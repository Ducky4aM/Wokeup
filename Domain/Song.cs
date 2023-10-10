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

        public Song(string name, string image, int listened)
        {
            this.name= name;
            this.image = image;
            this.listened = listened;
            //this.artist = artist;
            //this.genre = genre;
        }

        public override string ToString()
        {
            return this.name;
        }

    }
}
