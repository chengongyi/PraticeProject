using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pratice.Design.Duck005
{
    public class DuckDemo
    {
        public static void Run()
        {
            Duck duck1 = new RedDuck();
            Duck duck2 = new RubberDuck();
            Duck duck3 = new RokeyDuck();

            duck1.PerformFly();
            duck2.PerformFly();
            duck3.PerformFly();
        }
    }
}
