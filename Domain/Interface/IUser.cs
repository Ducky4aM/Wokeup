using Domain.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interface
{
    public interface IUser
    {
  string name { get; }
        string password { get; }

        bool AddFavoriteList(IFavoriteList favorite_list);
        IReadOnlyList<IFavoriteList> GetFavoriteLists();
        Genre GetPreferGenre();
        bool RemoveFavoriteList(IFavoriteList favoriteList);
        bool SetPreferGenre(Genre genre);
    }
}
