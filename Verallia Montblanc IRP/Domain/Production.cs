using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LiteDB;

namespace IRP.Domain
{
    public class Production : IDomain
    {
        public long ProductionId { get; set; }
        public DateTime Start {get; set; }
        public DateTime? End { get; set; }
        public Model Model { get; set; }

        public Production()
        {
            End = null;
            Model = null;
            Start = DateTime.Today;
        }

        public BsonValue Id() => new BsonValue(ProductionId);

        #region Equals, Hash, ToString

        public override string ToString() => $"{Model.Name} [{Start}-{End}]";

        protected bool Equals(Production other)
        {
            return Equals(ProductionId, other.ProductionId) && Equals(Model, other.Model);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((Production) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                return ((ProductionId.GetHashCode()) * 397) ^ (Model != null ? Model.GetHashCode() : 0);
            }
        }

        #endregion
    }
}
