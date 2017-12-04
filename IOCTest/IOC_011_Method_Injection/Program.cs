using Microsoft.Practices.Unity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IOC_011_Method_Injection
{
    class Program
    {
        static void Main(string[] args)
        {
            var container = new UnityContainer();

            // container.RegisterType<IBall, FootBall>();

            container.RegisterType<Student>(new InjectionMethod("SetBall", new FootBall()));

            var student = container.Resolve<Student>();

            student.Play();
        }
    }

    public interface IBall { }
    public class BasketBall : IBall { }
    public class FootBall : IBall { }

    public class Student
    {
        public IBall MyBall;

        [InjectionMethod]
        public void SetBall(IBall ball)
        {
            MyBall = ball;
        }

        public void Play()
        {
            Console.WriteLine(MyBall.GetType().Name);
        }


    }
}
