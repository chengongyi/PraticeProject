using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pratice.Delegate.Delegate008
{
    //这里定义了方法的类型，声明一个方法类型
    public delegate void GrettingHandler(string name);

    public class GreetingManager
    {
        //第一种方式：使用一个委托变量
        public GrettingHandler MakeGrettingWithDelegate;

        //第二种：使用事件，事件其实就是对委托的一次封装，让外界更好的去使用委托，
        public event GrettingHandler MakeGretting;

        public virtual void OnMakeDelegateGretting(string name)
        {
            MakeGrettingWithDelegate(name);
        }

        public virtual void OnMakeEventGretting(string name)
        {
            GrettingHandler handler = MakeGretting;
            if (handler != null) handler(name);
        }
    }
}
