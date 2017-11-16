using Nancy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HttpServer.SelfHost.Nancy
{
    public class HomeModule : NancyModule
    {
        public HomeModule()
        {
            Get["/"] = x => "Hello";

            Get["/login"] = x => { return "person name :" + Request.Query.name + " age : " + Request.Query.age; };

        }
    }
}
