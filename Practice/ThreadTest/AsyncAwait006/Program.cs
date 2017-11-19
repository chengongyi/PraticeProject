using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace AsyncAwait006
{
    class Program
    {
        static void Main(string[] args)
        {
            Stopwatch watch = new Stopwatch();
            watch.Start();
            var studentTask = GetStudentAsync(1);
            var orderTask = GetOrderAsync(1);
            var dressTask = GetDressAsync(1);

            var student = studentTask.Result;
            var order = orderTask.Result;
            var dress = dressTask.Result;

            watch.Stop();

            Console.WriteLine("学生{0}总共话费了{1}元，他穿着一件{2}的衣服,总耗时{3}",student.Name,order.SpendMoney,dress.ClothColor,watch.ElapsedMilliseconds);
        }


        static async Task<Student> GetStudentAsync(int id)
        {
            var student = await Task.Run(()=> {
                Thread.Sleep(5000);
                return new Student() {
                    Name = "小明"
                };
            });

            return student;
        }


        static async Task<Order> GetOrderAsync(int id)
        {
            var order = await Task.Run(() => {
                Thread.Sleep(5000);
                return new Order()
                {
                    SpendMoney = 1000
                };
            });

            return order;
        }

        static async Task<Dress> GetDressAsync(int id)
        {
            var order = await Task.Run(() => {
                Thread.Sleep(5000);
                return new Dress()
                {
                    ClothColor="黄色"
                };
            });

            return order;
        }

    }

    class Student
    {
        public  string Name { get; set; }
    }

    class Order
    {
        public decimal SpendMoney { get; set; }
    }

    class Dress
    {
        public string ClothColor { get; set; }
    }
}
