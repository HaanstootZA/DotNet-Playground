using System;
using System.Windows.Forms;
using System.Drawing;
using System.Collections.Generic;

namespace MappingApplication
{
    partial class Form1 : Form
    {
        private string m_testtext;
        private Layer m_rootlayer;

        public Form1()
        {
            InitializeComponent();
            m_testtext = "0";
            txtDMin.Text = "100";
            txtLeafs.Text = "5";
            txtLevels.Text = "3";
        }

        private void txtBox_TextChanged(object sender, EventArgs e)
        {
            if (sender.GetType() == typeof(TextBox))
            {
                TextBox temp = (TextBox)sender;
                if (!MapMath.IsNumeric(temp.Text) && temp.Text != "")
                {
                    temp.Text = m_testtext;
                }
            }
        }

        private void txtBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (sender.GetType() == typeof(TextBox))
            {
                TextBox temp = (TextBox)sender;
                m_testtext = temp.Text;
                if (Char.IsLetter(e.KeyChar))
                    e.Handled = true;
            }
        }

        private Layer GetRootLayer() {
            return new Layer(new PageNode[] { new PageNode(new Page("Root"), null) }, -1);
        }

        private void InitializeDataStructure(int Depth, int Nodes)
        {
            MapMath.NODES = Nodes;
            m_rootlayer = GetRootLayer();
            Depth--;
            while (Depth > 0)
            {
                m_rootlayer.AddLayer();
                Depth--;
            }
        }
        
        private void btnGenerate_Click(object sender, EventArgs e)
        {
            InitializeDataStructure(Convert.ToInt32(txtLevels.Text), Convert.ToInt32(txtLeafs.Text));
            MapGenerator mg = new MapGenerator(Convert.ToDouble(txtDMin.Text));
            mg.GenerateMap(m_rootlayer);
            int size = ((int)Math.Ceiling(MapMath.MINRAD))*2;
            MapMath.MINRAD = 0;
            ImageGenerator ig = new ImageGenerator(size, size, MapMath.FindMiddle(size, size));
            Queue<PageNode> NodeQueue = m_rootlayer.GetAllLinks();
            pbImage.Height = size;
            pbImage.Width = size;
            pbImage.Image = ig.GenerateImage(ref NodeQueue);
            pbImage.Refresh();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            pbImage.Image.Save(@"C:\Users\hendrikj\Desktop\Map.jpg", System.Drawing.Imaging.ImageFormat.Jpeg);
        }

        private void pbImage_MouseClick(object sender, MouseEventArgs e)
        {
            String temp = "Mouse Clicked on Location: \r\n x:" + e.Location.X + " y:" + e.Location.Y;
            MessageBox.Show(temp);
        }
    }
}