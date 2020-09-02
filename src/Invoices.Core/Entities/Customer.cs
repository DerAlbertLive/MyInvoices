using Invoices.Core.ValueObjects;

namespace Invoices.Core.Entities
{
    public class Customer : Entity
    {
        protected Customer()
        {
            CompanyName = CompanyName.Empty();
            Name = PersonName.Empty();
            MainAddress = Address.Empty();
        }

        public Customer(CompanyName companyName, PersonName name):this()
        {
            CompanyName = companyName;
            Name = name;
        }

        public CompanyName CompanyName { get; }
        public PersonName Name { get; set; }

        public Address MainAddress { get; set; }

    }
}
