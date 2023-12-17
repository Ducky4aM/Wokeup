using Domain.CustomException;
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

        private Genre preferGenre;

        public User(string name, string password)
        {
            this.name = name;
            this.password = password;
        }

        //this contructor using when create a nieuw user
        public User(string name, string password, IStringValidator validator)
        {
            if (validator.Validate(name) == false)
            {
                throw new InvalidNameException("User name is not Valid");
            }

            this.name = name.Trim();

            if (validator.Validate(password) == false)
            {
                throw new ArgumentException("Invalid Password");
            }

            this.password = password;
        }

        public User(string name, Genre genre)
        {
            this.name = name;
            this.preferGenre = genre;
        }

        public User(string name)
        {
            this.name = name;
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
            if (this.favoriteLists.Any(item => item.name == favorite_list.name) == true)
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

        private bool PasswordValidator(string password, IStringValidator validator)
        {
            return validator.Validate(password);
        }

        public bool SetPreferGenre(Genre genre)
        {
            if (genre == null)
            {
                throw new ArgumentException("Can't add prefer genre, genre is null!");
            }

            this.preferGenre = genre;
            return true;
        }

        public Genre? GetPreferGenre()
        {
            return this.preferGenre;
        }
    }
}
