using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pratice.Delegate.Delegate010
{
    public class TestDemo010
    {
        public static void Run()
        {
            Heater heater=new Heater();
            Alarm alarm=new Alarm();
            Display display=new Display();

            heater.BoilEvent += alarm.MakeAlert;
            heater.BoilEvent += display.ShowMsg;

            heater.BoilWater();
        }
    }
}
