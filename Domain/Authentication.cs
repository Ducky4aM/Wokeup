using Infrastructure;
using Infrastructure.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class Authentication
    {
        UserRepository userRepository = new UserRepository();

        public User? AuthUser(User user)
        {
            UserDTO? userDto = new UserDTO(user.name, user.password);

            userDto = userRepository.AuthUser(userDto);

            if (userDto == null)
            {
                return null;
            }

            return new User(userDto.username, userDto.id);
        }
    }
}
