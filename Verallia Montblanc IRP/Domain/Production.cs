using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Animation;
using LiteDB;

namespace IRP.Domain
{
    public class Production : IDomain
    {
        public long ProductionId { get; set; }
        public DateTime Start {get; set; }
        public DateTime? End { get; set; }
        public Model Model { get; set; }
        public Line Line { get; set; }
        
        public Production()
        {
            End = null;
            Model = null;
            Line = null;
            Start = DateTime.Today;
        }

        public BsonValue Id() => new BsonValue(ProductionId);

        public bool Validate()
        {
            if (Start == DateTime.MinValue) return false;
            if (Model == null) return false;
            return Line != null;
        }
        
        #region Equals, Hash, ToString

        public override string ToString() => $"{Line.Name} - {Model.Name} [{Start}-{End}]";
        
        protected bool Equals(Production other)
        {
            return Start.Equals(other.Start) && End.Equals(other.End) && Equals(Model, other.Model) && Equals(Line, other.Line);
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
                var hashCode = Start.GetHashCode();
                hashCode = (hashCode * 397) ^ End.GetHashCode();
                hashCode = (hashCode * 397) ^ (Model != null ? Model.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (Line != null ? Line.GetHashCode() : 0);
                return hashCode;
            }
        }

        #endregion
    }
}
