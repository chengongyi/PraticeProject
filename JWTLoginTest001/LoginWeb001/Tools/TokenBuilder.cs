using System;
using System.Collections.Generic;
using System.ComponentModel;
using JWT;
using JWT.Algorithms;
using JWT.Serializers;

namespace LoginWeb001.Tools
{
    public static class TokenBuilder
    {
        private static readonly string Secretkey;

        static TokenBuilder()
        {
            Secretkey = System.Configuration.ConfigurationManager.AppSettings["SecreKey"];
        }

        public static string CreateToken(object info, int expireSecond = 0)
        {
            return expireSecond == 0 ? EncodeInfo(info) : EncodeInfoWithTime(info, expireSecond);
        }

        public static JwtResponse ParseToken(string token)
        {
            try
            {
                var json = GetDecoder().Decode(token, Secretkey, true);
                return new JwtResponse
                {
                    UserInfo = json,
                    Desc = "Token is ok",
                    Status = (int)JwtResponse.TokenStatus.Success
                };
            }
            catch (TokenExpiredException)
            {
                return new JwtResponse
                {
                    Desc = "Token has expired",
                    Status = (int)JwtResponse.TokenStatus.Expired
                };
            }
            catch (SignatureVerificationException)
            {
                return new JwtResponse
                {
                    Desc = "Token has invalid signature",
                    Status = (int)JwtResponse.TokenStatus.Invalid
                };
            }
            catch (Exception)
            {
                return new JwtResponse
                {
                    Desc = "Token is error",
                    Status = (int)JwtResponse.TokenStatus.Error
                };
            }
        }

        private static string EncodeInfoWithTime(object info, int expireSecond)
        {
            IDateTimeProvider provider = new UtcDateTimeProvider();
            var now = provider.GetNow();
            now = now.AddSeconds(expireSecond);

            var unixEpoch = JwtValidator.UnixEpoch; // 1970-01-01 00:00:00 UTC
            var secondsSinceEpoch = Math.Round((now - unixEpoch).TotalSeconds);

            var payload = new Dictionary<string, object>
            {
                {"exp", secondsSinceEpoch},
                {"info", info}
            };

            var token = GetEncoder().Encode(payload, Secretkey);
            return token;
        }

        private static string EncodeInfo(object info)
        {
            var payload = new Dictionary<string, object>
            {
                {"info", info}
            };
            return GetEncoder().Encode(payload, Secretkey);
        }

        private static IJwtDecoder GetDecoder()
        {
            IJsonSerializer serializer = new JsonNetSerializer();
            IDateTimeProvider provider = new UtcDateTimeProvider();
            IJwtValidator validator = new JwtValidator(serializer, provider);
            IBase64UrlEncoder urlEncoder = new JwtBase64UrlEncoder();
            return new JwtDecoder(serializer, validator, urlEncoder);
        }

        private static IJwtEncoder GetEncoder()
        {
            IJwtAlgorithm algorithm = new HMACSHA256Algorithm();
            IJsonSerializer serializer = new JsonNetSerializer();
            IBase64UrlEncoder urlEncoder = new JwtBase64UrlEncoder();
            return new JwtEncoder(algorithm, serializer, urlEncoder);
        }

        public class JwtResponse
        {
            public int Status { get; set; }
            public string UserInfo { get; set; }
            public string Desc { get; set; }
            public enum TokenStatus
            {
                [Description("Token is ok")]
                Success = 0,
                [Description("Token has expired")]
                Expired = -1,
                [Description("Token has invalid signature")]
                Invalid = -2,
                [Description("Token is error")]
                Error = 3

            }
        }

    }
}