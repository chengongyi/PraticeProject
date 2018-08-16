using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IOC_004
{
    class Program
    {
        static void Main(string[] args)
        {
            var service = new CustomerService();
            var name=service.GetCustomerName(5);
            Console.WriteLine(name);
        }
    }


    /*
     * 这里其实是一个容器类，组合了服务需求方 和 服务提供方
     */
    public class CustomerService
    {
        CustomerBusinessLogic _customerBL;
        public CustomerService()
        {
            _customerBL = new CustomerBusinessLogic(new CustomerDataAccess());
        }
        public string GetCustomerName(int id)
        {
            return _customerBL.ProcessCustomerData(id);
        }
    }

    /*
     * 问题的核心就是这个方法，这个服务
     */
    public interface ICustomerDataAccess
    {
        string GetCustomerName(int id);
    }

    /*
     * 这里这个服务，调用了其他的方法，
     * 他不依赖于具体类，而是依赖于接口，
     * 因为他是这么想的，我不管你们谁来提供这个服务，只要有个人能够提供这个服务就可以了。
     * 所以，他就简单的依赖于这个接口
     */
    public class CustomerBusinessLogic
    {
        ICustomerDataAccess _dataAccess;

        public CustomerBusinessLogic(ICustomerDataAccess custDataAccess)
        {
            _dataAccess = custDataAccess;
        }

        public string ProcessCustomerData(int id)
        {
            return _dataAccess.GetCustomerName(id);
        }
    }

    /*
     * 这是一个实体类 被调用
     */
    public class CustomerDataAccess : ICustomerDataAccess
    {
        public string GetCustomerName(int id)
        {
            return "Rex Chen";
        }
    } 
}
