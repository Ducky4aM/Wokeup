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
    public class GetSongsSuggestToUser : IGetSongsStrategy
    {
        private UserService userService;

        public GetSongsSuggestToUser(UserService userService)
        {
            this.userService = userService;
        }

        public IReadOnlyList<Song> GetSongs(IUser user, List<Song> songs)
        {
            List<Genre> genres = this.userService.getSuggestGenreForUser();

            songs.Sort(new SortSongsSuggest(genres));

            return songs.AsReadOnly();
        }
    }
}
