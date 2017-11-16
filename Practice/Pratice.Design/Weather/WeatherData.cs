using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pratice.Design.Weather
{
    public class WeatherData:ISubject
    {
        private readonly List<IObserver> observers;
        private float temperature;
        private float humidity;
        private float pressure;

        public WeatherData()
        {
            observers=new List<IObserver>();
        }

        public void Register(IObserver o)
        {
            observers.Add(o);
        }

        public void Remove(IObserver o)
        {
            observers.Remove(o);
        }

        public void Notify()
        {
            foreach (var observer in observers)
            {
                    observer.Update(temperature,humidity,pressure);
            }
        }

        public void MeasurementsChanged()
        {
            Notify();
        }

        public void SetMeasurements(float temperature, float humidity, float pressure)
        {
            this.temperature = temperature;
            this.humidity = humidity;
            this.pressure = pressure;

            MeasurementsChanged();
        }
    }
}
