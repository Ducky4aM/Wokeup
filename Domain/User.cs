using Domain.Helper;
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
        public int id { get; private set; }

        public string name { get; private set; }

        public string password { get; private set; }

        private List<FavoriteList> favoriteLists = new List<FavoriteList>();
        
        private List<Genre> preferGenres = new List<Genre>();

        public User(string name, string password)
        {
            if (this.NameValidator(name, new NullWhiteSpaceValidator()) == false)
            {
                throw new Exception("User name is not Valid");
            }

            this.name = name.Trim();

            this.password = password;
        }

        public User(int id, string name)
        {
            if (this.NameValidator(name, new NullWhiteSpaceValidator()) == false)
            {
                throw new Exception("User name is not Valid");
            }

            this.name = name.Trim();

            this.id = id;
        }

        public void RemoveFavoriteList(FavoriteList favoriteList)
        {
            if (this.favoriteLists.Contains(favoriteList))
            {
                this.favoriteLists.Remove(favoriteList);
            }
        }

        public bool AddFavoriteList(FavoriteList favorite_list)
        {
            if (this.favoriteLists.Any(item => item.name == favorite_list. name) == true)
            {
                return false;
            }

            this.favoriteLists.Add(favorite_list);

            return true;
        }

        public IReadOnlyList<FavoriteList> GetFavoriteLists()
        {
            return this.favoriteLists.AsReadOnly();
        }

        private bool NameValidator(string name, IStringValidator validator)
        {
            return validator.Validate(name);
        }

        public bool AddPreferGenre(Genre genre)
        {
            if (this.preferGenres.Any(item => item.name == genre.name) == true)
            {
                return false;
            }

            this.preferGenres.Add(genre);

            return true;
        }

        public IReadOnlyList<Genre> GetPreferGenres()
        {
            return this.preferGenres.AsReadOnly();
        }
    }
}
