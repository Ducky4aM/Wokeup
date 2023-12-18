using Domain.CustomException;
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

        //this contructor using when create a nieuw user
        public User(string name, string password)
        {
            if (string.IsNullOrEmpty(name) == true)
            {
                throw new InvalidNameException("User name is not Valid");
            }

            this.name = name.Trim();

            if (string.IsNullOrEmpty(password) == true)
            {
                throw new ArgumentException("Invalid user password");
            }

            this.password = password;
        }

        public User(string name, Genre genre)
        {
            if (string.IsNullOrEmpty(name) == true)
            {
                throw new InvalidNameException("User name is not Valid");
            }
            this.name = name;

            if (genre == null)
            {
                throw new ArgumentException("Genre is null");
            }

            this.preferGenre = genre;
        }

        public User(string name)
        {
            if (string.IsNullOrEmpty(name) == true)
            {
                throw new InvalidNameException("User name is not Valid");
            }

            this.name = name;
        }

        public bool RemoveFavoriteList(IFavoriteList favoriteList)
        {
            if (favoriteList == null)
            {
                throw new ArgumentException("Favorite list to remove is null");
            }

            if (this.favoriteLists.Contains(favoriteList) == false)
            {
                return false;
            }

            this.favoriteLists.Remove(favoriteList);

            return true;
        }

        public bool AddFavoriteList(IFavoriteList favoriteList)
        {
            if (favoriteList == null)
            {
                throw new ArgumentException("Can't add null favorite list");
            }

            if (this.favoriteLists.Any(item => item.name == favoriteList.name) == true)
            {
                return false;
            }

            this.favoriteLists.Add(favoriteList);

            return true;
        }

        public IReadOnlyList<IFavoriteList> GetFavoriteLists()
        {
            return this.favoriteLists.AsReadOnly();
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
