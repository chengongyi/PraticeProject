using Microsoft.Practices.Unity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IOC_007_Unity
{
    class Program
    {
        static void Main(string[] args)
        {
            
        }

        private static void RegisterNamedType()
        {
            IUnityContainer container = new UnityContainer();
            container.RegisterType<ICar, BMW>();

            container.RegisterType<ICar, Audi>("LuxuryCar");

            //container.Resolve<ICar>(); --BMW

            //container.Resolve<ICar>("LuxuryCar");  --Audi


            container.RegisterType<Driver>("LuxuryCarDriver",
                new InjectionConstructor(container.Resolve<ICar>("LuxuryCar")));

            var driver1 = container.Resolve<Driver>();
            driver1.RunCar();
            driver1.RunCar();


            var driver2 = container.Resolve<Driver>("LuxuryCarDriver");
            driver2.RunCar();
            driver2.RunCar();
        }

        private static void MultipleRegistration()
        {
            IUnityContainer container = new UnityContainer();
            container.RegisterType<ICar, BMW>();

            container.RegisterType<ICar, Audi>();

            container.Resolve<Driver>().RunCar();
        }

        private static void BasicMethodToUseUnity()
        {
            IUnityContainer container = new UnityContainer();
            container.RegisterType<ICar, Audi>();

            /*
             * unity 使用Resolve 生成具指定的类，并且注入进去
             */
            Driver drv = container.Resolve<Driver>();
            drv.RunCar();
        }

        private static void OriginalMethod()
        {
            /*
                         * 这里有什么问题？
                         * 
                         * 我们手动的生成了一个车的实例，并且手动的把它注入了
                         */
            Driver driver = new Driver(new BMW());

            driver.RunCar();
        }
    }

    public interface ICar
    {
        int Run();
    }

    public class BMW : ICar
    {
        private int miles = 0;
        public int Run()
        {
            return ++miles;
        }
    }

    public class Ford : ICar
    {
        private int miles = 0;
        public int Run()
        {
            return ++miles;
        }
    }

    public class Audi : ICar
    {
        private int miles = 0;
        public int Run()
        {
            return ++miles;
        }
    }

    public class Driver
    {
        private ICar _car = null;
        public Driver(ICar car)
        {
            _car = car;
        }

        public void RunCar()
        {
            Console.WriteLine("Running {0} - {1} mile ", _car.GetType().Name, _car.Run());
        }
    }

}
