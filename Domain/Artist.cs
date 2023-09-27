using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class Artist
    {
        public string name { get; private set; }

        public Artist(string name)
        {
            this.name = name;
        }
    }
}
