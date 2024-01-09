using Domain;
using Domain.Interface;
using Domain.Service.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTest.Mock
{
    public class SongServiceMock : ISongService
    {
        private readonly List<Song> songs;

        public SongServiceMock()
        {
        }

        public SongServiceMock(List<Song> songs)
        {
            this.songs = songs;
        }

        public IReadOnlyList<Song> GetAllSongs()
        {
            return this.songs;
        }

        public IReadOnlyList<Song> GetSongsBaseOnGenre(Genre genre)
        {
            throw new NotImplementedException();
        }

        public IReadOnlyList<Song> GetSongsFromFavoriteList(IFavoriteList favoriteList)
        {
            throw new NotImplementedException();
        }
    }
}
