using System.Collections.Generic;
using LiteDB;

namespace IRP.Domain
{
    public class DefectType : IDomain
    {
        public int DefectTypeId { get; set; }
        public int Severity { get; set; }
        public string Name { get; set; }
        
        public BsonValue Id() => new BsonValue(DefectTypeId);
        public bool Validate()
        {
            if (string.IsNullOrWhiteSpace(Name)) return false;
            return Severity >= 0;
        }
        
        #region Equals, Hash, ToString
        
        public override string ToString() => Name;

        protected bool Equals(DefectType other)
        {
            return Severity == other.Severity && string.Equals(Name, other.Name);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((DefectType) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                return (Severity * 397) ^ (Name != null ? Name.GetHashCode() : 0);
            }
        }

        private sealed class SeverityRelationalComparer : IComparer<DefectType>
        {
            public int Compare(DefectType x, DefectType y)
            {
                if (ReferenceEquals(x, y)) return 0;
                if (ReferenceEquals(null, y)) return 1;
                if (ReferenceEquals(null, x)) return -1;
                return x.Severity.CompareTo(y.Severity);
            }
        }

        public static IComparer<DefectType> SeverityComparer { get; } = new SeverityRelationalComparer();

        #endregion
    }
}
