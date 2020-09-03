using System.Collections.Generic;

namespace Invoices.Core.ValueObjects
{
    public class PersonName : ValueObject
    {
        public string Given { get; }
        public string Middle { get; }
        public string Family { get; }

        public PersonName(string given, string middle, string family)
        {
            Given = given;
            Middle = middle;
            Family = family;
        }

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return Given;
            yield return Middle;
            yield return Family;
        }

        public static PersonName Empty() => _empty;
        static PersonName _empty = new PersonName(string.Empty, string.Empty, string.Empty);
    }
}
