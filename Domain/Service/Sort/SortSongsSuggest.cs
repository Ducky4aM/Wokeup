using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Service.Sort
{
    internal class SortSongsSuggest : IComparer<Song>
    {
        List<Genre> genres;

        public SortSongsSuggest(List<Genre> genres) 
        {
            this.genres = genres; 
        }

        public int Compare(Song? x, Song? y)
        {
            int indexX = genres.FindIndex(genre => genre.name == x.genre.name);
            int indexY = genres.FindIndex(genre => genre.name == y.genre.name);

            if (indexX == -1 && indexY == -1)
            {
                // If both genres are not in the specified order, maintain the original order
                return 0;
            }

            if (indexX == -1)
            {
                // x's genre is not in the specified order, so move it to the end
                return 1;
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
