using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PostSharp.Laos;

namespace AOPDemo2
{
    class Program
    {
        static void Main(string[] args)
        {
            Describe("张总", "504");
        }

        [Logging(BusinessName = "预定房间")]
        public static void Describe(string memberName, string roomNumber)
        {
            Console.WriteLine("测试");
        }

    }

    class LoggingHelper
    {
        private const String _errLogFilePath = @"log.txt";

        public static void Writelog(String message)
        {
            StreamWriter sw = new StreamWriter(_errLogFilePath, true);
            String logContent = String.Format("[{0}]{1}", DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss"), message);
            sw.WriteLine(logContent);
            sw.Flush();
            sw.Close();
        }
    }


    [Serializable]
    [AttributeUsage(AttributeTargets.Method, AllowMultiple = true, Inherited = true)]
    public sealed class LoggingAttribute : OnMethodBoundaryAspect
    {
        public string BusinessName { get; set; }

        public override void OnEntry(MethodExecutionEventArgs eventArgs)
        {
            LoggingHelper.Writelog(BusinessName + "开始执行");
        }

        public override void OnExit(MethodExecutionEventArgs eventArgs)
        {
            LoggingHelper.Writelog(BusinessName + "成功完成");
        }
    }
}
