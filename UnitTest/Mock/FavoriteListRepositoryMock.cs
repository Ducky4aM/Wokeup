using Infrastructure.DTO;
using Infrastructure.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTest.Mock
{
    public class FavoriteListRepositoryMock : IFavoriteRepository
    {
        private readonly bool isSuccess;
        private readonly List<FavoriteListDTO> favoriteList;

        public FavoriteListRepositoryMock() { }

        public FavoriteListRepositoryMock(bool isSuccess)
        {
            this.isSuccess = isSuccess;
        }

        public FavoriteListRepositoryMock(List<FavoriteListDTO> favoriteListDtos)
        {
            this.favoriteList = favoriteListDtos;
        }

        public bool AddNewFavoriteList(FavoriteListDTO favoriteListDto, UserDTO userDto)
        {
            return this.isSuccess;
        }

        public bool AddSongTofavorietList(SongDTO songDto, FavoriteListDTO favoriteListDto)
        {
            return this.isSuccess;
        }

        public IReadOnlyList<FavoriteListDTO> GetAllFavoriteListBaseOnUser(UserDTO userDto)
        {
            return this.favoriteList;
        }

        public bool RemoveFavoriteList(FavoriteListDTO favoriteListDto)
        {
            return this.isSuccess;
        }

        public bool RemoveSongInFavoriteList(SongDTO songDto, FavoriteListDTO favoriteListDto)
        {
            return this.isSuccess;
        }
    }
}
