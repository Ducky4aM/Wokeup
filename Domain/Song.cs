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
        private int songId;
        private string songName;
        private int songListened;

        public int id { get; private set; }

        public string name { get; private set; }

        public int listened { get; private set; }

        public string image { get; private set; }

        public Genre genre { get; private set; }

        public Artist artist { get; private set; }

        public Song(int id, string name, string image, int listened, Genre genre, Artist artist)
        {
            this.id = id;

            if (this.nameValidator(name, new NullWhiteSpaceValidator()) == false)
            {
                throw new Exception("Song name not valid");
            }

            this.name = name.Trim();
            this.image = image;
            this.listened = listened;
            this.genre = genre;
            this.artist = artist;
        }

        public Song(int songId, string songName, int songListened, Genre genre, Artist artist)
        {
            this.songId = songId;
            this.songName = songName;
            this.songListened = songListened;
            this.genre = genre;
            this.artist = artist;
        }

        public override string ToString()
        {
            return this.name;
        }

        private bool nameValidator(string name, IStringValidator validator)
        {
            return validator.Validate(name);
        }
    }
}
