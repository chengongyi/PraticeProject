using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using SwaggerUITest_001.Models;

namespace SwaggerUITest_001.Controllers
{
    [RoutePrefix("v0/home")]
    public class HomeController : ApiController
    {
        [Route("login")]
        public string Login(string username, string pwd)
        {
            return "success";
        }

        [AccessKey]
        [HttpGet]
        [Route("info/{id}")]
        public string GetUserInfo(int id)
        {
            return "tomy";
        }

        /// <summary>
        /// [upload]
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [Route("upload")]
        public object Upload()
        {
            HttpFileCollection files = HttpContext.Current.Request.Files;
            foreach (var key in files.AllKeys)
            {
                HttpPostedFile file = files[key];
                file.SaveAs(@"E:\upload");
            }
            return Ok(new
            {
                 Info="上传成功"
            });
        }
    }
}
