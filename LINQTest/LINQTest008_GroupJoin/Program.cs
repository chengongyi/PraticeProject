using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LINQTest008_GroupJoin
{
    class Program
    {
        static void Main(string[] args)
        {
            IList<Student> studentList = new List<Student>() {
                new Student() { StudentID = 1, StudentName = "Student1", StandardID =1 },
                new Student() { StudentID = 2, StudentName = "Student2", StandardID =2 },
                new Student() { StudentID = 3, StudentName = "Student3", StandardID =2 },
                new Student() { StudentID = 4, StudentName = "Student4" , StandardID =4 },
                new Student() { StudentID = 5, StudentName = "Student5"  }
            };

            IList<Standard> standardList = new List<Standard>() {
                new Standard(){ StandardID = 1, StandardName="Standard 1"},
                new Standard(){ StandardID = 2, StandardName="Standard 2"},
                new Standard(){ StandardID = 3, StandardName="Standard 3"}
            };


            //使用Standard 来对StudentList进行分组

            //standardList left join studentList

            var groupjoin = standardList.GroupJoin(studentList, //inner sequence
                std => std.StandardID, //outerkeySelector
                stu => stu.StandardID, //innerkey Selector
                (std, studentGroup) => new
                {
                     Students=studentGroup,
                     Name=std.StandardName,
                }
            );

            foreach (var item in groupjoin)
            {
                Console.WriteLine(item.Name);
                foreach (var student in item.Students)
                {
                    Console.WriteLine("    "+ student.StudentName);
                }
            }
            Console.WriteLine("===========================");

            var groupjoin2 = studentList.GroupJoin(standardList,
                stu => stu.StandardID,
                sta => sta.StandardID,
                (stu, stagroup) => new
                {
                    StuName=stu.StudentName,
                    StanGroup=stagroup
                }
            );

            foreach (var item in groupjoin2)
            {
                Console.WriteLine(item.StuName);
                foreach (var standard in item.StanGroup)
                {
                    Console.WriteLine("{0},{1}",standard.StandardID,standard.StandardName);
                }
            }


            Console.WriteLine("===========================================");


            var groupjoin3 = from std in standardList
                join stu in studentList
                    on std.StandardID equals stu.StandardID
                    into studentGroup
                select new
                {
                    StandardName = std.StandardName,
                    Students = studentGroup
                };

            foreach (var item in groupjoin3)
            {
                Console.WriteLine(item.StandardName);
                foreach (var student in item.Students)
                {
                    Console.WriteLine("    "+student.StudentName);
                }
            }
        }
    }

    public class Student
    {
        public int StudentID { get; set; }
        public string StudentName { get; set; }
        public int StandardID { get; set; }
    }

    public class Standard
    {
        public int StandardID { get; set; }
        public string StandardName { get; set; }
    }
}
