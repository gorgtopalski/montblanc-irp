using System.Windows.Controls;
using LiteDB;

namespace IRP.Domain
{
    public class Line : IDomain
    {
        public int LineId { get; set; }
        public string Name { get; set; }

        public BsonValue Id() => LineId > 0 ? new BsonValue(LineId) : new BsonValue();
        public bool Validate()
        {
            return !string.IsNullOrWhiteSpace(Name);
        }
        
        #region Equals, Hash and ToString

        protected bool Equals(Line other)
        {
            return string.Equals(Name, other.Name);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((Line)obj);
        }

        public override int GetHashCode()
        {
            return (Name != null ? Name.GetHashCode() : 0);
        }


        public override string ToString()
        {
            return Name;
        }

        #endregion
    }
}
