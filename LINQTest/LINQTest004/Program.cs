using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LINQTest004
{
    class Program
    {
        /*
         * Use OfType operator to filter the above collection based on each element's type
         */
        static void Main(string[] args)
        {
            IList list = new ArrayList();
            list.Add(0);
            list.Add("one");
            list.Add("Tow");
            list.Add(new Student() { Age = 1 });

            //var result0 = from s in list
            //              where 1=1
            //              select s;

            var result = from s in list.OfType<Student>()
                         select s;

            var result1 = from s in list.OfType<string>()
                         select s;

            var result2 = list.OfType<string>();

            foreach (var item in result1)
            {
                Console.WriteLine(item);
            }
        }
    }
}
