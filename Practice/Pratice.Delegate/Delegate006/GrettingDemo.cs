using System;
using System.Globalization;

namespace Pratice.Delegate.Delegate006
{
    public delegate void PeopleGetting(string name);
    public class GrettingDemo
    { 
        public void Run()
        {
            PeopleGetting p = (name)=> Console.WriteLine("你好：" + name);
            p += (name)=> Console.WriteLine("hello"+name);
            p("tom");
        }
    }

    public class TestDemo006 
    {
        public static void Run()
        {
            new GrettingDemo().Run();
        }
    }
}
