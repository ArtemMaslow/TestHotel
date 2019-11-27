using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TestHotel.Entities
{
    public class Users
    {
        public string Login { get; set; }
        public string Password { get; set; }

        public Users()
        {

        }

        public Users(string login, string password)
        {
            Login = login;
            Password = password;
        }
    }
}
