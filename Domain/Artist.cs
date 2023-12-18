using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class Artist
    {
        public string name { get; private set; }

        private List<Genre> genres = new List<Genre>();

        public Artist(string name)
        {
            if (string.IsNullOrEmpty(name) == true)
            {
                throw new ArgumentException("Artist name can't be null or empty");
            }

            this.name = name;
        }

        public IReadOnlyList<Genre> GetGenres()
        {
            return this.genres.AsReadOnly();
        }
    }
}
