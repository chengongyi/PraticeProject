using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pratice.Delegate.Delegate011
{
    public class BoiledEventArgs : EventArgs
    {
        public readonly int temperature;

        public BoiledEventArgs(int temperature)
        {
            this.temperature = temperature;
        }
    }

    public class Heater
    {
        private int temperature;
        public string type;
        public string area;

        //委托的类型名称为 EventHandler结尾
        public delegate void BoiledEventHandler(object sender, BoiledEventArgs e);

        //事件名称为委托名称去掉EventHandler
        public event BoiledEventHandler Boiled;

        //这里提供了继承重写，让子类可以拒绝对她的监视  --事件触发
        protected virtual void OnBoiled(BoiledEventArgs e)
        {
            BoiledEventHandler handler = Boiled;
            if (handler != null) handler(this, e);
        }

        public void BoilWater()
        {
            for (int i = 0; i < 100; i++)
            {
                temperature = i;
                if (temperature > 95)
                {
                    OnBoiled(new BoiledEventArgs(temperature));
                }
            }
        }
    }

    public class Alarm
    {
        public void MakeAlert(object sender, BoiledEventArgs e)
        {
            Heater heater = sender as Heater;
            Console.WriteLine( "Alarm: type={0},area={1}",heater.type,heater.area);
            Console.WriteLine( "Alarm:temperature={0}",e.temperature);
        }
    }

    public class TestDemo011
    {
        public static void Run()
        {
            Heater heater=new Heater();
            Alarm alarm=new Alarm();
            heater.Boiled += alarm.MakeAlert;
            heater.BoilWater();
        }
    }
}
