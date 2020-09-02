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

        public static PersonName Empty()
        {
            return new PersonName(string.Empty, string.Empty, string.Empty);
        }

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return Given;
            yield return Middle;
            yield return Family;
        }
    }
}
