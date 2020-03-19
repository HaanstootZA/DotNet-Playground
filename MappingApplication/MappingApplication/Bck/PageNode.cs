using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace MappingApplication
{
    class PageNode
    {
        private int m_size;
        private MPoint m_position;
        private Page m_Page;
        private PageNode m_parent;
        private Font m_font;
        public int Index;

        public int Size { get {return m_size;}}
        public PageNode Parent { get { return m_parent; } }
        public bool Root { get { return m_parent == null; } }
        public MPoint Position
        {
            get { return m_position; }
            set { m_position = value; }
        }

        public PageNode(Page Page, PageNode Parent) {
            m_Page = Page;
            m_parent = Parent;
            m_size = 0;
            m_position = new MPoint(0, 0);
            m_font = new Font("Calibri", 12, FontStyle.Regular);
        }

        public PageNode[] GetPageLinks() { 
            Page[] temp = m_Page.GetLinks();
            PageNode[] newnodes = new PageNode[temp.Length];
            int i = 0;
            foreach (Page p in temp) {
                newnodes[i] = new PageNode(p, this);
                i++;
            }
            m_size = temp.Length;
            return newnodes;
        }

        public override string ToString()
        {
            return m_Page.Title;
        }

        public SizeF StringSize(Graphics g)
        {
            return g.MeasureString(m_Page.Title, m_font);
        }

        public void SetDot(MPoint Origin, ref Bitmap bmp)
        {
            try
            {
                Graphics g = Graphics.FromImage(bmp);
                SizeF s = StringSize(g);
                MPoint pos = m_position + Origin - new MPoint(s.Width / 2, (s.Height) / 2);
                g.DrawRectangle(Pens.Black, pos.iX, pos.iY, s.Width + 2, s.Height + 1);
                pos += 1;
                g.FillRectangle(Brushes.White, pos.iX, pos.iY, s.Width, s.Height);
                pos -= 1;
                g.DrawString(m_Page.Title, m_font, Brushes.Black, pos.PointF());
            }
            catch { }
        }
    }
}
