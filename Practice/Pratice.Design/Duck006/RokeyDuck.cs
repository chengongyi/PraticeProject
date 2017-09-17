using System;

namespace Pratice.Design.Duck006
{
    public class RokeyDuck:Duck
    {
        public RokeyDuck()
        {
            FlyBehavior=new FlyWithRocketPorwer();
        }
        public override void Swim()
        {
            throw new NotImplementedException();
        }

        public override void Display()
        {
            throw new NotImplementedException();
        }

        public void IWantFly()
        {
            FlyBehavior.Fly();
        }
    }
}
