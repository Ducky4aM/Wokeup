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
        public string name { get; private set; }
        public string password { get; private set; }

        public int id { get; private set; }

        private List<FavoriteList> favoriteLists = new List<FavoriteList>();

        private FavoriteListRepository favoriteListRepository = new FavoriteListRepository();

        public User(string name, string password)
        {
            this.name = name;
            this.password = password;
        }

        public User(string name,int id)
        {
            this.name = name;
            this.id = id;
        }

        public IReadOnlyList<FavoriteList> GetFavoriteListCollection ()
        {
            return this.favoriteLists;
        }

        public bool CreateNewFavoriteList(string name)
        {
            if (IsFavorieListExist(name) == true)
            {
                return false;
            }

            FavoriteList newList = new FavoriteList(name);
            FavoriteListDTO favoriteListDto = new FavoriteListDTO(name);
            this.favoriteListRepository.AddNewFavoriteList(favoriteListDto, this.id);

            favoriteLists.Add(newList); 

            return true;
        }

        private bool IsFavorieListExist(string name)
        {
            return this.favoriteLists.Any(favoritelist => favoritelist.name == name);
        }

        public IReadOnlyList<FavoriteList> GetUserFavoriteLists()
        {
            IReadOnlyList<FavoriteListDTO> favoriteListsDto = favoriteListRepository.GetAllFavoriteListBaseOnUserId(this.id);
            this.favoriteLists.Clear();

            foreach (FavoriteListDTO favoriteListDto in favoriteListsDto)
            {
                this.favoriteLists.Add(new FavoriteList(favoriteListDto.id,favoriteListDto.name));
            }

            return this.favoriteLists.AsReadOnly();
        }

    }
}
