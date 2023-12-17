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
        public static IGetSongsStrategy GetStrategy(IUser user, IUserService userService)
        {
            IGetSongsStrategy strategy = new GetMostListenedSongs();

            if (user.GetPreferGenre() != null)
            {
                if (userService.IsUserHaveSongInFavoriteList() == false)
                {
                    strategy = new GetSongsUserPreferGenereStratergy();
                }

                if (userService.IsUserHaveSongInFavoriteList() == true)
                {
                    strategy = new GetSongsSuggestToUser(userService);
                }
            }

            return strategy;
        }
    }
}
