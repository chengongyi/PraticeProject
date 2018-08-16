using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary1
{
    public class Class1
    {
    }

    public interface IMyService
    {
        void DoFunction();
    }

    public class MyService: IMyService
    {
        public void DoFunction()
        {
            Console.WriteLine("Hello");
        }
    }
}
