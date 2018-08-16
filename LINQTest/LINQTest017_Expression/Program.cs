using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace LINQTest017_Expression
{
    class Program
    {
        static void Main(string[] args)
        {
            Func<Student, bool> isTeenAger = s => s.Age > 18;

            Expression<Func<Student, bool>> isTeenExpress = s => s.Age > 18;

            Expression<Action<Student>> printStudent = s => Console.WriteLine(s.StudentName);

            var student = new Student()
            {
                StudentID=1,
                Age =10,
                StudentName ="小明"
            };


            Console.WriteLine(isTeenAger(student));

            Console.WriteLine(isTeenExpress.Compile()(student));

            printStudent.Compile()(student);
        }
    }

    public class Student
    {
        public int StudentID { get; set; }
        public string StudentName { get; set; }
        public int Age { get; set; }
    }
}
