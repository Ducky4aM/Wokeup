using Domain.Interface;
using Domain.Service.Interface;
using Domain.Service.Sort;
using Infrastructure;
using Infrastructure.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Service
{
    public class GetSongsUserPreferGenereStratergy : IGetSongsStrategy
    {
        public IReadOnlyList<Song> GetSongs(IUser user ,List<Song> songs)
        {
            List<Genre> genres = new List<Genre>() { user.GetPreferGenre() };

            List<IComparer<Song>> comparers = new List<IComparer<Song>>() {
                new SongGenreComparer(genres),
                new SongListenedComparer()
            };

            SongSortingManager sortingManager = new SongSortingManager(comparers);
            songs.Sort(sortingManager);

            return songs.AsReadOnly();
        }
    }
}
 