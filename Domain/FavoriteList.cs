using Domain.Helper;
using Domain.Service;
using Infrastructure;
using Infrastructure.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class FavoriteList
    {
        public string name { get; private set; }

        public int id { get; private set; }

        private List<Song> songs = new List<Song>();

        public FavoriteList(string name)
        {
            this.name = this.GetValidName(name, new NullWhiteSpaceValidator());
        }

        public FavoriteList(int id, string name)
        {
            this.name = this.GetValidName(name, new NullWhiteSpaceValidator());

            this.id = id;
        }

        public IReadOnlyList<Song> GetSongs()
        {
            return this.songs.AsReadOnly();
        }

        public bool AddSongToFavoriteList(Song song)
        {
            if (this.songs.Any(songCheck => songCheck.id == song.id))
            {
                return false;
            }

            this.songs.Add(song);

            return true;
        }

        public bool RemoveSongInFavoriteList(Song song)
        {
            if (this.songs.Contains(song) == false)
            {
                return false;
            }

            this.songs.Remove(song);

            return true;
        }

        public override string ToString()
        {
            return this.name;
        }

        private string GetValidName(string name, IStringValidator validator)
        {
            if (validator.Validate(name) == false)
            {
                throw new Exception("Favorite list name not valid");
            }

            return name.Trim();
        }
    }
}
