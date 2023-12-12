using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Service.Sort
{
    public class SortSongsListened : IComparer<Song>
    {
        public int Compare(Song? x, Song? y)
        {
            return y.listened.CompareTo(x.listened);
        }
    }
}
