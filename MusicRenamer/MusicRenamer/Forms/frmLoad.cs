using System;
using System.Windows.Forms;

namespace MusicRenamer
{
    public partial class WaitForm : Form
    {
        private const int CP_NOCLOSE_BUTTON = 0x200;
        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams myCp = base.CreateParams;
                myCp.ClassStyle = myCp.ClassStyle | CP_NOCLOSE_BUTTON;
                return myCp;
            }
        }

        public WaitForm()
        {
            InitializeComponent();
        }

        public void ShowForm() {
            Timer.Start();
            this.ShowDialog();
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            if (!ThreadHelper.Thread_Busy)
            {
                DialogResult = System.Windows.Forms.DialogResult.OK;
                this.Close();
            }
        }
    }
}
