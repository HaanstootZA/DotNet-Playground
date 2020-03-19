using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Shapes
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnGenerateClick(object sender, EventArgs e)
        {
            Shape circle = ShapeGenerator.GenerateCircle(20);
            pbImage.Image = ImageGenerator.GenerateImageForCircleOnScreen(pbImage.Width, pbImage.Height, circle);
            pbImage.Refresh();
        }
    }
}
