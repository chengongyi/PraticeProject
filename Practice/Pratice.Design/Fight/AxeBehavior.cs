using System;

namespace Pratice.Design.Fight
{
    public  class  AxeBehavior:IWeaponBehavior
    {
        public int AttackValue { get; set; }

        public AxeBehavior()
        {
            this.AttackValue = 90;
        }

        public void UseWeapon()
        {
            Console.WriteLine("实现用斧头砍");
        }
    }
}