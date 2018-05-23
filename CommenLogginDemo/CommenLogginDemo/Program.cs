using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common.Logging; 

namespace CommenLogginDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            ILog log = LogManager.GetLogger("mylogger");
 

            Parallel.For(0, 100, (i, loopState) =>
            {
                if (i >= 10)
                    loopState.Break();
                log.Debug(i);
            });


        }
    }
}
