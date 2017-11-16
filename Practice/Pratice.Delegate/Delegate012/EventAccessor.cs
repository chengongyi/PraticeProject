using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pratice.Delegate.Delegate012
{
    public delegate string GeneralEventHandler();

    public class Publisher
    {
        //私有委托变量
        private GeneralEventHandler numberChanged;

        //事件访问器
        public  event GeneralEventHandler NumberChanged
        {
            add { numberChanged = value; }
            remove { numberChanged -= value; }
        }

        public void DoSomething()
        {
            if (numberChanged != null)
            {
                string rtn = numberChanged();
                Console.WriteLine("return:{0}",rtn);
            }
        }
    }

    public class Subscriber1
    {
        public string OnNumberChanged()
        {
            Console.WriteLine("Subscriber1 执行了");
            return "Subscriber1";
        }
    }

    public class Subscriber2
    {
        public string OnNumberChanged()
        {
            Console.WriteLine("Subscriber2 执行了");
            return "Subscriber2";
        }
    }

    public class TestDemo012
    {
        public static void Run()
        {
            Publisher p=new Publisher();
            Subscriber1 subscriber1=new Subscriber1();
            Subscriber2 subscriber2=new Subscriber2();
            p.NumberChanged -= subscriber1.OnNumberChanged;
            p.NumberChanged += subscriber1.OnNumberChanged;
            p.NumberChanged -= subscriber1.OnNumberChanged;
            p.NumberChanged += subscriber2.OnNumberChanged;

            p.DoSomething();
        }
    }
}
