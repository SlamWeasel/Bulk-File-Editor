using System.Diagnostics;
using System.Linq;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using Vlc.DotNet.Core;
using Vlc.DotNet.Core.Interops.Signatures;
using Vlc.DotNet.Forms;
using Microsoft.WindowsAPICodePack.Shell;
using Microsoft.WindowsAPICodePack.Shell.PropertySystem;
using Snap.Discord.GameSDK.ABI;
using System.Runtime.CompilerServices;
using System.Text.Unicode;
using Windows.ApplicationModel.UserActivities;

namespace Bulk_File_Editor
{
    public unsafe partial class MainForm : Form
    {
        bool MediaOpened = false, mediaPlayerOpen = false;
        public string mediaFolder;
        /// <summary>
        /// List of paths from the files that the program will go through
        /// </summary>
        public List<string> mediaFiles;
        private FolderBrowserDialog openFileDialog;
        /// <summary>
        /// Video Player Control
        /// </summary>
        private VlcControl mediaPlayer;
        /// <summary>
        /// Image Display Control
        /// </summary>
        private PictureBox pictureBox;
        private string[] imgExt = { ".png", ".jpg", ".jpeg", ".webp", ".bmp", ".gif" },
                            vidExt = { ".mp4", ".mov", ".webm" };
        private IDiscordActivityManager* discordActivityManager;
        private readonly long ProgramStart = DateTimeOffset.UtcNow.ToUnixTimeSeconds();
        private int progress = 1, progressGoal;

        [UnmanagedCallersOnly(CallConvs = [typeof(CallConvCdecl)])]
        private static unsafe void UpdateActivity(void* any, DiscordResult result)
        {
            Console.WriteLine($"UpdateActivity Result: {result}");
        }

        private void setActivity(string detail)
        {
            DiscordActivity activity1 = default;
            DiscordGame.Set(activity1.state, 128, RadioI.Checked ? "Going through Images" : RadioV.Checked ? "Going through Videos" : "Going through Files");
            DiscordGame.Set(activity1.details, 128, detail);
            activity1.timestamps.start = this.ProgramStart;
            DiscordGame.Set(activity1.assets.large_image, 128, "filescrubber-icon");
            DiscordGame.Set(activity1.assets.large_text, 128, "Software by SlamWeasel");
            DiscordGame.Set(activity1.assets.small_image, 128, "eye");
            DiscordGame.Set(activity1.assets.small_text, 128, "https://github.com/SlamWeasel/Bulk-File-Editor");
            discordActivityManager->update_activity(discordActivityManager, &activity1, null, &UpdateActivity);
        }

        // Non-Nullable Error
#pragma warning disable CS8618
        /// <summary>
        /// Program Entry, Constructor
        /// </summary>
        public unsafe MainForm()
        {
            InitializeComponent();

            // Adding Tooltips to the Buttons
            TipApply.SetToolTip(NextButton, "Apply the changes and go to the next file");
            TipStop.SetToolTip(StopButton, "If you loaded videos, this button stops the video playing");
            TipReload.SetToolTip(ReplayButton, "Replay the video (might need to be stopped first)");
            TipSkip.SetToolTip(SkipButton, "Skips the current file without doing any changes to it. It will come up in the next listing");
            TipOpen.SetToolTip(OpenButton, "Open another Folder, will reload the media list, might take some time");
            TipVolumne.SetToolTip(VolumeBar, "Set the volume the video is playing");

            DiscordCreateParams @params = default;
            Methods.DiscordCreateParamsSetDefault(&@params);
            @params.client_id = 1235644610655813632;
            @params.flags = (uint)DiscordCreateFlags.Default;
            IDiscordCore* core;
            Methods.DiscordCreate(3, &@params, &core);

            ThreadPool.QueueUserWorkItem(obj =>
            {
                IDiscordCore* d = (IDiscordCore*)(nint)obj!;
                while (true)
                {
                    Thread.Sleep(100);
                    d->run_callbacks(d);
                }
            }, (nint)core);

            discordActivityManager = core->get_activity_manager(core);
        }

        /// <summary>
        /// Loading the Main Form, initializing objects and attributes
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Form1_Load(object sender, EventArgs e)
        {
            AllocConsole();

            Console.Write("Bulk File Editor Active\nConsole will deliver debug and Error Data, DONT PANIC !\n\n\n");

            /*
             * Setting the Discord Activity
             */
            setActivity("No Folder selected yet");

            if (MediaOpened) { MediaPlaceholder.Dispose(); }
        }

        /// <summary>
        /// Allocate Console, default script to start a console for the output of the program
        /// </summary>
        /// <returns></returns>
        [DllImport("kernel32.dll", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        static extern bool AllocConsole();

        /// <summary>
        /// Loads the media at index 0 of the list. Also removes the current player, when a new mediaList is being loaded
        /// </summary>
        private void loadMedia()
        {
            // Check if Folder is empty
            if (mediaFiles.Count == 0)
            {
                MessageBox.Show("No files found!");
                return;
            }

            try
            {
                string mediaPath = mediaFiles[0];

                Console.WriteLine(mediaPath);

                /*
                 * Setting the Discord Activity
                 */
                setActivity($"Progress: {progress}/{progressGoal}"); 

                /*
                 * Creating the Imagebox for displaying images if it doesnt already exist
                 */
                if (RadioI.Checked)
                {
                    if (mediaPlayerOpen)
                        mediaPlayer.Dispose();
                    mediaPlayerOpen = false;

                    if (pictureBox != null)
                        pictureBox.Dispose();

                    pictureBox = mediaPath.EndsWith(".webp") ?
                        new PictureBox()
                        {
                            Image = new Func<string, Image>((p) => { using (WebP webp = new WebP()) return webp.Load(p); })(mediaPath),
                            BackColor = Color.Gray,
                        }
                        : new PictureBox()
                        {
                            ImageLocation = mediaPath
                        };

                    pictureBox.Bounds = new System.Drawing.Rectangle(5, 5, 400, 150);
                    pictureBox.SizeMode = PictureBoxSizeMode.Zoom;
                    pictureBox.Dock = DockStyle.Fill;
                    pictureBox.BorderStyle = BorderStyle.FixedSingle;

                    MediaHolder.Controls.Add(pictureBox);
                }
                /*
                 * Creating the VLC Media Player for displaying videos if it doesnt already exist
                 */
                else if (RadioV.Checked)
                {
                    mediaPlayerOpen = true;


                    if (pictureBox != null)
                        pictureBox.Dispose();

                    if (mediaPlayer == null || mediaPlayer.IsDisposed)
                    {
                        mediaPlayer = new VlcControl();
                        mediaPlayer.BeginInit();
                        mediaPlayer.VlcLibDirectory = new DirectoryInfo("C:\\Program Files\\VideoLAN\\VLC");
                        mediaPlayer.EndInit();

                        MediaHolder.Controls.Add(mediaPlayer);

                        mediaPlayer.Anchor = AnchorStyles.Top | AnchorStyles.Right | AnchorStyles.Bottom | AnchorStyles.Left;
                        mediaPlayer.Dock = DockStyle.Fill;
                        mediaPlayer.VlcMediaPlayer.Log += (sender, e) =>
                        {
                            Console.ForegroundColor = ConsoleColor.Yellow;
                            Console.Error.WriteLine(e.Message);
                            Console.ResetColor();
                        };
                        mediaPlayer.VlcMediaPlayer.EncounteredError += (sender, e) =>
                        {
                            throw new Exception("Shit");
                        };
                    }

                    mediaPlayer.VlcMediaPlayer.Play("file:///" + mediaPath.Replace("\\", "/"));
                }
                else return;

                FileInfo fileInfo = new FileInfo(mediaPath);
                if (!MediaPlaceholder.IsDisposed) MediaPlaceholder.Dispose();
                NameField.Text = fileInfo.Name.Substring(0, fileInfo.Name.Length - fileInfo.Extension.Length);
            }
            catch (Exception ex)
            {
                if (mediaFiles.Count == 0)
                    MessageBox.Show("No more Files left!", "Youre Done", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                else
                    MessageBox.Show(ex.Message);
            }
        }

        /// <summary>
        /// Clicking the next button, applies the changes and goes to the next media file
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1_Click(object sender, EventArgs e)
        {
            if (NameField.Text == "" || CommentField.Text == "")
                return;

            if (mediaFiles.Count == 0)
            {
                MessageBox.Show("No more Files left!", "Youre Done", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            if (mediaPlayer != null) mediaPlayer.VlcMediaPlayer.Stop();

            string mediaPath = mediaFiles[0];
            ShellFile file = ShellFile.FromFilePath(mediaPath);

            try
            {
                FileInfo fileInfo = new FileInfo(mediaPath);

                string newPath;
                if (fileInfo.Extension == ".gif")
                {
                    newPath = mediaFolder + "\\" + NameField.Text + "-RENAMED.gif";
                    File.Move(mediaPath, newPath, false);
                }
                else
                {
                    try
                    {
                        file.Properties.System.Comment.Value = CommentField.Text;
                        newPath = mediaFolder + "\\" + NameField.Text + fileInfo.Extension;
                        File.Move(mediaPath, newPath, false);
                    }
                    catch (PropertySystemException ex)
                    {
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.BackgroundColor = ConsoleColor.DarkRed;
                        Console.Write("\n" + ex + "\n");
                        Console.BackgroundColor = ConsoleColor.DarkGreen;
                        Console.Write("Ignoring Comment and adding '-RENAMED'");
                        Console.ResetColor();
                        Console.Write(" \n");
                        newPath = mediaFolder + "\\" + NameField.Text + "-RENAMED" + fileInfo.Extension;
                        File.Move(mediaPath, newPath, false);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.ForegroundColor = ConsoleColor.White;
                Console.BackgroundColor = ConsoleColor.DarkRed;
                Console.WriteLine(ex);
                Console.ResetColor();
                return;
            }
            finally
            {
                file.Dispose();
            }

            mediaFiles.RemoveAt(0);

            CommentField.Text = "";

            progress++;

            loadMedia();
        }

        /// <summary>
        /// Clicking on the label to load the first folder. Removed the label
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MediaPlaceholder_Click(object sender, EventArgs e)
        {
            openFileDialog = new FolderBrowserDialog()
            {
                InitialDirectory = "C:\\",
                ShowPinnedPlaces = true,
                ShowNewFolderButton = true,
                AutoUpgradeEnabled = true
            };
            DialogResult result = openFileDialog.ShowDialog();
            if (result == DialogResult.OK)
            {
                MediaOpened = true;
                mediaFolder = openFileDialog.SelectedPath;
                mediaFiles = new List<string>();

                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine(Directory.GetFiles(openFileDialog.SelectedPath).Length + " Files in the Folder");
                Console.ResetColor();
                LoadDisplay.Maximum = Directory.GetFiles(openFileDialog.SelectedPath).Length;
                LoadDisplay.Minimum = 0;
                LoadDisplay.Value = 0;
                int i = 1;
                foreach (string f in Directory.GetFiles(openFileDialog.SelectedPath))
                {
                    FileInfo fileInfo = new FileInfo(f);
                    ShellFile file = ShellFile.FromFilePath(f);

                    if (file.Properties.System.Comment.Value != "" && file.Properties.System.Comment.Value != null) continue;

                    file.Dispose();

                    if (RadioV.Checked && vidExt.Contains(fileInfo.Extension))
                    {
                        mediaFiles.Add(f);
                        Console.WriteLine("Added vid\n" + "File number " + i + " checked " + f);
                    }
                    else if (RadioI.Checked && imgExt.Contains(fileInfo.Extension) && !fileInfo.Name.Contains("-RENAMED."))
                    {
                        mediaFiles.Add(f);
                        Console.WriteLine("Added img\n" + "File number " + i + " checked " + f);
                    }

                    LoadDisplay.Value = i;

                    i++;
                }

                LoadDisplay.Value = 0;

                progressGoal = mediaFiles.Count();

                /*
                 * 
                 * The computation might take a while
                 * 
                 */

                loadMedia();

            }
        }

        /// <summary>
        /// Stops the player
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void StopButton_Click(object sender, EventArgs e)
        {
            if (!mediaPlayerOpen) return;

            mediaPlayer.VlcMediaPlayer.Stop();
        }

        /// <summary>
        /// Restarts the currently playing (or finished) video
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ReplayButton_Click(object sender, EventArgs e)
        {
            if (!mediaPlayerOpen) return;

            mediaPlayer.VlcMediaPlayer.Stop();
            mediaPlayer.VlcMediaPlayer.Play();
        }

        /// <summary>
        /// Pressing Enter after entering a value applies the changes
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CommentField_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Return)
                button1_Click(sender, e);
        }

        /// <summary>
        /// Removes the current item from the list
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SkipButton_Click(object sender, EventArgs e)
        {
            mediaFiles.RemoveAt(0);

            CommentField.Text = "";

            progress++;

            loadMedia();
        }

        /// <summary>
        /// Opens the Folder Selector to open restart the process of creating a list
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OpenButton_Click(object sender, EventArgs e)
        {
            if (!MediaPlaceholder.IsDisposed) return;
            MediaPlaceholder_Click(sender, e);
        }

        /// <summary>
        /// Adjusting the Volumne of the mediaplayer
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void VolumeBar_Scroll(object sender, EventArgs e)
        {
            if (!mediaPlayerOpen) return;

            mediaPlayer.VlcMediaPlayer.Audio.Volume = VolumeBar.Value * 2;
        }
    }
}

internal static class DiscordGame
{
    public static unsafe void Set(sbyte* reference, int length, string source)
    {
        Span<sbyte> sbytes = new(reference, length);
        sbytes.Clear();
        Utf8.FromUtf16(source.AsSpan(), MemoryMarshal.Cast<sbyte, byte>(sbytes), out _, out _);
    }
}
