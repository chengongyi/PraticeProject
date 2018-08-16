using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LINQTest007_Join
{
    class Program
    {
        /*
         * 
            Join query syntax: 
            from... in outerSequence
            join... in innerSequence 
            on outerKey equals innerKey
            select ...
         */
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

            //LINQ METHOD

            var innerJoin = studentList.Join(
                standardList,
                student => student.StandardID,
                standard => standard.StandardID,
                (student, stand) =>new 
                {
                    StudentName=student.StudentName,
                    StanderName=stand.StandardName
                }
            );


            //Query Syntax

            innerJoin = from stu in studentList //outer sequence
                join sta in standardList
                    on stu.StandardID equals sta.StandardID
                select new
                {
                    StudentName = stu.StudentName,
                    StanderName = sta.StandardName
                };

            foreach (var item in innerJoin)
            {
                Console.WriteLine(item.StudentName+"-"+item.StanderName);
            }
        }
    }

    public class Student
    {
        public int StudentID { get; set; }
        public string StudentName { get; set; }
        public int StandardID { get; set; }
        public int Age { get; set; }
    }

    public class Standard
    {
        public int StandardID { get; set; }
        public string StandardName { get; set; }
    }
}
