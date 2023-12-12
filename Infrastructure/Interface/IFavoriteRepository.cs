using Infrastructure.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Interface
{
    public interface IFavoriteRepository
    {
        IReadOnlyList<FavoriteListDTO> GetAllFavoriteListBaseOnUser(UserDTO userDto);

        bool AddNewFavoriteList(FavoriteListDTO favoriteListDto, UserDTO userDto);

        bool RemoveFavoriteList(FavoriteListDTO favoriteListDto);

        bool AddSongTofavorietList(SongDTO songDto, FavoriteListDTO favoriteListDto);

        bool RemoveSongInFavoriteList(SongDTO songDto, FavoriteListDTO favoriteListDto);
    }
}
