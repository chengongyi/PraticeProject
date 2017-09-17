namespace Pratice.Design.Duck006
{
     
    public abstract class Duck
    {
        /// <summary>
        /// 这里引入了一个飞行的行为，这样一来，每次飞行行为的变动，就不会影响到其他的稳定类中，把这部分抽出去，让其自由发展
        /// </summary>
        public FlyBehavior FlyBehavior;
        public abstract  void Swim();

        public abstract void Display();

        /// <summary>
        /// 这里更进了一步，可以动态的设置行为，而不是在构造函数中指定
        /// </summary>
        /// <param name="flyBehavior"></param>
        public void SetFlyBehavior(FlyBehavior flyBehavior)
        {
            this.FlyBehavior = flyBehavior;
        }

        public void PerformFly()
        {
            FlyBehavior.Fly();
        }
    }
}
