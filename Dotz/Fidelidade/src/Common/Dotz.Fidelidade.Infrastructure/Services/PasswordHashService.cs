using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;
using Dotz.Fidelidade.Application.Common.Interfaces;

namespace Dotz.Fidelidade.Infrastructure.Services
{
    public class PasswordHashService : IPasswordHashService
    {
        public string GetHash(string input)
        {
            var bytes = MD5.HashData(Encoding.ASCII.GetBytes(input));
            return Convert.ToBase64String(bytes);
        }
    }
}
