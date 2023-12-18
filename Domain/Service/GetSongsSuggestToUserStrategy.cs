using Domain.Interface;
using Domain.Service.Interface;
using Domain.Service.Sort;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Service
{
    public class GetSongsSuggestToUserStrategy : IGetSongsStrategy
    {
        private IUserService userService;

        public GetSongsSuggestToUserStrategy(IUserService userService)
        {
            this.userService = userService;
        }

        public IReadOnlyList<Song> GetSongs(IUser user, List<Song> songs)
        {
            List<Genre> genres = this.userService.GetSuggestGenreForUser();

            List<IComparer<Song>> comparers = new List<IComparer<Song>>() {
                new SongGenreComparer(genres),
                new SongReleaseDateComparer(),
                new SongListenedComparer(),
            };

            SongSortingManager sortingManager = new SongSortingManager(comparers);

            songs.Sort(sortingManager);
            return songs.AsReadOnly();
        }
    }
}
