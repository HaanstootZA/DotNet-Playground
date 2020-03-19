using System;
using System.Drawing;
using System.Collections.Generic;

namespace MappingApplication
{
    class ImageGenerator
    {
        private int m_height;
        private int m_width;
        private MPoint m_origin;

        public MPoint Origin
        {
            get { return m_origin; }
        }

        public ImageGenerator(int Width, int Height, MPoint Origin)
        {
            m_height = Height;
            m_width = Width;
            m_origin = Origin;
        }

        private bool SetPixel(int x, int y, ref Bitmap bmp)
        {
            bool cont = true;
            if (x >= m_width || x < 0 || y >= m_height || y < 0)
                cont = false;
            if (cont)
                bmp.SetPixel(x, y, Color.Red);
            return cont;
        }

        //private void SetDot(int x, int y, ref Bitmap bmp, int size)
        //{
        //    MPoint mid = new MPoint(x, y);
        //    DrawCircle(size, mid, ref bmp);
        //}

        //private void SetDot(string Text, MPoint pos, ref Bitmap bmp)
        //{
        //    try
        //    {
        //        Graphics g = Graphics.FromImage(bmp);
        //        Font mf = new Font("Calibri", 12, FontStyle.Regular);
        //        int height = mf.Height;
        //        SizeF s = g.MeasureString(Text, mf);
        //        g.DrawRectangle(Pens.Black, pos.iX - (int)(s.Width / 2), pos.iY - s.Height / 2, s.Width + 2, s.Height + 1);
        //        g.FillRectangle(Brushes.White, pos.iX - (int)(s.Width / 2) + 1, pos.iY - ((s.Height) / 2) + 1, s.Width, s.Height);
        //        g.DrawString(Text, new Font("Calibri", 12, FontStyle.Regular), Brushes.Black, new PointF(pos.iX - (int)(s.Width / 2), pos.iY - s.Height / 2));
        //    }
        //    catch { }
        //}

        private void DrawLine(MPoint pos1, MPoint pos2, ref Bitmap bmp)
        {
            try
            {
                Graphics g = Graphics.FromImage(bmp);
                Pen p1 = new Pen(Color.Red);
                g.DrawLine(p1, pos1.Point(), pos2.Point());
            }
            catch { }
        }

        private void DrawCoordinates(ref Queue<PageNode> nodes, ref Bitmap bmp)
        {
            foreach (PageNode n in nodes)
            {
                if (n.Parent != null)
                    DrawLine(n.Parent.Position + m_origin, n.Position + m_origin, ref bmp);
                n.SetDot(m_origin, ref bmp);
            }
        }

        private void DrawCircle(double rad, MPoint midp, ref Bitmap bmp)
        {
            //Start at Xm and draw up to Xm + R
            for (int x = 0; x <= rad; x++)
            {
                int y = (int)Math.Floor(Math.Sqrt(Math.Pow(Convert.ToDouble(rad), 2) - Math.Pow(x, 2)));
                SetPixel(midp.iX + x, midp.iY + y, ref bmp);
                SetPixel(midp.iX + x, midp.iY - y, ref bmp);
                SetPixel(midp.iX - x, midp.iY + y, ref bmp);
                SetPixel(midp.iX - x, midp.iY - y, ref bmp);
                SetPixel(midp.iX + y, midp.iY + x, ref bmp);
                SetPixel(midp.iX + y, midp.iY - x, ref bmp);
                SetPixel(midp.iX - y, midp.iY + x, ref bmp);
                SetPixel(midp.iX - y, midp.iY - x, ref bmp);
            }
        }

        public void GenerateImage(ref Queue<PageNode> nodes, ref Bitmap bmp)
        {
            m_height = bmp.Height;
            m_width = bmp.Width;
            DrawCoordinates(ref nodes, ref bmp);
        }

        public Bitmap GenerateImage(ref Queue<PageNode> nodes)
        {
            Bitmap temp = new Bitmap(m_width, m_height);
            DrawCoordinates(ref nodes, ref temp);
            return temp;
        }
    }
}
