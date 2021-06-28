using System;
using System.Collections.Generic;
using System.Text;

namespace SOCIAL.DOMAIN.TYPES
{
    public abstract class ENTITY<TId> : IEquatable<ENTITY<TId>>
    {
        #region Constructors and properties
        protected ENTITY(TId id)
        {
            if (!IsValidId(id))
                throw new ArgumentException();

            Id = Id;
        }
        #endregion

        public TId Id { get; private set; }

        #region IEquatable implementation
        public bool Equals(ENTITY<TId> other)
        {
            return Id.GetHashCode() == other.Id.GetHashCode();
        }

        public override bool Equals(object obj)
        {
            return Equals(obj as ENTITY<TId>);
        }

        public override int GetHashCode()
        {
            return Id.GetHashCode();
        }

        public static bool operator ==(ENTITY<TId> lhs, ENTITY<TId> rhs)
        {
            return lhs.Equals(rhs);
        }

        public static bool operator !=(ENTITY<TId> lhs, ENTITY<TId> rhs)
        {
            return !(lhs == rhs);
        }
        #endregion

        #region Private methods
        private bool IsValidId(TId id)
        {
            return id is int || id is Guid;
        }
        #endregion

    }
}

