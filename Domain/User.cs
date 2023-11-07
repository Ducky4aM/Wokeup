using Domain.Service;
using Infrastructure;
using Infrastructure.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class User
    {
        public int id { get; set; }  
        public string name { get; private set; }
        public string password { get; private set; }

        private List<FavoriteList> favoriteLists = new List<FavoriteList>();

        public User(string name, string password)
        {
            this.name = name;
            this.password = password;
        }

        public User(int id, string name)
        {
            this.id = id;
            this.name = name;
        }

        internal void RemoveFavoriteList(FavoriteList favoriteList)
        {
            if (this.favoriteLists.Contains(favoriteList))
            {
                this.favoriteLists.Remove(favoriteList);
            }
        }

        internal void AddFavoriteList(FavoriteList favorite_list)
        {
            //hier better met bool returm type
            if (this.favoriteLists.Any(favoritelist => favoritelist.name.Equals(favorite_list.name)))
            {
                return;
            }

            this.favoriteLists.Add(favorite_list);
        }

        internal void UpdateFavoriteList(List<FavoriteList> favoriteLists)
        {
            this.favoriteLists = favoriteLists;
        }

        public IReadOnlyList<FavoriteList> GetFavoriteLists()
        {
            return this.favoriteLists.AsReadOnly();
        }
    }
}
