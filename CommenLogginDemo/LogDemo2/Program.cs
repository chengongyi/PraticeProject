using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common.Logging;

namespace LogDemo2
{
    class Program
    {
        static void Main(string[] args)
        {
            ILog log = LogManager.GetLogger("mylogger");
            Parallel.For(0, 100, (i, loopState) =>
            {
                if (i > 10)
                {
                    loopState.Break();
                    log.Debug($"异常数字{i}");
                }
                log.Debug($"正常数字{i}");
            });


            log.Debug("任务结束！！！");

        }
    }
}
