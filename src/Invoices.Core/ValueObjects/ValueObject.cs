using System;
using System.Collections.Generic;
using System.Linq;

namespace Invoices.Core.ValueObjects
{
    // based on https://enterprisecraftsmanship.com/posts/value-object-better-implementation/

    /// <summary>
    ///  Based Class for all Value Objects
    /// </summary>

    public abstract class ValueObject
    {
        protected abstract IEnumerable<object> GetEqualityComponents();

        public override bool Equals(object obj)
        {
            if (obj == null)
                return false;

            if (GetType() != obj.GetType())
                return false;

            if (obj is ValueObject valueObject)
            {
                return GetEqualityComponents().SequenceEqual(valueObject.GetEqualityComponents());
            }

            throw new InvalidOperationException("Your are not allowed to compare none ValueObjects");
        }

        public override int GetHashCode()
        {
            return GetEqualityComponents()
                .Aggregate(1, (current, obj) => { return HashCode.Combine(current, obj); });
        }

        public static bool operator ==(ValueObject a, ValueObject b)
        {
            if (ReferenceEquals(a, null) && ReferenceEquals(b, null))
                return true;

            if (ReferenceEquals(a, null) || ReferenceEquals(b, null))
                return false;

            return a.Equals(b);
        }

        public static bool operator !=(ValueObject a, ValueObject b)
        {
            return !(a == b);
        }
    }
}
