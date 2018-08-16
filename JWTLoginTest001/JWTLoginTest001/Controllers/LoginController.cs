using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Web.Http;
using JWTLoginTest001.Models;
using JWT;
using JWT.Algorithms;
using JWT.Serializers;

namespace JWTLoginTest001.Controllers
{
    public class LoginResult {
        public string UserName { get; set; }
        public string Password { get; set; }
    }

    public class LoginController : ApiController
    {
        public LoginResult Post([FromBody] LoginResult request)
        {
            LoginResult rs = new LoginResult();
            if (request.UserName == "admin" && request.Password == "123")
            {
                AuthInfo payload = new AuthInfo
                {
                    IsAdmin = true,
                    Roles = new List<string> {"admin", "owner"},
                    UserName = "admin"
                };

                const string secret = "GQDstcKsx0NHjPOuXOYg5MbeJ1XT0uFiwDVvVBrk";

                IJwtAlgorithm algorithm = new HMACSHA256Algorithm();
                IJsonSerializer serializer = new JsonNetSerializer();
                IBase64UrlEncoder urlEncoder = new JwtBase64UrlEncoder();
                IJwtEncoder encoder = new JwtEncoder(algorithm, serializer, urlEncoder);
                var token = encoder.Encode(payload, secret);

                return rs;
            }
            return rs;
        }
    }
}
