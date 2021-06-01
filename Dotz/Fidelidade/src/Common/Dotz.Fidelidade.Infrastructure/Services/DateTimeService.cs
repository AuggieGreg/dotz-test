using System;
using Dotz.Fidelidade.Application.Common.Interfaces;

namespace Dotz.Fidelidade.Infrastructure.Services
{
    public class DateTimeService : IDateTime
    {
        public DateTime Now => DateTime.Now;
    }
}
