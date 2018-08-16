using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IOC_005
{
    class Program
    {
        static void Main(string[] args)
        {
        }
    }

    /*
     * 包装之后的服务，通过属性注入，进行依赖倒置
     */
    public class NameService
    {
        Logic logic;
        public NameService()
        {
            logic = new Logic();
            logic.DataAccess = new DataAccess();
        }

        public string GetName(int id)
        {
            return logic.GetName(id);
        }
    }

    /*
     * 业务类
     */
    public class Logic
    {
        public string GetName(int id)
        {
            return DataAccess.GetName(id);
        }
        public IDataAccess DataAccess { get; set; }
    }

    /*
     * 服务的接口
     */
    public interface IDataAccess
    {
        string GetName(int id);
    }

    /*
     * 服务具体的实现类
     */
    public class DataAccess : IDataAccess
    {
        public string GetName(int id)
        {
            return "Rex "+id;
        }
    }
}
