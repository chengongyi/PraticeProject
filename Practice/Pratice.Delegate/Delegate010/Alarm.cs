using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pratice.Delegate.Delegate010
{
    public class Alarm
    {
        public void MakeAlert(int parm)
        {
            Console.WriteLine(string.Format("闹铃：水已经{0}度了", parm));
        }
    }
}
