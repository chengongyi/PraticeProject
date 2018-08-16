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

namespace TaskSchedler
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            Text = "Synchronization Context Task Scheduler Demo";
            Visible = true;
            Width = 400;
            Height = 100;
        }
          
        private readonly TaskScheduler m_syncContextTaskScheduler = TaskScheduler.FromCurrentSynchronizationContext();

        private CancellationTokenSource m_cts;

        protected override void OnMouseClick(MouseEventArgs e)
        {
            if (m_cts != null)
            {
                m_cts.Cancel();
                m_cts = null;
            }
            else
            {
                Text = "Operation runing";

                m_cts = new CancellationTokenSource();

                var t = new Task<Int32>(() => Sum(m_cts.Token, 200000), m_cts.Token);

                t.Start();

                t.ContinueWith(task => Text = "Result:" + task.Result,
                    CancellationToken.None, TaskContinuationOptions.OnlyOnRanToCompletion,
                    m_syncContextTaskScheduler);

                base.OnMouseClick(e);
            }
        }

        private int Sum(CancellationToken token, int i)
        {
            return 100000;
        }
        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }

    internal sealed class MyForm : Form
    {
        public MyForm()
        {
            Text = "Synchronization Context Task Scheduler Demo";
            Visible = true;
            Width = 400;
            Height = 100;
        }

        private readonly TaskScheduler m_syncContextTaskScheduler = TaskScheduler.FromCurrentSynchronizationContext();

        private CancellationTokenSource m_cts;

        protected override void OnMouseClick(MouseEventArgs e)
        {
            if (m_cts != null)
            {
                m_cts.Cancel();
                m_cts = null;
            }
            else
            {
                Text = "Operation runing";

                m_cts = new CancellationTokenSource();

                var t = new Task<Int32>(() => Sum(m_cts.Token, 200000), m_cts.Token);

                t.Start();

                t.ContinueWith(task => Text = "Result:" + task.Result,
                    CancellationToken.None, TaskContinuationOptions.OnlyOnRanToCompletion,
                    m_syncContextTaskScheduler);

                base.OnMouseClick(e);
            }
        }

        private int Sum(CancellationToken token, int i)
        {
            return 100000;
        }
    }
}
