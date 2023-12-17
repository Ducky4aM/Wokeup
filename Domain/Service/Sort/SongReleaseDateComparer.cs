using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Service.Sort
{
    public class SongReleaseDateComparer : IComparer<Song>
    {
        public int Compare(Song? x, Song? y)
        {
            bool xReleasedWithinWeek = (DateTime.Now - x.releaseAt).TotalDays <= 7;
            bool yReleasedWithinWeek = (DateTime.Now - y.releaseAt).TotalDays <= 7;

            if (xReleasedWithinWeek && !yReleasedWithinWeek)
            {
                return -1; // x should come first
            }
            else if (!xReleasedWithinWeek && yReleasedWithinWeek)
            {
                return 1; // y should come first
            }
            else
            {
                return 0; // no preference if both or neither were released within the last week
            }
        }
    }
}
