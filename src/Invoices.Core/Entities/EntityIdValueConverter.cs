using System;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Invoices.Core.Entities
{
    public class EntityIdValueConverter<T> : ValueConverter<T, Guid> where T : EntityId<T>
    {
        public EntityIdValueConverter() : base(id => id.Id, guid => (Activator.CreateInstance(typeof(T), guid) as T)!)
        {
        }
    }
}
