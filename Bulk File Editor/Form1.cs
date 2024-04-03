using System.Diagnostics;
using System.Linq;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using Vlc.DotNet.Core;
using Vlc.DotNet.Core.Interops.Signatures;
using Vlc.DotNet.Forms;
using Microsoft.WindowsAPICodePack.Shell;

namespace Bulk_File_Editor
{
    public partial class MainForm : Form
    {
        bool MediaOpened = false, mediaPlayerOpen = false;
        public string mediaFolder;
        public List<string> mediaFiles;
        private FolderBrowserDialog openFileDialog;
        private VlcControl mediaPlayer;
        private PictureBox pictureBox;
        private string[]    imgExt = { ".png", ".jpg", ".jpeg", ".webp", ".bmp" },
                            vidExt = { ".mp4", ".mov", ".webm", ".gif" };

        public MainForm()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            AllocConsole();
            if (MediaOpened) { MediaPlaceholder.Dispose(); }
        }

        [DllImport("kernel32.dll", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        static extern bool AllocConsole();

        private void button1_Click(object sender, EventArgs e)
        {
            if (NameField.Text == "" || CommentField.Text == "")
                return;

            try
            {
                string mediaPath = mediaFiles[0];
                ShellFile file = ShellFile.FromFilePath(mediaPath);
                FileInfo fileInfo = new FileInfo(mediaPath);
                file.Properties.System.Comment.Value = CommentField.Text;
                string newPath = mediaFolder + "\\" + NameField.Text + fileInfo.Extension;
                file.Dispose();
                File.Move(mediaPath, newPath, false);
            }
            catch(Exception ex) 
            {
                Console.WriteLine(ex);
                return;
            }

            mediaFiles.RemoveAt(0);

            CommentField.Text = "";

            loadMedia();
        }

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

                Console.WriteLine(Directory.GetFiles(openFileDialog.SelectedPath).Length + " Files in the Folder");
                int i = 1;
                foreach (string f in Directory.GetFiles(openFileDialog.SelectedPath))
                {
                    ShellFile file = ShellFile.FromFilePath(f);
                    //MessageBox.Show(file.Properties.System.Comment.Value);

                    if (file.Properties.System.Comment.Value != "" && file.Properties.System.Comment.Value != null) continue;

                    file.Dispose();
                    FileInfo fileInfo = new FileInfo(f);

                    if (RadioV.Checked && vidExt.Contains(fileInfo.Extension))
                    {
                        mediaFiles.Add(f);
                        Console.WriteLine("Added vid\n" + "File number " + i + " checked " + f);
                    }
                    else if (RadioI.Checked && imgExt.Contains(fileInfo.Extension))
                    {
                        mediaFiles.Add(f);
                        Console.WriteLine("Added img\n" + "File number " + i + " checked " + f);
                    }

                    i++;
                };


                /*
                 * 
                 * The computation might take a while
                 * 
                 */

                loadMedia();

            }
        }

        private void loadMedia()
        {
            string mediaPath = mediaFiles[0];

            Console.WriteLine(mediaPath);
            try
            {
                if (RadioI.Checked)
                {
                    if (mediaPlayerOpen)
                        mediaPlayer.Dispose();
                    mediaPlayerOpen = false;

                    if (pictureBox != null)
                        pictureBox.Dispose();
                    pictureBox = new PictureBox()
                    {
                        ImageLocation = mediaPath,
                        Bounds = new System.Drawing.Rectangle(5, 5, 400, 150),
                        SizeMode = PictureBoxSizeMode.CenterImage,
                        BorderStyle = BorderStyle.FixedSingle
                    };

                    this.Controls.Add(pictureBox);
                }
                else if (RadioV.Checked)
                {
                    mediaPlayerOpen = true;


                    if (pictureBox != null)
                        pictureBox.Dispose();

                    if (mediaPlayer == null)
                    {
                        mediaPlayer = new VlcControl();
                        mediaPlayer.BeginInit();
                        mediaPlayer.VlcLibDirectory = new DirectoryInfo("C:\\Program Files\\VideoLAN\\VLC");
                        mediaPlayer.VlcMediaplayerOptions = new[] { "--config=\"C:\\Users\\3rike\\AppData\\Roaming\\vlc\\vlcrc\"", "-vv" };
                        mediaPlayer.EndInit();

                        MediaHolder.Controls.Add(mediaPlayer);

                        mediaPlayer.Anchor = AnchorStyles.Top | AnchorStyles.Right | AnchorStyles.Bottom | AnchorStyles.Left;
                        mediaPlayer.Dock = DockStyle.Fill;
                        mediaPlayer.VlcMediaPlayer.Log += (sender, e) =>
                        {
                            Console.Error.WriteLine(e.Message);
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
                MediaPlaceholder.Dispose();
                NameField.Text = fileInfo.Name;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
