using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Web.Http;
using LoginWeb001.Models;
using LoginWeb001.Tools;

namespace LoginWeb001.Controllers
{
    public class LoginController : ApiController
    {
        public LoginResult Post([FromBody]LoginRequest request)
        {
            LoginResult rs = new LoginResult();
         
            if (request.UserName != "admin" || request.Password != "123")
            {
                rs.Success = false;
                rs.Message = "用户名或密码不正确";
                return rs;
            }
           
            var authInfo = new AuthInfo
            {
                IsAdmin = true,
                Roles = new List<string> {"admin", "owner"},
                UserName = "admin"
            };
            var token = TokenBuilder.CreateToken(authInfo);
            rs.Token = token;
            rs.Success = true;
            return rs;
        }
    }

    public class LoginRequest
    {
        public string UserName { get; set; }
        public string Password { get; set; }
    }

    public class LoginResult
    {
        public string Token { get; set; }
        public bool Success { get; set; }
        public string Message { get; set; }
    }
}
