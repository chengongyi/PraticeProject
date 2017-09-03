using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pratice.Delegate.Delegate004
{
    public delegate void GreetingHandler(string name);

    public class Getting
    {
        public static void EnglishGreeting(string name)
        {
            Console.WriteLine("Hello："+name);
        }

        public static void ChineseGreeting(string name)
        {
            Console.WriteLine( "你好："+name);
        }

        public static void GettingPeople(string name,GreetingHandler gettingHandler)
        {
            gettingHandler(name);
        }

      
    }

      public  class TestDemo004 
        {
          public void Run()
          {
              var name = "tomy";
              Getting.GettingPeople(name, Getting.ChineseGreeting);
              Getting.GettingPeople(name, Getting.EnglishGreeting);
          }
        }
}
