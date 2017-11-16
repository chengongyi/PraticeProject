using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pratice.Design.Fight
{
    public class DemoTest
    {
        public static void Run()
        {
            Character character1 = new King("King",200);
            Character character2 = new Queen("Queen",200);

            character1.Fight();
            character1.SetWeapon(new AxeBehavior());
            character1.Fight();
            character1.SetWeapon(new KnifeBehavior());
            character1.Fight();
            character2.Fight();
        }
    }
}
