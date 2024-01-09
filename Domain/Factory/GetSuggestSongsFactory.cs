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
        //Uservervice allen gerbuikem usere hoeven niet
        public static IGetSongsStrategy GetStrategy(IUserService userService)
        {
            IGetSongsStrategy strategy = new GetMostListenedSongsStrategy();

            if (userService.IsUserHaveSongInFavoriteList() == false)
            {
                strategy = new GetSongsUserPreferGenereStratergy();
            }

            if (userService.IsUserHaveSongInFavoriteList() == true)
            {
                strategy = new GetSongsSuggestToUserStrategy(userService);
            }

            return strategy;
        }
    }
}
