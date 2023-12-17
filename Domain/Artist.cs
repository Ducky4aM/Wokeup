using Domain.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class Artist
    {
        public int id { get; private set; }

        public string name { get; private set; }

        private List<Genre> genres = new List<Genre>();

        public Artist(string name)
        {
            this.name = name;
        }

        public IReadOnlyList<Genre> GetGenres()
        {
            return this.genres.AsReadOnly();
        }
    }
}
