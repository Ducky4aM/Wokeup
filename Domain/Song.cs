using Domain.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class Song
    {
        public string name { get; private set; }

        public int listened { get; private set; }

        public string image { get; private set; }

        public Genre genre { get; private set; }

        public Artist artist { get; private set; }

        public DateTime releaseAt { get; private set; }

        public Song(string name, string image, int listened, Genre genre, Artist artist, DateTime releaseAt)
        {
            this.name = name;
            this.image = image;
            this.listened = listened;
            this.genre = genre;
            this.artist = artist;
            this.releaseAt = releaseAt;
        }

        public Song(string name)
        {
            this.name = name;
        }

        public override string ToString()
        {
            return this.name;
        }
    }
}
