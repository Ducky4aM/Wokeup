using Domain.Service;
using Infrastructure;
using Infrastructure.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Auth
{
    public class Authentication
    {
        UserRepository userRepository = new UserRepository();

        public AuthenicationResult AuthUser(string name, string password)
        {
            UserDTO userDto = new UserDTO(name, password);

            UserDTO? userData = userRepository.FindUser(userDto);

            if (userData == null)
            {
                return new AuthenicationResult { AuthenticationStatus = new ServiceStatusJob(false, "Error", $"User with {name} not found!") };
            }

            if (name != userData.userName && userData.password != password)
            {
                return new AuthenicationResult { AuthenticationStatus = new ServiceStatusJob(false, "Error", "Login failed. Invalid username or password!") };
            }

            return new AuthenicationResult { AuthenticatedUser = new User(userData.userName, userData.password) };

        }
    }
}
