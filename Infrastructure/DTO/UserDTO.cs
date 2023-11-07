using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.DTO
{
    public class UserDTO
    {
        public int userId { get; private set; }
        public string userName { get; private set; }
        public string password { get; private set; }

        public UserDTO(int userId, string userName, string password)
        {
            this.userId = userId;
            this.userName = userName;
            this.password = password;
        }

        public UserDTO(string userName, string password)
        {
            this.userName = userName;
        }

        public UserDTO(int id)
        {
            this.userId = id;
        }
    }
}
