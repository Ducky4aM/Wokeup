using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Service.Sort
{
    public class SongSortingManager : IComparer<Song>
    {
        private readonly List<IComparer<Song>> comparers;

        public SongSortingManager(List<IComparer<Song>> comparers)
        {
            this.comparers = comparers;
        }

        public int Compare(Song? x, Song? y)
        {
            foreach (var comparer in comparers)
            {
                int result = comparer.Compare(x, y);
                if (result != 0)
                {
                    return result;
                }
            }

            return 0; // If all comparers return 0, the songs are considered equal
        }
    }
}
