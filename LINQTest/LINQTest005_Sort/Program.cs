using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data;


namespace LINQTest005_Sort
{
    class Program
    {
        static void Main(string[] args)
        {
            var resul1 = from s in DataProvider.List
                         orderby s.StudentName
                         select s;

            var result2 = from s in DataProvider.List
                          orderby s.StudentID descending
                          select s;

            var result3 = DataProvider.List.OrderBy(o => o.StudentID);

            var result4 = DataProvider.List.OrderByDescending(o => o.StudentID);


            //多排序

            var reuslt5 = from s in DataProvider.List
                          orderby s.StudentID, s.Age
                          select s;

            var result6 = DataProvider.List.OrderBy(o => o.StudentID).ThenBy(o => o.Age).ThenBy(o => o.StudentName);


            var result7 = from s in DataProvider.List
                select new { s.StudentName,s.Age};

            var result7Item = result7.FirstOrDefault().Age;


        }
    }
}
