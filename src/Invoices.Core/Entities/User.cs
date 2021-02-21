using System;
using Invoices.Core.ValueObjects;

namespace Invoices.Core.Entities
{
    public class User : IEntityChanged
    {
        public UserId Id { get; }

        public PersonName Name { get; private set; }

        public DateTime CreatedAt { get; private set; }
        public DateTime ChangedAt { get; private set; }

        public void Created()
        {
            CreatedAt = DateTime.UtcNow;
            ChangedAt = DateTime.MinValue;
        }

        public void Changed()
        {
            ChangedAt = DateTime.UtcNow;
        }

        public EMail EMail { get; private set; }

        public bool Locked { get; private set; }

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
