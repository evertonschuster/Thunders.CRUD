using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Thunders.CRUD.Domain.Clients;
using Thunders.CRUD.Domain.Clients.Models;

namespace Thunders.CRUD.infrastructure.Converters
{
    internal class NameConverter : ValueConverter<Name, string>
    {
        public NameConverter()
            : base(v => v.Value, v => new Name(v))
        {
        }
    }
}
