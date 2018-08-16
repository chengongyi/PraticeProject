using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Practices.EnterpriseLibrary.PolicyInjection;
using Microsoft.Practices.Unity;
using Microsoft.Practices.Unity.InterceptionExtension;

namespace AOPDemo1
{
    class Program
    {
        static void Main(string[] args)
        {
            var oUserTest1 = new User() { Name = "test2222", PassWord = "yxj" };

            var oUserTest2 = new User() { Name = "test3333", PassWord = "yxj" };

            var oUser = UserOperation.GetInstance();

            oUser.Test(oUserTest1);

            oUser.Test2(oUserTest1, oUserTest2);
        }
    }

    public class User
    {
        public string Name { set; get; }
        public string PassWord { set; get; }
    }

    public class LogHandler : ICallHandler
    {
        public int Order { get; set; }
        public string LogInfo { set; get; }

        //这个方法就是拦截的方法，可以规定在执行方法之前和之后的拦截
        public IMethodReturn Invoke(IMethodInvocation input, GetNextHandlerDelegate getNext)
        {
            //1.执行方法之前的拦截
            Console.WriteLine("方法执行前拦截到了");

            //2.执行方法
            var messagereturn = getNext()(input, getNext);

            //3.执行方法之后的拦截
            Console.WriteLine("方法执行后拦截到了");

            return messagereturn;
        }
    }

    public class LogHandlerAttribute : HandlerAttribute
    {
        public string LogInfo { set; get; }
        public int Order { get; set; }
        public override ICallHandler CreateHandler(IUnityContainer container)
        {
            return new LogHandler() { Order = this.Order, LogInfo = this.LogInfo };
        }
    }

    public interface IUserOperation
    {
        void Test(User oUser);
        void Test2(User oUser, User oUser2);
    }

    public class UserOperation : MarshalByRefObject, IUserOperation
    {
        private static UserOperation oUserOpertion = null;
        public UserOperation()
        {
            //oUserOpertion = PolicyInjection.Create<UserOperation>();
        }

        //定义单例模式将PolicyInjection.Create<UserOperation>()产生的这个对象传出去，这样就避免了在调用处写这些东西
        public static UserOperation GetInstance()
        {
            return oUserOpertion ?? (oUserOpertion = PolicyInjection.Create<UserOperation>());
        }
        //调用属性也会拦截
        public string Name { set; get; }

        //[LogHandler]，在方法上面加这个特性，只对此方法拦截
        [LogHandler(LogInfo = "Test的日志为aaaaa")]
        public void Test(User oUser)
        {
            Console.WriteLine("Test方法执行了");
        }

        [LogHandler(LogInfo = "Test2的日志为bbbbb")]
        public void Test2(User oUser, User oUser2)
        {
            Console.WriteLine("Test2方法执行了");
        }
    }
}
