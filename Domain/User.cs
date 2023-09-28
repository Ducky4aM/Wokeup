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

        private string password;

        private List<FavoriteList> favoriteListCollecttion;


        public User(string name, string password)
        {
            this.name = name;
            this.password = password;
        }

        public List<FavoriteList> GetUserFavoriteListCollection ()
        {
            return this.favoriteListCollecttion;
        }

        public bool createNewFavoriteList(string name)
        {
            FavoriteList newList =  new FavoriteList(name,this);

            favoriteListCollecttion.Add(newList); 

            return true;
        }

    }
}
