using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace EFTest_001
{
    class Program
    {
        static void Main(string[] args)
        {
            var getlist = Get();
            var result = getlist.Result;
            foreach (var student in result)
            {
                Console.WriteLine("{0},{1}",student.StudentId,student.StudentName);
            }  
        }

        private static void Add()
        {
            using (var studentDB = new SchoolDBEntities())
            {
                Random r = new Random();
                studentDB.Students.Add(new Student()
                {
                    StudentName = r.Next(0, 1000).ToString(),
                    RowVersion = r.Next(1, 10),
                    StandardId = r.Next(1, 10)
                });
                studentDB.SaveChanges();
            }
        }

        private static void Delete()
        {
            using (var studentDB = new SchoolDBEntities())
            {
                var deleteStudent = studentDB.Students.FirstOrDefault(a => a.StudentId == 1);
                studentDB.Students.Remove(deleteStudent);
                studentDB.SaveChanges();
            }
        }

        private static async Task Update()
        {
            try
            {
                using (var studentDB = new SchoolDBEntities())
                {
                    var student = await studentDB.Students.FirstOrDefaultAsync(o => o.StudentId == 4);

                    student.StudentName = "王五的门店";

                    await studentDB.SaveChangesAsync();
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        private static void Update1()
        {

            using (var studentDb = new SchoolDBEntities())
            {
                var student = studentDb.Students.FirstOrDefault(o => o.StudentId == 2);

                student.StudentName = "张三的门店";

                studentDb.SaveChanges();
            }

        }

        private static async Task<List<Student>> Get()
        {
            using (var studentDb = new SchoolDBEntities())
            {
                var q = from c in studentDb.Students
                        select c;

                return await q.ToListAsync();

                return await studentDb.Students.Skip(0).Take(10).ToListAsync();
            }

        }
    }
}

