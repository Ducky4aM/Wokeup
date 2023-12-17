namespace Domain.Service.Interface
{
    public interface IUserService
    {
        List<Genre> getSuggestGenreForUser();
        bool IsUserHaveSongInFavoriteList();
        ServiceStatusResult setUserPreferGenre(Genre genre);
    }
}