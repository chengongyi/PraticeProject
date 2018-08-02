using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IOC_002
{
    /*
     *  patterns implements Ioc principle
     *  
     *  1.Service Locator
     *  2.Factory
     *  3.Abstract Factory
     *  4.Template Method
     *  5.Strategy
     *  6.Denpendency Injection
     */

    class Program
    {
        static void Main(string[] args)
        {
            var name = new CustomerLogic().GetCustomerName(1);
            Console.WriteLine(name);
        }
    }

    /*conclusion:
            * 
            * the most important things is !!!!!
            * 
            * we have inverted the control of creating an object of dependent class from
            * Logic class to Factory class
            */

    public class CustomerLogic
    {

        public CustomerLogic()
        {

        }

        public string GetCustomerName(int id)
        {
            //2. we use factory class  to get an object of dataAccess
              
            DataAccess dataAccess = DataAccessFoctory.GetDataAccessObj();

            return dataAccess.GetCustomerName(id);
        }
    }

    //1.we create a class :Factory

    public class DataAccessFoctory
    {
        public static DataAccess GetDataAccessObj()
        {
            return new DataAccess();
        }
    }

}
