using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sidescroller
{
    public class User
    {
        public int Id { get; private set; }
        public String Login { get; private set; }
        public String Password { get; private set; }
        public String Name { get; private set; }
        public int Money { get; set; }
        public List<int> BoughtUpgrades { get; set; }

        public User(int id, String login, String password, String name, int money)
        {
            this.Id = id;
            this.Login = login;
            this.Password = password;
            this.Name = name;
            this.Money = money;
        }
    }
}
