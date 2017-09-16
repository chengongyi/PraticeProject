using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pratice.Design.Duck005
{
     
    public abstract class Duck
    {
        /// <summary>
        /// 这里引入了一个飞行的行为，这样一来，每次飞行行为的变动，就不会影响到其他的稳定类中，把这部分抽出去，让其自由发展
        /// </summary>
        public FlyBehavior FlyBehavior;
        public abstract  void Swim();

        public abstract void Display();

        public void PerformFly()
        {
            FlyBehavior.Fly();
        }
    }
}
