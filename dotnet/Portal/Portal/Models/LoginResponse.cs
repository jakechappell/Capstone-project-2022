using System;

namespace Portal.Models
{
    public class LoginResponse
    {
        public string Jwt { get; set; }
        public int ExpiresIn { get; set; }
        public DateTime IssuedDatTime { get; set; }
        public DateTime ExpirationDateTime { get; set; }
    }
}
