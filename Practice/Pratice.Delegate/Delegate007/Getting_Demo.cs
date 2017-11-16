using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pratice.Delegate.Delegate007
{
    public interface IGretting
    {
        void SayGreting(string name);
    }

    public class EnglishGreeting : IGretting
    {
        public void SayGreting(string name)
        {
            Console.WriteLine("Hello：" + name);
        }
    }

    public  class  ChineseGreeting:IGretting
    {
        public void SayGreting(string name)
        {
            Console.WriteLine("你好：" + name);
        }
    }
 

      public  class TestDemo007
        {
          //这里使用了接口调用，使用了多态机制
          public static void Greeting(string name, IGretting makeGretting)
          {
              makeGretting.SayGreting(name);
          }
          public static void Run()
          {
              const string name = "tomy"; 
              Greeting(name,new ChineseGreeting());
              Greeting(name, new EnglishGreeting());
              Greeting(name, new EnglishGreeting());
          }
        }
}
