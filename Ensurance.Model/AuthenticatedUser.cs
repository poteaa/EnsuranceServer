using Ensurance.Model.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ensurance.Model
{
    public class AuthenticatedUser: UserDTO
    {
        public string Token { get; set; }
    }
}
