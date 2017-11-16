using System;

namespace Pratice.Design.Fight
{
    public class BowAndArrowBehavior:IWeaponBehavior
    {
        public int AttackValue { get; set; }

        public BowAndArrowBehavior()
        {
            this.AttackValue = 50;
        }

        public void UseWeapon()
        {
            Console.WriteLine("实现用弓箭射击");
        }
    }
}