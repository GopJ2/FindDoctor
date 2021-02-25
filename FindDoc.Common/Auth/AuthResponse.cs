using System;
using FindDoc.Common.Dtos.UserDto;

namespace FindDoc.Common.Auth
{
    public class AuthResponse
    {
        public int Status { get; set; }

        public string Message { get; set; }

        public UserDto User { get; set; }

        public string Token { get; set; }

        public DateTime? Expiration { get; set; }
    }
}
