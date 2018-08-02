using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LINQTest007_Join;

namespace LINQ009_Container
{
    class Program
    {
        static void Main(string[] args)
        {
            IList<Student> studentList = new List<Student>() {
                new Student() { StudentID = 1, StudentName = "John", Age = 18 } ,
                new Student() { StudentID = 2, StudentName = "Steve",  Age = 15 } ,
                new Student() { StudentID = 3, StudentName = "Bill",  Age = 25 } ,
                new Student() { StudentID = 4, StudentName = "Ram" , Age = 20 } ,
                new Student() { StudentID = 5, StudentName = "Ron" , Age = 19 }
            };

            Student std = new Student() { StudentID = 3, StudentName = "Bill" };
            bool result = studentList.Contains(std,new StudentComarer()); //returns false
            bool result1 = studentList.Contains(std); //returns false
            Console.WriteLine(result);
            Console.WriteLine(result1);
        }

        class StudentComarer : IEqualityComparer<Student>
        {
            public bool Equals(Student x, Student y)
            {
                return y != null && (x != null && x.StudentID == y.StudentID);
            }

            public int GetHashCode(Student obj)
            {
                return obj.GetHashCode();
            }
        }
    }
}
