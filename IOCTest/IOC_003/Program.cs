using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IOC_003
{
    /*
     * DIP Definition
     * 1.High-level modules should not depend on low-level modules. 
     *    Both should depend on abstraction.
     * 
     * 2.Abstractions should not depend on details.
     *    Details should depend on abstractions.
     */

    /*
    * why we create an object and manage the life time of it?
    * 
    * we just use it method!!!!!!
    * 
    * so ,we don't care what object we use ,we just care about the method
    * we use an interface instead it
    */
    class Program
    {
        static void Main(string[] args)
        {
        }
    }

    public class CustomerBusinessLogic
    {
        ICustomerDataAccess _custDataAccess;

        public CustomerBusinessLogic()
        {
            _custDataAccess = DataAccessFactory.GetCustomerDataAccessObj();
        }

        public string GetCustomerName(int id)
        {
            return _custDataAccess.GetCustomerName(id);
        }
    }

    public class DataAccessFactory
    {
        public static ICustomerDataAccess GetCustomerDataAccessObj()
        {
            return new CustomerDataAccess();
        }
    }

    public interface ICustomerDataAccess
    {
        string GetCustomerName(int id);
    }

    public class CustomerDataAccess : ICustomerDataAccess
    {
        public CustomerDataAccess()
        {
        }
        public string GetCustomerName(int id)
        {
            return "Dummy Customer Name";
        }
    }



}
