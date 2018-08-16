using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Practice.Event002
{
    public delegate void FileWatchEventHandler(object sender, MyEvent args);

    public class FileWatch
    {
        private bool _bLastStatus = false;

        public event FileWatchEventHandler FileWatchEvent;

        protected virtual void OnFileChange(MyEvent e)
        {
            if (FileWatchEvent != null)
            {
                FileWatchEvent(this, e);
            }
        }

        public void MonitorFile()
        {
            var filePath = @"E:\";

            List<string> filesNames = new List<string>();

            while (true)
            {
                var files = new DirectoryInfo(filePath).GetFiles().Select(o => o.Name).ToList();

                if (files.Count != filesNames.Count)
                {
                    string op = "";
                    List<string> names;
                    if (files.Count > filesNames.Count)
                    {
                        op = "添加";
                        names = files.Except(filesNames).ToList();
                    }
                    else
                    {
                        op = "删除";
                        names = filesNames.Except(files).ToList();
                    }

                    filesNames = files;

                    OnFileChange(new MyEvent(names,op));
                }

                Thread.Sleep(250);
            }

        }
    }

    public class MyEvent : EventArgs
    {
        public List<string> FileNames { get; set; }
        public string Op { get; set; }

        public MyEvent(List<string> names,string op)
        {
            FileNames = names;
            Op = op;
        }
    }

    class Program
    {
        static FileWatch FileWatchEventSource;

        static void Main(string[] args)
        {
            FileWatchEventSource = new FileWatch();

            //1. 启动后台线程添加监视事件
            var thrd = new Thread(FileWatchEventSource.MonitorFile)
            {
                IsBackground = true
            };

            thrd.Start();

            //2.注册本地事件处理方法
            FileWatchEventSource.FileWatchEvent += OnFileChange;

            Console.ReadLine();
        }

        private static void OnFileChange(object Sender, MyEvent e)
        {
            foreach (var eFileName in e.FileNames)
            {
                Console.WriteLine(DateTime.Now.ToString() + ": 文件发生改变. --" + e.Op + "  " + eFileName);
            }
        }
    }
}
