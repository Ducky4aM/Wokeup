using Domain.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Validator
{
    public class PasswordLenghtValidator : IStringValidator
    {
        public bool Validate(string validateValue)
        {
            if (validateValue.Length < 3)
            {
                return false;
            }

            return true;
        }
    }
}
