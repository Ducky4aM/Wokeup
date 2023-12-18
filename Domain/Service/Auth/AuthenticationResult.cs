using Domain.Interface;
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
        public IUser? AuthenticatedUser { get; set; }
        public ServiceStatusResult? AuthenticationStatus { get; set; }
    }
}
