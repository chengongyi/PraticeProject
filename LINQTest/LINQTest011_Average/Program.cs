using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LINQTest011_Average
{
    class Program
    {
        static void Main(string[] args)
        {
            IList<int> intList = new List<int> () { 10, 20, 30 };

            var avg = intList.Average();

            Console.WriteLine("Average: {0}", avg);
        }
    }
}
