using Domain.Interface;
using Domain.Service;
using Infrastructure;
using Infrastructure.DTO;
using Infrastructure.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Service.Auth
{
    public class AuthenticationService
    {
        private IUserRepository userRepository;

        public AuthenticationService(IUserRepository userRepository) 
        {
            this.userRepository = userRepository;
        }

        public AuthenticationResult AuthUser(IUser user)
        {
            try
            {
                UserDTO? InloggedUserDto = userRepository.FindUser(new UserDTO(user.name, user.password));

                if (InloggedUserDto == null)
                {
                    return new AuthenticationResult { AuthenticationStatus = ServiceStatusResult.Failure("Error", $"User with {user.name} not found!") };
                }

                if (user.name != InloggedUserDto.userName || InloggedUserDto.password != user.password)
                {
                    return new AuthenticationResult { AuthenticationStatus = ServiceStatusResult.Failure("Error", "Login failed. Invalid username or password!") };
                }

                if (InloggedUserDto.preferGenre == null)
                {
                    return new AuthenticationResult { AuthenticatedUser = new User(InloggedUserDto.userName) };
                }

                return new AuthenticationResult { AuthenticatedUser = new User(InloggedUserDto.userName, new Genre(InloggedUserDto.preferGenre.name))};
            }
            catch (Exception ex)
            {
                return new AuthenticationResult { AuthenticationStatus = ServiceStatusResult.Failure("Error", ex.Message) };
            }
        }

        public ServiceStatusResult createAccount(IUser user)
        {
            UserDTO userDto = new UserDTO(user.name, user.password);

            UserDTO? findUser = userRepository.FindUser(userDto);

            if (findUser != null)
            {
                return ServiceStatusResult.Failure("Info", "User already exist please try other name");
            }

            userRepository.CreateNewUser(userDto);

            return ServiceStatusResult.Success("Info", "Create account successful");
        }
    }
}
