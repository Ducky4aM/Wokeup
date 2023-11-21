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
            if (this.NameValidator(name, new NullWhiteSpaceValidator()) == false)
            {
                throw new Exception("Artist name is not valid!");
            }
              
            this.name = name.Trim();
        }

        public IReadOnlyList<Genre> GetGenres()
        {
            return this.genres.AsReadOnly();
        }

        private bool NameValidator(string name, IStringValidator validator)
        {
            return validator.Validate(name);
        }
    }
}
