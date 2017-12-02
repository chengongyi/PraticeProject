using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IOC_006_Method
{
    class Program
    {
        static void Main(string[] args)
        {
            var service = new CustomerService();
            var name = service.GetName(45);
            Console.WriteLine(name);
        }
    }

    public class CustomerService
    {
        CustomerLogic _logic;
        public CustomerService()
        {
            _logic = new CustomerLogic();
            _logic.SetDependency(new DataAccess());
        }

        public string GetName(int id)
        {
            return _logic.GetName(id);
        }
    }


    public interface IDataAccessDependency
    {
        void SetDependency(IDataAccess dataAccess);
    }

    public class CustomerLogic : IDataAccessDependency
    {
        IDataAccess _dataAccess;
        public void SetDependency(IDataAccess dataAccess)
        {
            _dataAccess = dataAccess;
        }

        public string GetName(int id)
        {
            return _dataAccess.GetName(id);
        }
    }

    public interface IDataAccess
    {
        string GetName(int id);
    }

    public class DataAccess : IDataAccess
    {
        public string GetName(int id)
        {
            return "REX " + id;
        }
    }


}
