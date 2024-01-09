using Domain;
using Domain.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTest.Mock
{
    public class UserMock : IUser
    {
        private readonly bool isValid;

        private readonly List<IFavoriteList> favoriteLists;

        private readonly Genre preferGenre;

        public string name { get; set; }

        public UserMock()
        {
        }

        public UserMock(bool isValid)
        {
            this.isValid = isValid;
        }

        public UserMock(string name,bool isValid)
        {
            this.name = name;
            this.isValid = isValid;
        }

        public UserMock(List<IFavoriteList> favoriteLists)
        {
            this.favoriteLists = favoriteLists;
        }

        public UserMock(List<IFavoriteList> favoriteLists, Genre genre)
        {
            this.favoriteLists = favoriteLists;
            this.preferGenre = genre;
        }

        public UserMock(bool isValid,Genre genre)
        {
            this.isValid = isValid;
            this.preferGenre = genre;
        }

        public string password => throw new NotImplementedException();

        public bool AddFavoriteList(IFavoriteList favorite_list)
        {
            return this.isValid;
        }

        public bool AddPreferGenre(Genre genre)
        {
            throw new NotImplementedException();
        }

        public IReadOnlyList<IFavoriteList> GetFavoriteLists()
        {
            return this.favoriteLists;
        }

        public bool RemoveFavoriteList(IFavoriteList favoriteList)
        {
            return isValid;
        }

        public Genre GetPreferGenre()
        {
            return this.preferGenre;
        }

        public bool SetPreferGenre(Genre genre)
        {
            return this.isValid;
        }
    }
}
