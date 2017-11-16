using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pratice.Design.Duck005
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
