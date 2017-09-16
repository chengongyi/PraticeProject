using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pratice.Design.Duck003
{
    /// <summary>
    /// 橡皮鸭
    /// </summary>
    public class RubberDuck:Duck
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
           //哑方法，不做任何的处理 

            //但是这里会有个问题，这是一只橡皮鸭，他本来就不能飞，这里还让他能够调用这个方法，这本身就是个错误！！！
        }
    }
}
