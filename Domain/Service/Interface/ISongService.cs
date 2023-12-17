using Domain.Interface;

namespace Domain.Service.Interface
{
    public interface ISongService
    {
        IReadOnlyList<Song> GetAllSongs();
        IReadOnlyList<Song> GetSongsBaseOnGenre(Genre genre);
        IReadOnlyList<Song> GetSongsFromFavoriteList(IFavoriteList favoriteList);
    }
}