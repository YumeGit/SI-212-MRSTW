using System;

namespace MRSTW.Domain
{
    public class UserLoginData
    {
        public string Email { get; set; }
        public string Password { get; set; }
        public string IpAddress { get; set; }
        public DateTime Time { get; set; }
    }
}
