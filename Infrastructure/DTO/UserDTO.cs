using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.DTO
{
    public class UserDTO
    {
        public string username { get; private set; }
        public string password { get; private set; }
        public int id { get; private set; }


        public UserDTO(string userName, string password)
        {
            this.username = userName;
            this.password = password;
        }


        public UserDTO(string userName, int id)
        {
            this.username = userName;
            this.id = id;
        }
    }
}
