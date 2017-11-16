using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pratice.Delegate.Delegate010
{
    public class Heater
    {
        private int temperature;

        public delegate void BoilHandler(int param);

        public event BoilHandler BoilEvent;

        public void BoilWater() 
        {
            for (int i = 0; i < 100; i++)
            {
                temperature = i;
                if (temperature > 95)
                {
                    if (BoilEvent != null)
                    {
                        BoilEvent(temperature);
                    }
                }
            }
        }
    }
}
