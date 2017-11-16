using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using Pratice.Design.Duck001;

namespace Pratice.Design.Duck001
{
    public abstract class Duck
    {
        public void quack()
        {
            Console.WriteLine("呱呱呱");
        }

        public void swim()
        {
            Console.WriteLine("游啊游");
        }

        /// <summary>
        /// 抽象方法：不能有实现的方法体，因为这里的动作或者行为都是抽象的，所以不具有实现方法
        /// </summary>
        public  abstract void Display();

        /// <summary>
        /// 虚拟方法：本身可以有实现，虚方法的目的是为了让子类去实现，如果子类不去实现，也可以使用父类的方法
        /// </summary>
        public virtual void VitrualDisplay()
        {
            Console.WriteLine("我是虚拟的方法");
        }


        /*
         小结：这里使用抽象
         */
    }

    public class GreenDuck : Duck
    {
        public override void Display()
        {
            Console.WriteLine("外观是绿头的鸭子....");
        }
    }

    public class RedDuck : Duck
    {
        public override void Display()
        {
            Console.WriteLine("外观是红头的鸭子");
        }
    }


    public class DuckDemo
    {
        public static void Run()
        {
            Duck duck1=new RedDuck();
            Duck duck2=new GreenDuck();

            duck1.swim();
            duck1.quack();
            duck1.Display();   
            duck2.swim();
            duck2.quack();
            duck2.Display();
         

        }
    }
}
