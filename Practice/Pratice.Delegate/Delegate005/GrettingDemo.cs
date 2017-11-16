using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Pratice.Delegate.Delegate005
{
    public delegate void PeopleGetting(string name);
    public class GrettingDemo
    {
        public void ChineseHi(string name)
        {
            Console.WriteLine("你好，"+name);
        }

        public void EnglishHi(string name)
        {
            Console.WriteLine( "hello,"+name);
        }

        public void run()
        {
            PeopleGetting p = ChineseHi;
            p += EnglishHi;
            p("tom");

            p -= EnglishHi;
            p("tom"); 

        }
    }

    public class TestDemo005
    {
        public static void Run()
        {
            new GrettingDemo().run();
        }
    }
}
