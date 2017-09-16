using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pratice.Design.Duck004
{
    public class RedDuck : Duck,IFly, IQuack
    {
        public void Fly()
        {
            throw new NotImplementedException();
        }

        public void Quack()
        {
            throw new NotImplementedException();
        }

        public override void Display()
        {
            throw new NotImplementedException();
        }

        public override void Swim()
        {
            throw new NotImplementedException();
        }
    }
}
