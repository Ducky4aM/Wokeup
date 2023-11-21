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
    public class AuthenticationService
    {
        UserRepository userRepository = new UserRepository();

        public AuthenticationResult AuthUser(string name, string password)
        {
            try
            {
                UserDTO? InloggedUserDto = userRepository.FindUser(new UserDTO(name, password));

                if (InloggedUserDto == null)
                {
                    return new AuthenticationResult { AuthenticationStatus = ServiceStatusResult.Failure("Error", $"User with {name} not found!") };
                }

                if (name != InloggedUserDto.userName || InloggedUserDto.password != password)
                {
                    return new AuthenticationResult { AuthenticationStatus = ServiceStatusResult.Failure("Error", "Login failed. Invalid username or password!") };
                }

                return new AuthenticationResult { AuthenticatedUser = new User(InloggedUserDto.userId, InloggedUserDto.userName)};
            }
            catch (Exception ex)
            {
                return new AuthenticationResult { AuthenticationStatus = ServiceStatusResult.Failure("Error", ex.Message) };
            }
        }
    }
}
