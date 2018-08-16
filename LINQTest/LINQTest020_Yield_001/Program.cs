using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace LINQTest020_Yield_001
{
    public class Persons : System.Collections.IEnumerable
    {
        public IEnumerator GetEnumerator()
        {
            yield return "1";
            Thread.Sleep(1000);
            yield return "2";
            Thread.Sleep(1000);
            yield return "3";
            Thread.Sleep(1000);
            yield return "4";
            Thread.Sleep(1000);
            yield return "5";
            Thread.Sleep(1000);
            yield return "6";
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Persons arrPersons = new Persons();

            foreach (string s in arrPersons)
            {
                System.Console.WriteLine(s);
            }

            System.Console.ReadLine();
        }
    }
}
