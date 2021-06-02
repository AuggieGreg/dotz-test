using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dotz.Fidelidade.Application.Dto
{
    public class UserDto
    {
        public Guid UserId { get; set; }

        public string Name { get; set; }

        public string Role { get; set; }

        public string Email { get; set; }

        public DateTime? BirthDate { get; set; }
    }
}
