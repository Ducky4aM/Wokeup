using Infrastructure.DTO;
using Infrastructure.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTest.Mock
{
    internal class SongRepositoryMock : ISongRepository
    {
        private List<SongDTO> songDtos = new List<SongDTO>();

        public SongRepositoryMock()
        {
        }

        public SongRepositoryMock(List<SongDTO> songDtos) 
        {
            this.songDtos = songDtos;
        }

        public IReadOnlyList<SongDTO> GetAll()
        {
            return this.songDtos.AsReadOnly();
        }

        public IReadOnlyList<SongDTO> GetSongFromFavoriteList(FavoriteListDTO favoriteListDto)
        {
            return this.songDtos.AsReadOnly();
        }

        public IReadOnlyList<SongDTO> GetSongsBaseOnGenre(GenreDTO genreDto)
        {
            return this.songDtos.AsReadOnly();
        }
    }
}
