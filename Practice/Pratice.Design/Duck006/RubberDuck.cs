using System;

namespace Pratice.Design.Duck006
{
    public class RubberDuck:Duck
    {
        public RubberDuck()
        {
            FlyBehavior=new FlyNoWay();
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
