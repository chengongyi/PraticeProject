using System;

namespace Pratice.Design.Duck006
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
