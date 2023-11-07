using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class Genre
    {
        public string name {  get; private set; }

        public Genre(string name) {
            this.name = name;
        }

        public override string ToString()
        {
            return this.name;
        }
    }
}
