using Dotz.Fidelidade.Application.Common.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Dotz.Fidelidade.Infrastructure.EntityQueriers
{
    public class UserEntityQuerier : IUserEntityQuerier
    {
        private readonly IApplicationDbContext _context;
        public UserEntityQuerier(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<bool> HasUniqueEmail(string email, CancellationToken token)
        {
            return await _context.Users.AllAsync(x => x.Email != email, token);
        }
    }
}
