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

        public UserDTO(string userName) { 
            this.username = userName;
        }
    }
}
