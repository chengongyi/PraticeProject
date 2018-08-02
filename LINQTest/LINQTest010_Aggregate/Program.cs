using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data;

namespace LINQTest010_Aggregate
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> strlist = new List<string>() { "One", "Two", "Three", "Four", "Five" };

            var str0 = strlist.Aggregate("Numbers:",(s1, s2) => s1 + "," + s2);

            Console.WriteLine(str0);
        
            Console.WriteLine("============================");
            
            IList<Student> studentList = new List<Student> () {
                new Student() { StudentID = 1, StudentName = "John", Age = 13 } ,
                new Student() { StudentID = 2, StudentName = "Moin", Age = 21 } ,
                new Student() { StudentID = 3, StudentName = "Bill", Age = 18 } ,
                new Student() { StudentID = 4, StudentName = "Ram", Age = 20 } ,
                new Student() { StudentID = 5, StudentName = "Ron", Age = 15 }
            };

            string str1 = studentList.Aggregate(
                "student's name:",
                (str, s)=>str+=s.StudentName+","
                );

            Console.WriteLine(str1);



            Console.WriteLine("============================");

            string str2 = studentList.Aggregate(
                "student's name:",  // seed value
                (str, s) => str += s.StudentName + ",",  // returns result using seed value, String.Empty goes to lambda expression as str
                str =>str.Substring(0,str.Length-1) // result selector that removes last comma
            );

            Console.WriteLine(str2);
        }
    }
}
