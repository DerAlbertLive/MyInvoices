using System;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Invoices.Core.Entities
{
    public class EntityIdValueConversion<T> : ValueConverter<T, Guid> where T : EntityId<T>
    {
        public EntityIdValueConversion() : base(id => id.Id, guid => (Activator.CreateInstance(typeof(T), guid) as T)!)
        {
        }
    }
}
