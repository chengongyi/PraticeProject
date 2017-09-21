namespace Pratice.Design.Weather
{
    /// <summary>
    /// 观察者
    /// </summary>
    public interface IObserver
    {
        /*
         * 想要成为观察者，则必须实现这个接口，
         * 因为成为观察者，是需要条件的
         */
        void Update(float temp, float humidity, float pressure);
    }
}