using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class User
    {
        public string name { get; private set; }

        private string password;

        public User(string name, string password)
        {
            this.name = name;
            this.password = password;
        }

    }
}
