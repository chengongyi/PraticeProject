using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pratice.Design.Weather
{
    /// <summary>
    /// 主题
    /// </summary>
    public interface ISubject
    {
        /*
         * 作为一个主题来讲，他就相当于一个报社一样。接受外界的订阅和取消订阅，
         * 并且自己更新状态后，通知这些观察者
         */

        void Register(IObserver o);
        void Remove(IObserver o);
        void Notify();
    }
}
