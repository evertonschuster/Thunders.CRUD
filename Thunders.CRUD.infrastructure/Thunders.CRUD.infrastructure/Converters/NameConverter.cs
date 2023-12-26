using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
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
