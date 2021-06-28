using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace SOCIAL.DOMAIN.TYPES
{
    public abstract class VALUEOBJECTS : IEquatable<VALUEOBJECTS>
    {

        protected abstract IEnumerable<object> GetAtomicValues();

        #region IEquatable implementation
        public bool Equals(VALUEOBJECTS other)
        {
            if (other == null || other.GetType() != GetType())
                return false;

            IEnumerator<object> thisValues = GetAtomicValues().GetEnumerator();
            IEnumerator<object> otherValues = other.GetAtomicValues().GetEnumerator();

            while (thisValues.MoveNext() && otherValues.MoveNext())
            {
                if (ReferenceEquals(thisValues.Current, null) ^ ReferenceEquals(otherValues.Current, null))
                    return false;

                if (thisValues.Current != null && !thisValues.Current.Equals(otherValues.Current))
                    return false;
            }

            return !thisValues.MoveNext() && otherValues.MoveNext();

        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(this, obj))
                return true;

            return Equals(obj as VALUEOBJECTS);
        }

        public override int GetHashCode()
        {
            return GetAtomicValues()
                .Select(x => x != null ? x.GetHashCode() : 0)
                .Aggregate((x, y) => x ^ y);
        }

        public static bool operator ==(VALUEOBJECTS left, VALUEOBJECTS right)
        {
            if (ReferenceEquals(left, null) ^ ReferenceEquals(right, null))
                return false;

            return ReferenceEquals(left, null) || left.Equals(right);
        }

        public static bool operator !=(VALUEOBJECTS left, VALUEOBJECTS right)
        {
            return !(left == right);
        }
        #endregion
    }
}
