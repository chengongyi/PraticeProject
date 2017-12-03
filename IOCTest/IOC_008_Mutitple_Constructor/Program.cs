using Microsoft.Practices.Unity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IOC_008_Mutitple_Constructor
{
    class Program
    {
        static void Main(string[] args)
        {
            var container = new UnityContainer();

            container.RegisterType<ICar, Audi>();

            container.RegisterType<IKey, AudiKey>();

            container.RegisterType<Driver>(new InjectionConstructor(new object[] {new Audi(),"Steve" }));

            var dirver = container.Resolve<Driver>();
            dirver.Show();
        }
    } 

    public class Driver
    {
        public ICar icar;
        public IKey ikey;
        public string DriverName;

        //[InjectionConstructor]
        public Driver(ICar car)
        {
            icar = car;
        }

        public Driver(ICar car, IKey key)
        {
            icar = car;
            ikey = key; 
        }

        public Driver(ICar car,string name)
        {
            icar = car;
            DriverName = name;
        }


        public void Show()
        {
            if (ikey == null)
            {
                Console.WriteLine(icar.GetType().Name+" "+DriverName);
                return;
            }
            Console.WriteLine(icar.GetType().Name+" "+ikey.GetType().Name);
        }
    }

    public interface ICar { }
    public class BM : ICar { }
    public class Audi : ICar { }


    public interface IKey { }
    public class BMKey : IKey { }
    public class AudiKey : IKey { }


}
