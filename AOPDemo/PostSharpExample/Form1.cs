using System;
using System.Windows.Forms;

namespace PostSharpExample
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void BTN_SUBSCRIBE_Click(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(TXB_NAME.Text.Trim()) && !String.IsNullOrEmpty(TXB_ROOM.Text.Trim()))
                CoreBusiness.Describe(TXB_NAME.Text.Trim(), TXB_ROOM.Text.Trim());
            else
                MessageBox.Show("信息不完整","提示");
        }
    }
}
