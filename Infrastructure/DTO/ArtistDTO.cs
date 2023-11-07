using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.DTO
{
    public class ArtistDTO
    {
        public string name { get; private set; }

        public ArtistDTO(string name)
        {
            this.name = name;
        }
    }
}
