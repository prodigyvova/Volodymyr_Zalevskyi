using System;
using System.Collections.Generic;
using System.Text;

namespace WebUI.Entities
{
    class UserStorage
    {
        private string username;
        private string password;

        public string Username { get { return username; } set { username = value; } }
        public string Password { get { return password; } set { password = value; } }

        public UserStorage(string username, string password)
        {
            this.username = username;
            this.password = password;
        }
    }
}
