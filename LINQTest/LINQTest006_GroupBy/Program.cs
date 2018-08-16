using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data;

namespace LINQTest006_GroupBy
{
    class Program
    {
        static void Main(string[] args)
        {
            var result1 = from s in DataProvider.List
                group s by s.Age;

            result1 = DataProvider.List.GroupBy(o => o.Age);

            //仅仅支持在LINQ Method中  不支持 query syntax
            result1 = DataProvider.List.ToLookup(o => o.Age);


            foreach (var item in result1)
            {
                Console.WriteLine("key={0}",item.Key);

                foreach (var student in item)
                {
                    Console.WriteLine(student.Age+"   "+student.StudentName);
                }
            }
        }
    }
}
