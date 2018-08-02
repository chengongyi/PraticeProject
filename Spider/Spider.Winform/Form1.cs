using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Spider.Winform
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            for (int directory = 8807; directory < 8808; directory++)
            {
                var directoryName = directory.ToString();

                ThreadPool.QueueUserWorkItem(PooledFunc, new TaskInfo { Name = directoryName });
            }
        }
        static void PooledFunc(object state)
        {
            var taskInfo = (TaskInfo)state;
            try
            {
                for (int index =1; index < 500; index++)
                {
                    DownloadRemoteImageFile(UrlAddress(taskInfo.Name, index), FileDirectoryName(taskInfo.Name), FileName(taskInfo.Name, index));
                    Console.WriteLine($"正在下载第{taskInfo.Name}下面的{taskInfo.index}张图片");
                }
              
            }
            catch (Exception ex)
            {
                Console.WriteLine($"下载第{taskInfo.Name}下面的{taskInfo.index}张图片失败");
            }
        }

        private static string FileName(string name, int index)
        {
            return $"E://PicSpace//{name}//{index}.jpg";
        }

        private static string FileDirectoryName(string name)
        {
            return $"E://PicSpace//{name}";
        }

        private static string UrlAddress(string directory, int index)
        {
            var name = index.ToString().PadLeft(3, '0');
            return $"http://hahost2.imgscloud.com/file/{directory}/{directory}_{name}.jpg";
        }

        private static void DownloadRemoteImageFile(string uri, string dirctoryName, string fileName)
        {
            if (File.Exists(fileName))
            {
                File.Delete(fileName);
            }

            if (!Directory.Exists(dirctoryName))
            {
                Directory.CreateDirectory(dirctoryName);
            }

            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(uri);
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();

            // Check that the remote file was found. The ContentType
            // check is performed since a request for a non-existent
            // image file might be redirected to a 404-page, which would
            // yield the StatusCode "OK", even though the image was not
            // found.
            if ((response.StatusCode == HttpStatusCode.OK ||
                 response.StatusCode == HttpStatusCode.Moved ||
                 response.StatusCode == HttpStatusCode.Redirect) &&
                response.ContentType.StartsWith("image", StringComparison.OrdinalIgnoreCase))
            {

                // if the remote file was found, download oit
                using (Stream inputStream = response.GetResponseStream())
                using (Stream outputStream = File.OpenWrite(fileName))
                {
                    byte[] buffer = new byte[9999999];
                    int bytesRead;
                    do
                    {
                        bytesRead = inputStream.Read(buffer, 0, buffer.Length);
                        outputStream.Write(buffer, 0, bytesRead);
                    } while (bytesRead != 0);
                }
            }
        }
    }

    class TaskInfo
    {
        public string Name { get; set; }
        public int index { get; set; }
    }
}
