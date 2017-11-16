using System;

namespace Pratice.Design.Fight
{
    public  abstract  class Character
    {
        private string Name { get; set; }
        private int LifeValue { get; set; }

        protected Character(string name,int lifeValue)
        {
            this.Name = name;
            this.LifeValue = lifeValue;
        }

        private IWeaponBehavior _weapon;
   
        
        public void Fight()
        {
            Console.Write(Name+": ");
            _weapon.UseWeapon();
        }

        public void SetWeapon(IWeaponBehavior w)
        {
            this._weapon = w;
        }
    }

    public class King : Character
    {
        public King(string name, int lifeValue) : base(name, lifeValue)
        {
            SetWeapon(new BowAndArrowBehavior());
        }
    }

    public class Queen : Character
    {
        public Queen(string name, int lifeValue) : base(name, lifeValue)
        {
            SetWeapon(new KnifeBehavior());
        }
    }
     
}
