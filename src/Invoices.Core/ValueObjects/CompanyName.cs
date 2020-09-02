using System.Collections.Generic;

namespace Invoices.Core.ValueObjects
{
    public class CompanyName : ValueObject
    {
        public string Name1 { get; }
        public string Name2 { get; }

        public CompanyName(string name1, string name2)
        {
            Name1 = name1;
            Name2 = name2;
        }
        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return Name1;
        }

        public static CompanyName Empty()
        {
            return new CompanyName(string.Empty, string.Empty);
        }
    }
}
