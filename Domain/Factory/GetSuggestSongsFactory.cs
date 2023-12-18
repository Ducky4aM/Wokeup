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
    public class GetSuggestSongsFactory
    {
        private IUser user;
        private IUserService userService;

        public GetSuggestSongsFactory(IUser user, IUserService userService)
        {
            if (user == null)
            {
                throw new ArgumentException("User is null");
            }

            if (userService == null)
            {
                throw new ArgumentException("UserService is null");
            }

            this.user = user;
            this.userService = userService;
        }

        public IGetSongsStrategy GetStrategy()
        {
            IGetSongsStrategy strategy = new GetMostListenedSongsStrategy();

            if (user.GetPreferGenre() != null)
            {
                if (userService.IsUserHaveSongInFavoriteList() == false)
                {
                    strategy = new GetSongsUserPreferGenereStratergy();
                }

                if (userService.IsUserHaveSongInFavoriteList() == true)
                {
                    strategy = new GetSongsSuggestToUserStrategy(userService);
                }
            }

            return strategy;
        }
    }
}
