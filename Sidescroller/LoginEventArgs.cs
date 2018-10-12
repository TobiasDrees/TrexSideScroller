using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sidescroller
{
    class LoginEventArgs : EventArgs
    {
        public LoginEventArgs(User user)
        {
            User = user;
        }

        public User User { get; private set; }
    }
}
