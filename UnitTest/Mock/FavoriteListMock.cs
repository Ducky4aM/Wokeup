using Domain;
using Domain.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTest.Mock
{
    public class FavoriteListMock : IFavoriteList
    {
        private readonly bool isValid;
        private List<Song> songs;

        public string name { get; set; }

        public FavoriteListMock()
        { 
        }

        public FavoriteListMock(List<Song> songs)
        {
            this.songs = songs;
        }

        public FavoriteListMock(string name,bool isValid)
        {
            this.name = name;
            this.isValid = isValid;
        }

        public FavoriteListMock(bool isValid) 
        {
            this.isValid = isValid;
        }

        public bool AddSongToFavoriteList(Song song)
        {
            return isValid;
        }

        public IReadOnlyList<Song> GetSongs()
        {
            return this.songs.AsReadOnly();
        }

        public bool RemoveSongInFavoriteList(Song song)
        {
            return isValid;
        }
    }
}
