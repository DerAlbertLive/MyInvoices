using Invoices.Core.ValueObjects;

namespace Invoices.Core.Entities
{
    public class Customer : Entity
    {
        protected Customer()
        {
            Name = CompanyName.Empty();
            ContactName = PersonName.Empty();
            MainAddress = Address.Empty();
        }

        public Customer(CompanyName name, PersonName contactName) : this()
        {
            Name = name;
            ContactName = contactName;
        }

        public CompanyName Name { get; }
        public PersonName ContactName { get; set; }

        public Address MainAddress { get; set; }
    }
}
