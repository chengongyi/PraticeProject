using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pratice.Delegate.Delegate002
{
    //场景
    //假定有两种猫：
    //一种是笨猫，它更本就追不上老鼠，所以老鼠即使听到它的叫声也不会逃走
    //另一种猫就是能抓老鼠的猫了，让老鼠闻风丧胆
    //这时候老鼠听到猫叫就不会马上Run了，它要先判断来的猫是哪种猫，只有遇到的是厉害的猫时，老鼠才会跑


    //解决利器：所有基于EventArgs的类都负责在发送器和接收器之间来回传递事件的信息

    public delegate void CryEventHandler(object sender, CryEventArgs e);

    public class CryEventArgs : EventArgs
    {
        public string Description { get; set; }
    }

    public class Cat
    { 
        //想要发布事件 这个是必须的
        public static event CryEventHandler Cry;
        private string Description { get; set; }
        public Cat(string description)
        {
            this.Description = description;
            Console.WriteLine("Cat:"+this.Description+" 来啦");
        }
        public virtual void OnCry()
        {
            Console.WriteLine("猫咪：喵喵。。。。。");

            CryEventArgs e=new CryEventArgs();
            e.Description = this.Description;

            if (Cry != null)
            {
                Cry(this, e);
            }
        }
    }

    public class Mouse
    {
        public Mouse()
        {
            Cat.Cry +=Run;
        }

        private void Run(object sender, CryEventArgs e)
        {
            string catDescription = e.Description;
            if (catDescription == "笨猫")
            {
                Console.WriteLine("老鼠：一只笨猫，别鸟他");
            }
            else
            {
                Console.WriteLine( "老鼠：天哪，快跑啊==========");
            }
        }
    }

    public class DemoTest002
    {
        public static void Run()
        {
            Mouse mouse=new Mouse();
            Cat foolcat=new Cat("笨猫");
            foolcat.OnCry();
            Cat smarctCat=new Cat("剑客猫");
            smarctCat.OnCry();
        }
    }
}
