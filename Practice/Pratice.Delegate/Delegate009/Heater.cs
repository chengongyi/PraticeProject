using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pratice.Delegate.Delegate009
{
    public class Heater
    {
        private int temperature;

        public void BoilWater()
        {
            for (int i = 0; i < 100; i++)
            {
                temperature = i;
                if (temperature > 95)
                {
                    MakeAlert(temperature);
                    ShowMsg(temperature);
                }
            }
        }

        private void MakeAlert(int parm)
        {
            Console.WriteLine(string.Format( "闹铃：水已经{0}度了",parm));
        }

        private void ShowMsg(int param)
        {
            Console.WriteLine("展示，水已经{0}度了",param);
        }
    }

    public class TestDemo009
    {
        public static void Run()
        {
            new Heater().BoilWater();
        }
    }
}
