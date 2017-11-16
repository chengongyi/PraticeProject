using System;

namespace Pratice.Design.Duck002
{
    public abstract class Duck
    {
        public abstract void Quack();

        public abstract void Swim();
         
        public  abstract void Display();

        public abstract void Fly();
    }

    public class GreenDuck : Duck
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

    public class RedDuck : Duck
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

    

    public class DuckDemo
    {
        public static void Run()
        {

        }
    }
}
