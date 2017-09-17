namespace Pratice.Design.Duck006
{
    public class DuckDemo
    {
        public static void Run()
        {
            Duck duck1 = new RedDuck();

            duck1.PerformFly();
            duck1.SetFlyBehavior(new FlyWithRocketPorwer());
            duck1.PerformFly();
            duck1.SetFlyBehavior(new FlyNoWay() );
            duck1.PerformFly();
            
            
        }
    }
}
