using System;
using System.Threading.Tasks;

namespace NetCoreDIDemo001
{
    /*
     * 这个是没有使用依赖注入的例子
     */
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
    }
    public class  UseDemo
    {
        /*
         * 这样做其实是有问题的，因为如果要有不同的实现类，则必须修改类才行
         * 很难进行单元测试
         * 这个时候，得使用依赖注入才行了
         */
        MyDependency _dependency = new MyDependency();
        public async Task OnGetAsync()
        {
            await _dependency.WriteMessage("IndexModel.OnGetAsync created this message.");
        }
    }

    public class MyDependency
    {
        public MyDependency()
        {
        }

        public Task WriteMessage(string message)
        {
            Console.WriteLine(
                $"MyDependency.WriteMessage called. Message: {message}");

            return Task.FromResult(0);
        }
    }
}
