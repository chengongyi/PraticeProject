using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AsyncAwait014
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            this.button1.Enabled = false;
            this.label1.Text = "Doing";

            //Thread.Sleep(3000);
            await Task.Delay(3000);

            this.button1.Enabled = true;
            this.label1.Text = "Done";


        }
    }
}
