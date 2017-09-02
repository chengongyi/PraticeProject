using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pratice.Delegate.Delegate003
{
    public class CryEventArg : EventArgs
    {
        public string Name { get; set; }
    }

    public class Cat
    {
        public static event Action<object, CryEventArg> Cry;
        private string Name { get; set; }
        public Cat(string name)
        {
            this.Name = name;
            Console.WriteLine("猫咪：我来啦！！！");
        }

        public virtual void OnCry()
        {
            Console.WriteLine("猫咪：我是"+this.Name+"，喵喵~~~~~");
            //这里是监听事件，如果没有人注册的话，则不会触发这个事件
            if (Cry != null) 
            {
                var e=new CryEventArg();
                e.Name = this.Name;
                Cry(this, e);
            }
        }
    }

    public class Mouse
    {
        public Mouse()
        {
            Console.WriteLine("老鼠：月黑风高，我来偷东西吃~~~");
            Console.WriteLine("老鼠：但是还得小心哪，有猫在。");
            Cat.Cry += Run;

        }

        public void Run(object sender, CryEventArg e)
        {
            if (e.Name == "笨猫")
            {
                Console.WriteLine("老鼠：一只笨猫，别鸟他");
            }
            else
            {
                Console.WriteLine("老鼠：天哪，快跑啊==========");
            }
        }
    }

    public class DemoTest003
    {
        public static void Run()
        {
            Mouse mouse=new Mouse();
            Cat foolCat=new Cat("笨猫");
            foolCat.OnCry();
            Cat smarCat = new Cat("厉害的猫");
            smarCat.OnCry();
        }
    }
}
