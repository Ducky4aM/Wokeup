using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Service
{
    public class SortSongOnUserPreferGenre : IComparer<Song>
    {
        User user;

        public SortSongOnUserPreferGenre(User user) 
        { 
            this.user = user;
        }

        public int Compare(Song? x, Song? y)
        {
            List<Genre> preferGenres = this.user.GetPreferGenres().ToList();

            int indexX = preferGenres.FindIndex(genre => genre.name == x.genre.name);
            int indexY = preferGenres.FindIndex(genre => genre.name == y.genre.name);

            if (indexX == -1)
            {
                // x's genre is not in the specified order, so move it to the end
                return indexY == -1 ? 0 : 1;
            }

            if (indexY == -1)
            {
                // y's genre is not in the specified order, so move it to the end
                return -1;
            }

            return indexX.CompareTo(indexY);
        }
    }
}
