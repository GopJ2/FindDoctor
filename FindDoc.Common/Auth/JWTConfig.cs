using System;
using System.Text;
using Microsoft.IdentityModel.Tokens;

namespace FindDoc.Common.Auth
{
    public class JWTConfig
    {
        public string Secret { get; set; }
        public string Issuer { get; set; }
        public string Audience { get; set; }
        public double AccessTokenExpiration { get; set; }

        public SymmetricSecurityKey GetSymmetricSecurityKey(string secret)
        {
            return new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secret));
        }
    }
}
