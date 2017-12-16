using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    public class Student
    {
        public int age;
        public int StudentID { get; set; }
        public string StudentName { get; set; }
        public int Age { get; set; }
    }

    public static class DataProvider
    {
        public static IList<Student> List = new List<Student>() {
        new Student() { StudentID = 1, StudentName = "John", Age = 13 } ,
        new Student() { StudentID = 2, StudentName = "Moin", Age = 21 } ,
        new Student() { StudentID = 3, StudentName = "Bill", Age = 13 } ,
        new Student() { StudentID = 4, StudentName = "Ram", Age = 20 } ,
        new Student() { StudentID = 5, StudentName = "Ron", Age = 15 },
        new Student() { StudentID = 6, StudentName = "Rex", Age = 15 }
     };
    }


}
