using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace MappingApplication
{
    class Layer
    {
        int m_size;
        int m_parent;
        int m_index;
        Layer m_next;
        PageNode[] m_nodes;

        public int Size { get { return m_size; } }

        public Layer Next { get { return m_next; } }

        public int Index { get { return m_index; } }

        public int Max
        {
            get
            {
                int max = 0;
                foreach (PageNode n in m_nodes)
                {
                    if (n.Size > max)
                        max = n.Size;
                }
                return max;
            }
        }
        
        public SizeF MaxSize
        {
            get
            {
                Bitmap bmp = new Bitmap(1, 1);
                Graphics g = Graphics.FromImage(bmp);
                SizeF max = new SizeF(0f, 0f);
                foreach (PageNode n in m_nodes)
                {
                    if (n.StringSize(g).Width > max.Width)
                        max = n.StringSize(g);
                }
                return max;
            }
        }

        public Layer(PageNode[] Links, int ParentIndex)
        {
            m_nodes = Links;
            m_index = ParentIndex + 1;
            m_parent = ParentIndex;
            m_size = Links.Length;
        }

        public void AddLayer()
        {
            if (m_next == null)
            {
                List<PageNode> newnodes = new List<PageNode>();
                foreach (PageNode n in m_nodes)
                {
                    newnodes.AddRange(n.GetPageLinks());
                }
                InsertLayerAfter(newnodes.ToArray());
            }
            else
                m_next.AddLayer();
        }

        private void SetNextLayer(Layer next)
        {
            if (m_next != null)
            {
                m_next.IncrementIndex(m_index, m_index + 1);
                next.m_next = m_next;
            }
            m_next = next;
        }

        private void InsertLayerAfter(PageNode[] Links)
        {
            Layer newlayer = new Layer(Links, m_index);
            SetNextLayer(newlayer);
        }

        private void IncrementIndex(int parent, int newparent)
        {
            if (parent == m_parent)
            {
                m_parent = newparent;
                if (m_next != null)
                    m_next.IncrementIndex(m_index, ++m_index);
            }
        }

        private void DecrementIndex(int parent, int newparent)
        {
            if (m_parent == parent)
            {
                m_parent = newparent;
                if (m_next != null)
                    m_next.DecrementIndex(m_index, --m_index);
            }
        }

        public PageNode[] Links
        {
            get
            {
                return m_nodes;
            }
        }

        public Queue<PageNode> GetAllLinks()
        {
            Queue<PageNode> links;
            if (m_next != null)
                links = m_next.GetAllLinks();
            else
                links = new Queue<PageNode>();
            foreach (PageNode pn in m_nodes)
                links.Enqueue(pn);
            return links;
        }
    }
}
