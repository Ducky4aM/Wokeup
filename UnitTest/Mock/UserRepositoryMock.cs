using Infrastructure.DTO;
using Infrastructure.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTest.Mock
{
    public class UserRepositoryMock : IUserRepository
    {
        private bool isValid;

        public UserRepositoryMock()
        {
        }

        public UserRepositoryMock(bool isValid)
        {
            this.isValid = isValid;
        }

        public void CreateNewUser(UserDTO userDto)
        {
            throw new NotImplementedException();
        }

        public UserDTO? FindUser(UserDTO userDto)
        {
            throw new NotImplementedException();
        }

        public bool SetUserPreferGenre(UserDTO userDto, GenreDTO genreDto)
        {
            return isValid;
        }
    }
}
