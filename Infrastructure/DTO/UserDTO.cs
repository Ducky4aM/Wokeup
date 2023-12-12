using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.DTO
{
    public class UserDTO
    {
        public string userName { get; private set; }
        public string password { get; private set; }
        public GenreDTO preferGenre { get; private set; }

        public UserDTO(string userName, string password, GenreDTO genreDto)
        {
            this.userName = userName;
            this.password = password;
            this.preferGenre = genreDto;
        }

        public UserDTO(string userName, string password)
        {
            this.userName = userName;
            this.password = password;
        }

        public UserDTO(string name)
        {
            this.userName = name;
        }
    }
}
