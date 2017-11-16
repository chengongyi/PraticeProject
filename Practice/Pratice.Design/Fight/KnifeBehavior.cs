using System;

namespace Pratice.Design.Fight
{
    public class KnifeBehavior:IWeaponBehavior
    {
        public int AttackValue { get; set; }

        public KnifeBehavior()
        {
            AttackValue = 100;
        }

        public void UseWeapon()
        {
            Console.WriteLine("实现匕首刺杀");
        }
    }
}