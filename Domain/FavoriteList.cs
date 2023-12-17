using Domain.CustomException;
using Domain.Helper;
using Domain.Interface;
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
    public class FavoriteList : IFavoriteList
    {
        public string name { get; private set; }

        private List<Song> songs = new List<Song>();

        public FavoriteList(string name, IStringValidator validator)
        {
            if (validator.Validate(name) == false)
            {
                throw new InvalidNameException("Invalid favorite list name");
            }

            this.name = name;
        }

        public FavoriteList(string name)
        {
            this.name = name;
        }

        public IReadOnlyList<Song> GetSongs()
        {
            return this.songs.AsReadOnly();
        }

        public bool AddSongToFavoriteList(Song song)
        {
            if (this.songs.Any(songCheck => songCheck.name == song.name))
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
    }
}
