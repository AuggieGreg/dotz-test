using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dotz.Fidelidade.Application.User.Commands
{
    public class UserLoginCommand
    {
        public string Email { get; set; }

        public string Password { get; set; }
    }
}
