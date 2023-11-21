using Domain.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class Genre
    {
        public string name { get; private set; }

        public Genre(string name)
        {
            if (this.nameValidator(name, new NullWhiteSpaceValidator()) == false)
            {
                throw new Exception("Genre name not valid");
            }

            this.name = name.Trim();
        }

        public override string ToString()
        {
            return this.name;
        }

        private bool nameValidator(string name, IStringValidator validator)
        {
            return validator.Validate(name);
        }
    }
}
