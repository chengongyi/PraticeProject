using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IOC_001
{
    class Program
    {
        static void Main(string[] args)
        {
            CustomerLogic logic = new CustomerLogic();
            var name = logic.GetCustomerName(1);
            Console.WriteLine(name);
        }
    }

    /*
     * Attention
     * CustomerLogic depends on an concrete class ,DataAccess
     * 
     * 1. tightly coupled class
     * 2.logic has to include 
     * 3.logic create and manage the life time of DataAccess
     * 
     * in the SRP ,we know a class shoun't has too much responsebility,
     * in this class, logic use a class and has to manage it,is not correct
     */
    public class CustomerLogic
    {
        DataAccess dataAccess;
        public CustomerLogic()
        {
            dataAccess = new DataAccess();
        }

        public string GetCustomerName(int id)
        {
            return dataAccess.GetCustomerName(id);
        }
    }

    public class DataAccess
    {
        public DataAccess()
        {

        }

        public string GetCustomerName(int id)
        {
            return "Rex";
        }
    }
}
