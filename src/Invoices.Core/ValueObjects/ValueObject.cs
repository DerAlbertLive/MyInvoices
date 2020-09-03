using System;
using System.Collections.Generic;
using System.Linq;

namespace Invoices.Core.ValueObjects
{
    // based on https://enterprisecraftsmanship.com/posts/value-object-better-implementation/

    /// <summary>
    ///  Based Class for all Value Objects
    /// </summary>
    public abstract class ValueObject : IEquatable<ValueObject>
    {
        protected abstract IEnumerable<object> GetEqualityComponents();

        public override bool Equals(object other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            if (other.GetType() != GetType()) return false;
            return Equals((ValueObject) other);
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

        public bool Equals(ValueObject? other)
        {
            if (other == null)
                return false;

            if (GetType() != other.GetType())
                return false;


            return GetEqualityComponents().SequenceEqual(other.GetEqualityComponents());
        }
    }
}
