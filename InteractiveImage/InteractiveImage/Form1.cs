using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing.Drawing2D;

namespace InteractiveImage
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            Bitmap bmp = new Bitmap(pbxImage.Width, pbxImage.Height);
            Random ran = new Random();
            for (int x = 0; x < bmp.Width; x++)
            {
                for (int y = 0; y < bmp.Height; y++)
                {
                    if (x + y == ran.Next((x + y) * 2))
                        bmp.SetPixel(x, y, Color.Black);
                    else
                        bmp.SetPixel(x, y, Color.White);
                }
            }
            pbxImage.Image = bmp;
            pbxImage.Refresh();
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Up)
            {
                float zoom = 2f;
                Bitmap bm = new Bitmap(pbxImage.Image, Convert.ToInt32(pbxImage.Image.Width * zoom), Convert.ToInt32(pbxImage.Image.Height * zoom));
                Graphics grap = Graphics.FromImage(bm);
                grap.InterpolationMode = InterpolationMode.HighQualityBicubic;
                grap.ScaleTransform(zoom, zoom);

                pbxImage.Height = bm.Height;
                pbxImage.Width = bm.Width;
                pbxImage.Image = bm;
                pbxImage.Refresh();
            }
            if (e.KeyCode == Keys.Down)
            {
                float zoom = 0.5f;
                Bitmap bm = new Bitmap(pbxImage.Image, Convert.ToInt32(pbxImage.Image.Width * zoom), Convert.ToInt32(pbxImage.Image.Height * zoom));
                Graphics grap = Graphics.FromImage(bm);
                grap.InterpolationMode = InterpolationMode.HighQualityBicubic;
                grap.SmoothingMode = SmoothingMode.HighQuality;
                grap.ScaleTransform(zoom, zoom);

                pbxImage.Height = bm.Height;
                pbxImage.Width = bm.Width;
                pbxImage.Image = bm;
                pbxImage.Refresh();
            }
        }
    }
}
