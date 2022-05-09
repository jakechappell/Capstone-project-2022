using System;
using System.Collections.Generic;

#nullable disable

namespace Portal.Models
{
    public partial class Session
    {
        public int SessionId { get; set; }
        public string Username { get; set; }
        public string Token { get; set; }
        public string Password { get; set; }
    }
}
