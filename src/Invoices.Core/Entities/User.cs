using System;
using Invoices.Core.ValueObjects;

namespace Invoices.Core.Entities
{
    public class User : IEntityChangedAt
    {
        public PersonName Name { get; }

        protected User()
        {
            Name = PersonName.Empty();
            EMail = EMail.Empty();
        }

        public User(PersonName name, EMail eMail) : this()
        {
            Name = name;
            EMail = eMail;
        }

        public long Id { get; }
        public DateTime CreatedAt { get; set; }
        public DateTime ChangedAt { get; set; }
        public EMail EMail { get; }

        public bool Locked { get; set; }
    }
}
