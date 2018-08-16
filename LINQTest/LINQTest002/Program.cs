using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LINQTest002
{
    class Program
    {
        static void Main(string[] args)
        {
            IList<Student> studentList = new List<Student>() {

        new Student() { StudentID = 1, StudentName = "John", Age = 13 } ,
        new Student() { StudentID = 2, StudentName = "Moin", Age = 21 } ,
        new Student() { StudentID = 3, StudentName = "Bill", Age = 18 } ,
        new Student() { StudentID = 4, StudentName = "Ram", Age = 20 } ,
        new Student() { StudentID = 5, StudentName = "Ron", Age = 15 }
     };


            Func<Student, bool> isStudentTeenAger = s => s.Age < 20;

            //Func delegate in LINQ Method Syntax
            var t1 = studentList.Where(isStudentTeenAger).ToList();

            //Func delegate in LINQ Query Syntax
            var t2 = from s in studentList
                     where isStudentTeenAger(s)
                     select s;

            var t3 = from s in studentList where s.Age > 20 select s;


        }
    }
}
