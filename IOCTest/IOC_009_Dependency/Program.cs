using Microsoft.Practices.Unity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IOC_009_Dependency
{
    class Program
    {
        static void Main(string[] args)
        {
            var container = new UnityContainer();
            
            /*
             * 这里进行注册，适用于构造注入和属性注入
             */
            container.RegisterType<ICar, Audi>("AODI");

            /*
             * 在注册类型的时候，可以指定类型，这样可以方便指定特有的类型
             */
            container.RegisterType<ICar, BMW>("BAOMA");

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

        /*
         * 这里是属性注入，使用Dependency标注
         */
        [Dependency("BAOMA")]
        public ICar Car { get; set; }

        public void RunCar()
        {
            Car.Run();
        }
    }

}
