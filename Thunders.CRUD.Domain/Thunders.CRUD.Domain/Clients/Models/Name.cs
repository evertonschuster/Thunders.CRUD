using Thunders.CRUD.Domain.Clients.Exceptions;

namespace Thunders.CRUD.Domain.Clients.Models
{
    public record Name
    {
        private string _value;

        public Name(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                throw new NameNullOrWhitespaceException(nameof(name));
            }

            _value = name;
        }

        public string Value => _value;

        public override string ToString()
        {
            return _value;
        }

        public static implicit operator string(Name nome)
        {
            return nome.ToString();
        }
    }
}
