using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using PangyaAPI.UCC;
using System.Windows.Forms;
using System.Drawing.Imaging;

namespace PangyaSuiteFiles.Forms
{
    public partial class FrmSDConvert : Form
    {
        string ActualFileSD;
        Bitmap FrontImg;
        Bitmap BackImg;
        Bitmap IconImg;
        bool isRChar = false;
        bool AutoTransparancy = false;
        public FrmSDConvert()
        {
            InitializeComponent();
        }
        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            openFileDialog1.Filter = "SelfDesign File (*.jpg)|*.jpg|All files (*.*)|*.*";
            openFileDialog1.FilterIndex = 1;
            openFileDialog1.RestoreDirectory = true;

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    ActualFileSD = Path.GetFileNameWithoutExtension(openFileDialog1.FileName);
                    ExtractZipFile(openFileDialog1.FileName, "", "C:\\Windows\\Temp\\davedevils\\" + ActualFileSD);
                    ReadPangyaPicture("front");
                    ReadPangyaPicture("back");

                    bool exists = File.Exists("C:\\Windows\\Temp\\davedevils\\" + ActualFileSD + "\\icon");

                    if (exists)
                        ReadPangyaPicture("icon");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: Could not read file from disk. Original error: " + ex.Message);
                }
            }
        }

        public void ReadPangyaPicture(string filename)
        {
            string path = "C:\\Windows\\Temp\\davedevils\\" + ActualFileSD + "\\" + filename;

            var ucc = new UCCFile(path);

            var flag = ucc.GetBitmapFromFileEntry(filename);
            if (filename == "front")
            {
                picfront.Image = flag;
                FrontImg = flag;
            }
            else if (filename == "back")
            {
                picback.Image = flag;
                BackImg = flag;
            }
            else if (filename == "icon")
            {
                picicon.Image = flag;
                IconImg = flag;
            }
        }

        public void SavePangyaPicture(string filename, Bitmap Img)
        {

            int width = Img.Width;
            int height = Img.Height;

            int x = 0;
            int y = 0;
            FileStream fs = new FileStream("C:\\Windows\\Temp\\davedevils\\" + ActualFileSD + "\\" + filename, FileMode.Create, FileAccess.Write);
            while (y < height)
            {
                Color pix = Img.GetPixel(x, y);
                fs.WriteByte(pix.B);
                fs.WriteByte(pix.G);
                fs.WriteByte(pix.R);

                if (isRChar == false || filename == "icon")
                    fs.WriteByte(pix.A);

                x++;
                if (x == width)
                {
                    x = 0;
                    y++;
                }
            }

            fs.Close();
        }
        public void ExtractZipFile(string archiveFilenameIn, string password, string outFolder)
        {
            PangyaAPI.ZIP.ZipFile zf = null;
            try
            {
                FileStream fs = File.OpenRead(archiveFilenameIn);
                zf = PangyaAPI.ZIP.ZipFile.Read(fs);
                if (!String.IsNullOrEmpty(password))
                {
                    zf.Password = password;     // AES encrypted entries are handled automatically
                }
                foreach (var zipEntry in zf)
                {
                    if (!zipEntry.IsDirectory)
                    {
                        continue;           // Ignore directories
                    }
                    String entryFileName = zipEntry.FileName;
                    // to remove the folder from the entry:- entryFileName = Path.GetFileName(entryFileName);
                    // Optionally match entrynames against a selection list here to skip as desired.
                    // The unpacked length is available in the zipEntry.Size property.

                    byte[] buffer = new byte[4096];     // 4K is optimum
                    Stream zipStream = zipEntry.InputStream;

                    // Manipulate the output filename here as desired.
                    String fullZipToPath = Path.Combine(outFolder, entryFileName);
                    string directoryName = Path.GetDirectoryName(fullZipToPath);
                    if (directoryName.Length > 0)
                        Directory.CreateDirectory(directoryName);

                    // Unzip file in buffered chunks. This is just as fast as unpacking to a buffer the full size
                    // of the file, but does not waste memory.
                    // The "using" will close the stream even if an exception occurs.
                    using (FileStream streamWriter = File.Create(fullZipToPath))
                    {
                        Copy(zipStream, streamWriter, buffer);
                    }
                }
            }
            finally
            {
                if (zf != null)
                {
                    zf.Close(); // Ensure we release resources
                }
            }
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {

            SavePangyaPicture("front", FrontImg);
            SavePangyaPicture("back", BackImg);

            bool existsicon = System.IO.File.Exists("C:\\Windows\\Temp\\davedevils\\" + ActualFileSD + "\\icon");

            if (existsicon)
                SavePangyaPicture("icon", IconImg);

            using (PangyaAPI.ZIP.ZipFile zip = new PangyaAPI.ZIP.ZipFile())
            {
                zip.AddFile("C:\\Windows\\Temp\\davedevils\\" + ActualFileSD);
                zip.Save(ActualFileSD + ".jpg");
            }
            if (File.Exists(ActualFileSD + ".jpg"))
                MessageBox.Show("Saved at " + ActualFileSD + ".jpg");
            else
                MessageBox.Show("Save has fail :(");

        }

        private void exportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //export
            bool exists = System.IO.Directory.Exists(ActualFileSD);

            if (!exists)
                System.IO.Directory.CreateDirectory(ActualFileSD);

            Bitmap frontsave = new Bitmap(FrontImg);
            Bitmap backsave = new Bitmap(BackImg);
            frontsave.Save(ActualFileSD + "\\" + "front.png", ImageFormat.Png);
            backsave.Save(ActualFileSD + "\\" + "back.png", ImageFormat.Png);

            frontsave.Dispose();
            backsave.Dispose();

            bool existsicon = System.IO.File.Exists("C:\\Windows\\Temp\\davedevils\\" + ActualFileSD + "\\icon");

            if (existsicon)
            {
                Bitmap iconsave = new Bitmap(IconImg);
                iconsave.Save(ActualFileSD + "\\" + "icon.png", ImageFormat.Png);
                iconsave.Dispose();
            }

            MessageBox.Show("Saved in folder :" + ActualFileSD);
        }

        private void importToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (File.Exists(ActualFileSD + "\\" + "front.png") == false
                || File.Exists(ActualFileSD + "\\" + "back.png") == false)
            {
                MessageBox.Show("You need import before export ... The Folder of import ->  :" + ActualFileSD);
            }
            else
            {
                //import
                Image Front = Image.FromFile(ActualFileSD + "\\" + "front.png");
                Image Back = Image.FromFile(ActualFileSD + "\\" + "back.png");

                Bitmap frontload = new Bitmap(Front);
                Bitmap backload = new Bitmap(Back);

                picfront.Image = frontload;
                FrontImg = new Bitmap(picfront.Image);
                picback.Image = backload;
                BackImg = new Bitmap(picback.Image);

                Back.Dispose();
                Front.Dispose();

                bool exists = File.Exists(ActualFileSD + "\\" + "icon.png");

                if (exists == true)
                {
                    Image Icon = Image.FromFile(ActualFileSD + "\\" + "icon.png");
                    Bitmap iconload = new Bitmap(Icon);
                    picicon.Image = iconload;
                    IconImg = new Bitmap(picicon.Image);
                    Icon.Dispose();
                }

                MessageBox.Show("File have been imported");
            }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked == true)
                isRChar = true;
            else
                isRChar = false;
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox2.Checked == true)
                AutoTransparancy = true;
            else
                AutoTransparancy = false;
        }

       void Copy(Stream source, Stream destination, byte[] buffer)
        {
            if (source == null)
            {
                throw new ArgumentNullException(nameof(source));
            }

            if (destination == null)
            {
                throw new ArgumentNullException(nameof(destination));
            }

            if (buffer == null)
            {
                throw new ArgumentNullException(nameof(buffer));
            }

            // Ensure a reasonable size of buffer is used without being prohibitive.
            if (buffer.Length < 128)
            {
                throw new ArgumentException("Buffer is too small", nameof(buffer));
            }

            bool copying = true;

            while (copying)
            {
                int bytesRead = source.Read(buffer, 0, buffer.Length);
                if (bytesRead > 0)
                {
                    destination.Write(buffer, 0, bytesRead);
                }
                else
                {
                    destination.Flush();
                    copying = false;
                }
            }
        }
    }
}
