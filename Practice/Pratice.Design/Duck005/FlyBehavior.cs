using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pratice.Design.Duck005
{
    public abstract class FlyBehavior
    {
        public abstract void Fly();
    }

    public  class  FlyWithWings:FlyBehavior
    {
        public override void Fly()
        {
            Console.WriteLine("用翅膀在飞");
        }
    }

    public  class FlyWithRocketPorwer:FlyBehavior
    {
        public override void Fly()
        {
            Console.WriteLine("用火箭在飞");
        }
    }

    public  class  FlyNoWay:FlyBehavior
    {
        public override void Fly()
        {
            Console.WriteLine("飞不了");
        }
    }
}
