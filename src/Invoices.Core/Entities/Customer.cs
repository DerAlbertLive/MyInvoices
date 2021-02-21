using Invoices.Core.ValueObjects;

namespace Invoices.Core.Entities
{
    public class Customer : Entity<CustomerId>
    {
        protected Customer()
        {
            Name = CompanyName.None;
            ContactName = PersonName.None;
            MainAddress = Address.None;
        }

        public Customer(CompanyName name, PersonName contactName) : this()
        {
            Name = name;
            ContactName = contactName;
        }

        public CompanyName Name { get; }
        public PersonName ContactName { get; }
        public Address MainAddress { get; }
    }
}
