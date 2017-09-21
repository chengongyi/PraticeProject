using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pratice.Design.Weather
{
    /// <summary>
    /// 展示接口
    /// </summary>
    public interface IDisplayElement
    {
        /*
         * 这个接口就和业务有关联了，
         * 因为这里是未来扩展的地方，后面的新加入的公告版。
         */
        void Display();
    }
}
