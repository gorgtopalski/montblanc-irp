using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LiteDB;

namespace IRP.Domain
{
    public class RejectionState : IDomain
    {
        public int Id { get; set; }
        public string State { get; set; }

        BsonValue IDomain.Id() => Id > 0 ? new BsonValue(Id) : new BsonValue();

        public bool Validate()
        {
            return !string.IsNullOrWhiteSpace(State);
        }
        
        #region Equals, Hash, ToString

        public override string ToString() => $"{State}";

        protected bool Equals(RejectionState other)
        {
            return string.Equals(State, other.State);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((RejectionState) obj);
        }

        public override int GetHashCode()
        {
            return (State != null ? State.GetHashCode() : 0);
        }

        #endregion
    }
}
