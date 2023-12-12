namespace Domain.Interface
{
    public interface IFavoriteList
    {
        string name { get; }

        bool AddSongToFavoriteList(Song song);
        IReadOnlyList<Song> GetSongs();
        bool RemoveSongInFavoriteList(Song song);
        string ToString();
    }
}