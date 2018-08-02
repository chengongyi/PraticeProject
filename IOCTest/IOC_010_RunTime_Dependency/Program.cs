using Microsoft.Practices.Unity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IOC_010_RunTime_Dependency
{
    class Program
    {
        static void Main(string[] args)
        {
            var container = new UnityContainer();

            /*
             * 动态的去设置属性
             * 
             * 注册时，指定一个属性名称，然后再把实例对象放进去
             */
            container.RegisterType<Driver>(new InjectionProperty("Car1", new BMW()));

            container.RegisterType<Driver>(new InjectionProperty("Car2", new Audi()));

            var dirver = container.Resolve<Driver>();
            dirver.RunCar();
        }
    }



    public interface ICar
    {
        void Run();
    }

    public class Audi : ICar
    {
        public void Run()
        {
            Console.WriteLine("AODI ");
        }
    }

    public class BMW : ICar
    {
        public void Run()
        {
            Console.WriteLine("BAOMA ");
        }
    }

    public class Driver
    {
        public Driver()
        {
        }
         
        public ICar Car1 { get; set; }

        public ICar Car2 { get; set; }

        public void RunCar()
        {
            if (Car1 != null)
            {
                Car1.Run();
            }

            if (Car2 != null)
            {
                Car2.Run();
            }
        }
    }

}
