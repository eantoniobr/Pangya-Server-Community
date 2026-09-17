using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;
using System.Diagnostics;
using PangyaAPI.TGA;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;

namespace PangyaSuiteFiles.Forms
{
    public partial class FrmViewTGA : Form
    {
        public FrmViewTGA()
        {
            InitializeComponent();
        }
		private void rbOriginal_CheckedChanged(object sender, EventArgs e)
		{
			tamanhoImg();
		}

		public void tamanhoImg()
		{
			if (rbOriginal.Checked)
			{
				boxImagem.SizeMode = PictureBoxSizeMode.Normal;
			}
			else if (rbAchatar.Checked)
			{
				boxImagem.SizeMode = PictureBoxSizeMode.StretchImage;
			}
			else if (rbAjustar.Checked)
			{
				boxImagem.SizeMode = PictureBoxSizeMode.Zoom;
			}
			else
			{
				boxImagem.SizeMode = PictureBoxSizeMode.CenterImage;
			}
	
		}

		private void rbAjustar_CheckedChanged(object sender, EventArgs e)
		{
			tamanhoImg();
		}

		private void rbAchatar_CheckedChanged(object sender, EventArgs e)
		{
			tamanhoImg();
		}

		private void btnAbrir_Click(object sender, EventArgs e)
		{
			//IL_005a: Unknown result type (might be due to invalid IL or missing references)
			if (BuscarArquivo.ShowDialog() != 0 && File.Exists(BuscarArquivo.FileName))
			{
				string left = BuscarArquivo.FileName.Substring(checked(BuscarArquivo.FileName.Length - 3), 3);
				if (Operators.CompareString(left, "tga", TextCompare: false) == 0)
				{
					new TargaImage();
					TargaImage.LoadTargaImage(BuscarArquivo.FileName);
					boxImagem.Image = (Image)(object)TargaImage.LoadTargaImage(BuscarArquivo.FileName);
				}
				txtImagem.Text = BuscarArquivo.FileName;
			}
		}

		private void btnSalvar_Click(object sender, EventArgs e)
		{
			string text = Conversions.ToString((int)SaveFileDialog1.ShowDialog());
			if (text != "0")
			{
				txtImagem.Text = SaveFileDialog1.FileName;
				var newImage = ResizeImage(boxImagem.Image, 56, 56);
				/*boxImagem.Image*/
				newImage.Save(txtImagem.Text);	
				Interaction.MsgBox("Imagem Salva com sucesso!!!");
				Process.Start(text);
			}
			else
			{
				Interaction.MsgBox("Error Ao Salvar Imagem !");
			}
		}

        private void BtnSalvarMassa_Click(object sender, EventArgs e)
		{
			tamanhoImg();
			if (string.IsNullOrEmpty(txtImagemMassa.Text) == false)
			{
				foreach (var FileName in Directory.GetFiles(txtImagemMassa.Text))
				{
                    if (FileName.Contains(".tga"))
					{
						Directory.CreateDirectory(txtImagemMassa.Text+@"\Imagens\");
						new TargaImage();
						TargaImage.LoadTargaImage(FileName);
						boxImagem.Image = (Image)(object)TargaImage.LoadTargaImage(FileName);
						boxImagem.Image.Save(txtImagemMassa.Text + @"\Imagens\" + Path.GetFileNameWithoutExtension(FileName) + ".png");
						Debug.WriteLine("Imagem Salva com sucesso!!!");

					}
				}
			}
			else
			{
				Interaction.MsgBox("Error Ao Salvar Imagem !");
			}

		}

		Bitmap ResizeImage(Image image, int width, int height)
		{
			var destRect = new Rectangle(0, 0, width, height);
			var destImage = new Bitmap(width, height);

			destImage.SetResolution(image.HorizontalResolution, image.VerticalResolution);

			using (var graphics = Graphics.FromImage(destImage))
			{
				graphics.CompositingMode = CompositingMode.SourceCopy;
				graphics.CompositingQuality = CompositingQuality.HighQuality;
				graphics.InterpolationMode = InterpolationMode.HighQualityBicubic;
				graphics.SmoothingMode = SmoothingMode.HighQuality;
				graphics.PixelOffsetMode = PixelOffsetMode.HighQuality;

				using (var wrapMode = new ImageAttributes())
				{
					wrapMode.SetWrapMode(WrapMode.TileFlipXY);

					graphics.DrawImage(image, destRect, 0, 0, image.Width, image.Height, GraphicsUnit.Pixel, wrapMode);
				}
			}

			return destImage;
		}

        private void boxImagem_MouseMove(object sender, MouseEventArgs e)
        {

		}
    }
}
