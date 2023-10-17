using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.DTO
{
    public class FavoriteListDTO
    {
        public string name { get; private set; }
        public int id { get; private set; }

        public FavoriteListDTO(string name){
            this.name = name;
        }

        public FavoriteListDTO(int id,string name){
            this.name = name;
            this.id = id;
        }
    }
}
