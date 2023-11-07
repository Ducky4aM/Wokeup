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
        public string name {  get; private set; }

        public int id { get; private set; }

        private List<Song> songs = new List<Song>();

        public FavoriteList(string name)
        {
            this.name = name;
        }

        public FavoriteList(int id, string name) 
        {
            this.name = name;
            this.id = id;
        }

        public IReadOnlyList<Song> GetSongs() {
            return this.songs.AsReadOnly();
        }

        internal bool AddSongToFavoriteList(Song song)
        {
            if (this.songs.Any(songCheck => songCheck.id == song.id))
            {
                return false; 
            }

            this.songs.Add(song);

            return true;
        }

        internal void RemoveSong(Song song)
        {
            if (this.songs.Contains(song))
            {
                this.songs.Remove(song);
            }
        }

        public override string ToString()
        {
            return this.name;
        }
    }
}
