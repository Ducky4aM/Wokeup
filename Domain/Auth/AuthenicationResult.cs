using Domain.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Auth
{
    public class AuthenicationResult
    {
        public User? AuthenticatedUser { get; set; }
        public ServiceStatusJob? AuthenticationStatus { get; set; }
    }
}
