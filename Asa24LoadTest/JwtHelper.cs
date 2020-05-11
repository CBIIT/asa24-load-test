using System;
using System.Collections.Generic;
using System.Json;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using JWT;
using JWT.Serializers;

namespace JwtHelper
{

    public static class JwtHelper
    {
        private static readonly string AppSecret = "YmY4NmU5MWQtNWFlNS00ZWVhLTkxZTMtNzhkMTlhMjE1ZTY2";

        /// <summary>
        /// Decodes the specified token and extracts the field "User" from the token payload.
        /// </summary>
        /// <param name="token">Json web token.</param>
        /// <returns></returns>
        public static string GetUserNameFromToken(string token)
        {
            string userName = string.Empty;
            try
            {
                IJsonSerializer serializer = new JsonNetSerializer();
                IDateTimeProvider provider = new UtcDateTimeProvider();
                IJwtValidator validator = new JwtValidator(serializer, provider);
                IBase64UrlEncoder urlEncoder = new JwtBase64UrlEncoder();
                IJwtDecoder decoder = new JwtDecoder(serializer, validator, urlEncoder);

                string payloadJson = decoder.Decode(token, AppSecret, verify: false);

                JsonObject payload = JsonObject.Parse(payloadJson) as JsonObject;

                userName = payload["user"];
                
            }
            catch (Exception e)
            {
                /**
                 * JWT.SignatureVerificationException - Exception from decoding a bad token.
                 * ArgumentException - jwt is not well-formed.
                 * 
                 */
            }

            return userName;
        }
    }
}
