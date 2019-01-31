using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace English_Learning_Application.Entity
{
    class User
    {
        private string name, username, password, role_id;

        public User(string name, string username, string password, string role_id)
        {
            this.name = name;
            this.username = username;
            this.password = password;
            this.role_id = role_id;
        }

        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        public string Username
        {
            get { return username; }
            set { username = value; }
        }

        public string Password
        {
            get { return password; }
            set { password = value; }
        }

        public string Role_id
        {
            get { return role_id; }
            set { role_id = value; }
        }

    }
}
