using Domain.Helper;
using Domain.Interface;
using Domain.Service;
using Infrastructure;
using Infrastructure.DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class User : IUser
    {
        public string name { get; private set; }

        public string password { get; private set; }

        private List<IFavoriteList> favoriteLists = new List<IFavoriteList>();
        
        private List<Genre> preferGenres = new List<Genre>();

        public User(string name, string password)
        {
            if (this.NameValidator(name, new NullWhiteSpaceValidator()) == false)
            {
                throw new Exception("User name is not Valid");
            }

            this.name = name.Trim();

            if (this.PasswordValidator(password, new NullWhiteSpaceValidator()) == false)
            {
                throw new Exception("Invalid Password");
            }
            this.password = password;
        }

        public User(string name, Genre genre)
        {
            if (this.NameValidator(name, new NullWhiteSpaceValidator()) == false)
            {
                throw new Exception("User name is not Valid");
            }

            this.name = name.Trim();
            this.preferGenres.Add(genre);
        }

        public User(string name)
        {
            if (this.NameValidator(name, new NullWhiteSpaceValidator()) == false)
            {
                throw new Exception("User name is not Valid");
            }

            this.name = name.Trim();
        }

        public bool RemoveFavoriteList(IFavoriteList favoriteList)
        {
            if (this.favoriteLists.Contains(favoriteList) == false)
            {
                return false;
            }

            this.favoriteLists.Remove(favoriteList);

            return true;
        }

        public bool AddFavoriteList(IFavoriteList favorite_list)
        {
            if (this.favoriteLists.Any(item => item.name == favorite_list. name) == true)
            {
                return false;
            }

            this.favoriteLists.Add(favorite_list);

            return true;
        }

        public IReadOnlyList<IFavoriteList> GetFavoriteLists()
        {
            return this.favoriteLists.AsReadOnly();
        }

        private bool NameValidator(string name, IStringValidator validator)
        {
            return validator.Validate(name);
        }

        private bool PasswordValidator(string password, IStringValidator validator)
        {
            return validator.Validate(password);
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
