using Infrastructure.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Interface
{
    public interface ISongRepository
    {
        IReadOnlyList<SongDTO> GetAll();

        IReadOnlyList<SongDTO> GetSongFromFavoriteList(FavoriteListDTO favoriteListDto);

        IReadOnlyList<SongDTO> GetSongsBaseOnGenre(GenreDTO genreDto);
    }
}
