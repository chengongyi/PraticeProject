using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LINQTest015_Take_Skip_While
{
    class Program
    {
        static void Main(string[] args)
        {
            IList<string> strList = new List<string>() {
                "Thre1",
                "Four",
                "Five",
                "Hundred"  };

            /*
             *从第一个开始， 搜索字符串长度大于4的
             */
            var result = strList.TakeWhile(s => s.Length > 4);

            foreach (string str in result)
                Console.WriteLine(str);

            Console.WriteLine("======================");

            /*
             * 从第一个字符串长度大于4的字符开始计算
             */
            var result2 = strList.SkipWhile(s => s.Length > 4);
            foreach (string str in result2)
                Console.WriteLine(str);
        }
    }
}
