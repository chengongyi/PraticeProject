using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LINQTest014_Concat
{
    class Program
    {
        static void Main(string[] args)
        {
            IList<string> collection1 = new List<string>() { "One", "Two", "Three" };
            IList<string> collection2 = new List<string>() { "Five", "Six" };
            var result = collection1.Concat(collection2);
            foreach (var item in result)
            {
                Console.WriteLine(item);
            }
        }
    }
}
