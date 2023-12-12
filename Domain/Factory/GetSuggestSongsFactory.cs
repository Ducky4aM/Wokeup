using Domain.Interface;
using Domain.Service;
using Domain.Service.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Factory
{
    public static class GetSuggestSongsFactory
    {
        public static IGetSongsStrategy GetStrategy(IUser user, UserService userService)
        {
            IGetSongsStrategy strategy = new GetMostListenedSongs();

            if (user.GetPreferGenres().Count > 0 && userService.IsUserHaveSongInFavoriteList() == false)
            {
                strategy = new GetSongsUserPreferGenereStratergy();
            }

            if (user.GetPreferGenres().Count >= 0 && userService.IsUserHaveSongInFavoriteList() == true)
            {
                strategy = new GetSongsSuggestToUser(userService);
            }

            return strategy;
        }
    }
}
