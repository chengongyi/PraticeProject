using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pratice.Delegate.Delegate008
{
    public class TestDemo008
    {
        public static void EnglishGretting(string name)
        {
            Console.WriteLine("hi,"+name);
        }
        public static void ChineseGretting(string name)
        {
            Console.WriteLine("你好," + name);
        }

        public static void Run()
        {

            //使用事件时：只能使用+= 或者-= 不需要关心第一次还是第二次进行赋值
            //对内部的委托机制进行了很好的封装
           var eventManager=new GreetingManager();
            //eventManager.MakeGretting = EnglishGretting; 报错语句
            eventManager.MakeGretting += EnglishGretting;
            eventManager.MakeGretting += ChineseGretting;
            eventManager.OnMakeEventGretting("tomey");

            //使用委托时：我们必须暴露委托这个属性，否则不能操作
            var delegateManagar = new GreetingManager();
            delegateManagar.MakeGrettingWithDelegate = null;
            delegateManagar.MakeGrettingWithDelegate = EnglishGretting;
            delegateManagar.MakeGrettingWithDelegate += ChineseGretting;
            delegateManagar.OnMakeDelegateGretting("mary");

        }
    }
}
