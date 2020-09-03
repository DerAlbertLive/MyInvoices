using System.Collections.Generic;

namespace Invoices.Core.ValueObjects
{
    public class Address : ValueObject
    {
        public string Street { get; }
        public string City { get; }
        public string ZipCode { get; }

        public Address(string street, string city, string zipCode)
        {
            Street = street;
            City = city;
            ZipCode = zipCode;
        }

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return Street;
            yield return City;
            yield return ZipCode;
        }

        public static Address Empty() => _empty;
        static Address _empty = new Address(string.Empty, string.Empty, string.Empty);
    }
}
