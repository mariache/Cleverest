using Cleverest.Entities.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cleverest.Entities
{
    public class User
    {
        public string Id { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public string Role { get; set; }

        public User() { }

        public User(string login, string password)
        {

            Id = Guid.NewGuid().ToString();

            Login = login;
            Password = password;

        }
    }
}
