using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pratice.Delegate.Delegate001
{
    //场景：
    //夜深人静，屋里有老鼠蹑手蹑脚的行动，且随时提防着猫，如果听到猫叫，老鼠闻声立即逃回洞里

    public delegate void CryEventHandler();

    public class Cat
    {
        public static event CryEventHandler Cry;

        public Cat()
        {
            Console.WriteLine("猫咪:我来啦！！！");
        }

        public virtual void OnCry()
        {
            Console.WriteLine("猫咪:苗苗苗苗。。。。");
            if (Cry != null)
            {
                Cry();
            }
        }
    }

    public class Mouse
    {
        public Mouse()
        {
            Cat.Cry += new CryEventHandler(Run);
            Console.WriteLine("老鼠：我正在偷东西吃，希望别被发现才行啊。。。");
        }

        public void Run()
        {
            Console.WriteLine("老鼠:猫来啦，我们快跑啊~~~~");
        }
    }

    public class DemoTest001
    {
        public static void Run()
        {
            Mouse moust=new Mouse();
            Cat cat=new Cat();
            cat.OnCry();
        }
    }
} 