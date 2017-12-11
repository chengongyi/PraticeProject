using Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LINQTest003
{
    class Program
    {
        static void Main(string[] args)
        {
            var result = DataProvider.List.Where((s,i)=> {
                if (i % 2 == 0) return true;
                return false;
            });

            foreach (var item in result.ToList())
            {
                Console.WriteLine(item.StudentID);
            }
        }
    }
}
