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
            return songs; 
        }

        public bool AddSongToFavoriteList(Song song)
        {
            this.songs.Add(song);

            return true;
        }

        public override string ToString()
        {
            return this.name;
        }
    }
}
