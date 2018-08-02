using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Tuhu;
using Tuhu.MessageQueue;

namespace EmailDemo001
{
    class Program
    {
        static void Main(string[] args)
        {
            var ms = new Ms()
            {
                Subject = "测试主题",
                To = new List<string>() {"chengongyi@tuhu.cn"},
                Body = "测试一下哈"
            };



            var jsons = JsonConvert.SerializeObject(ms);
            Console.WriteLine(jsons);
        }
    }

    public class Ms
    {
        public string Subject { get; set; }
        public List<string> To      { get; set; }
        public List<string> Cc { get; set; }
        public string Body { get; set; }
    }
}
