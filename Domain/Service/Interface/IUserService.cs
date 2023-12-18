namespace Domain.Service.Interface
{
    public interface IUserService
    {
        List<Genre> GetSuggestGenreForUser();
        bool IsUserHaveSongInFavoriteList();
        ServiceStatusResult SetUserPreferGenre(Genre genre);
    }
}