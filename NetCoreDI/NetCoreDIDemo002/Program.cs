using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;

namespace NetCoreDIDemo002
{
    /*
     * 如何实现依赖注入？
     * 1.使用接口抽象化
     * 2.注册服务容器中的依赖关系 IServiceProvider
     * 3.将服务注入到使用它的类的构造函数中  框架负责创建依赖关系的实例，并在不再需要时对其进行处理。
     */
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
    }

    public interface IMyDepenDency
    {
        Task WriteMessage(string message);
    }

    public class MyDependency : IMyDepenDency
    {
        //这里是用了官方推荐的 Microsoft.Extensions.Logging 
        private readonly ILogger<MyDependency> _logger;

        public MyDependency(ILogger<MyDependency> logger)
        {
            _logger = logger;
        }

        public Task WriteMessage(string message)
        {
            _logger.LogInformation("MyDenpendece.WriteAsync {MESSAGE}", message);
            return Task.FromResult(0);
        }
    }
}
