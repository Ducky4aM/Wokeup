using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.DTO
{
    public class GenreDTO
    {
        public string? name { get; set; }

        public GenreDTO(string? name) { 
            this.name = name;
        }
    }
}
