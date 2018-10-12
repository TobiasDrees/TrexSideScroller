using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sidescroller
{
    public class User
    {
        private int id;
        private String login;
        private String password;
        private String name;

        public User(int id, String login, String password, String name)
        {
            this.id = id;
            this.login = login;
            this.password = password;
            this.name = name;
        }

        public int getId()
        {
            return id;
        }

        public String getLogin()
        {
            return login;
        }

        public String getPassword()
        {
            return password;
        }

        public String getName()
        {
            return name;
        }
    }
}
