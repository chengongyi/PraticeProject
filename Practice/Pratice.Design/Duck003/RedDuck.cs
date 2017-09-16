using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pratice.Design.Duck003
{
    public class RedDuck:Duck
    {
        public override void Quack()
        {
            throw new NotImplementedException();
        }

        public override void Swim()
        {
            throw new NotImplementedException();
        }

        public override void Display()
        {
            throw new NotImplementedException();
        }

        public override void Fly()
        {
            throw new NotImplementedException();
        }
    }
}
