using System;
using Invoices.Core.ValueObjects;

namespace Invoices.Core.Entities
{
    public class User : IEntityChangedAt
    {
        public UserId Id { get; }

        public PersonName Name { get; }

        public DateTime CreatedAt { get; set; }
        public DateTime ChangedAt { get; set; }
        public EMail EMail { get; }

        public bool Locked { get; set; }

        protected User()
        {
            Id = UserId.New();
            Name = PersonName.None;
            EMail = EMail.None;
        }

        public User(PersonName name, EMail eMail) : this()
        {
            Name = name;
            EMail = eMail;
        }
    }
}
