using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data;

namespace LINQTest019_DeferredExecution
{
    public static class EnumerableExtensionMethods
    {
        public static IEnumerable<Student> GetTeenAgerStudents(this IEnumerable<Student> source)
        { 
            foreach (Student std in source)
            {
                Console.WriteLine("Accessing student {0}", std.StudentName);

                if (std.age > 12 && std.age < 20)
                    yield return std;
            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            IList<Student> studentList = new List<Student>() {
                new Student() { StudentID = 1, StudentName = "John", age = 13 } ,
                new Student() { StudentID = 2, StudentName = "Steve",  age = 15 } ,
                new Student() { StudentID = 3, StudentName = "Bill",  age = 18 } ,
                new Student() { StudentID = 4, StudentName = "Ram" , age = 12 } ,
                new Student() { StudentID = 5, StudentName = "Ron" , age = 21 }
            };

            var teenAgerStudents = from s in studentList.GetTeenAgerStudents()
                select s;


            foreach (Student teenStudent in teenAgerStudents)
                Console.WriteLine("Student Name: {0}", teenStudent.StudentName);
        }
    }
}
