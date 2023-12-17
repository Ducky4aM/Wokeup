using Infrastructure.DTO;

namespace Infrastructure.Interface
{
    public interface IUserRepository
    {
        void CreateNewUser(UserDTO userDto);
        UserDTO? FindUser(UserDTO userDto);
        bool SetUserPreferGenre(UserDTO userDto, GenreDTO genreDto);
    }
}