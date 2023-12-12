using Domain.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Service.Auth
{
    public class AuthenticationResult
    {
        public User? AuthenticatedUser { get; set; }
        public ServiceStatusResult? AuthenticationStatus { get; set; }
    }
}
