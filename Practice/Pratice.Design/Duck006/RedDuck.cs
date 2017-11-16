using System;

namespace Pratice.Design.Duck006
{
    public class RedDuck:Duck
    {
        public RedDuck()
        {
            FlyBehavior=new FlyWithWings();
        }
        public override void Swim()
        {
            throw new NotImplementedException();
        }

        public override void Display()
        {
            throw new NotImplementedException();
        }

        public void Fly()
        {
            FlyBehavior.Fly();
        }
    }
}
