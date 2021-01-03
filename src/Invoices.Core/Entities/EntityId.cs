using System;

namespace Invoices.Core.Entities
{
    public abstract record EntityId<T>(Guid Id)
    {
        public static T None => _none;
        static T _none = (T) Activator.CreateInstance(typeof(T), Guid.Empty)!;

        public static T New() => (T) Activator.CreateInstance(typeof(T), Guid.NewGuid())!;
    }
}
