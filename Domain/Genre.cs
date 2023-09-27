using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class Genre
    {
        public GenreType GenreType {  get; private set; }

        public Genre(GenreType genreType) {
            GenreType = genreType;
        }
    }
}
