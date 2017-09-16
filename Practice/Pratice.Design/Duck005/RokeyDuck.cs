using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pratice.Design.Duck005
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
