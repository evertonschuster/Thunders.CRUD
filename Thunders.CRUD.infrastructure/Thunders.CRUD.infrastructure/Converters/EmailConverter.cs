using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Thunders.CRUD.Domain.Clients.Models;

namespace Thunders.CRUD.infrastructure.Converters
{
    internal sealed class EmailConverter : ValueConverter<Email, string>
    {
        public EmailConverter()
            : base(v => v.Value, v => new Email(v))
        {
        }
    }
}
