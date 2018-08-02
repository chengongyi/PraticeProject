using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using FSLib.Network.Http;

namespace Spider01
{
    class Program
    {
        class TaskInfo
        {
            public string Name { get; set; }
            public int index { get; set; }
        }

        static void Main(string[] args)
        {
            for (int directory = 7389; directory < 8000; directory++)
            {
                var directoryName = directory.ToString();

                for (int i = 1; i < 500; i++)
                {
                    ThreadPool.QueueUserWorkItem(PooledFunc, new TaskInfo { index = i, Name = directoryName });
                }
            }

            Thread.Sleep(Int32.MaxValue);
        }

        static void PooledFunc(object state)
        {
            var taskInfo = (TaskInfo)state;
            try
            { 
                DownloadRemoteImageFile(UrlAddress(taskInfo.Name, taskInfo.index), FileDirectoryName(taskInfo.Name), FileName(taskInfo.Name, taskInfo.index));
                Console.WriteLine($"正在下载第{taskInfo.Name}下面的{taskInfo.index}张图片");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"下载第{taskInfo.Name}下面的{taskInfo.index}张图片失败");
            }
        }

        private static string FileName(string name, int index)
        {
            return $"D://PicSpace//{name}//{index}.jpg";
        }

        private static string FileDirectoryName(string name)
        {
            return $"D://PicSpace//{name}";
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
}
