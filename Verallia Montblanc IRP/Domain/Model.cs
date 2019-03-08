using System.Windows.Forms;
using LiteDB;

namespace IRP.Domain
{
    public class Model : IDomain
    {
        public int ModelId { get; set; }
        public string Name { get; set; }
        public string Blueprint { get; set; }

        public BsonValue Id() => new BsonValue(ModelId);
        public bool Validate()
        {
            if (string.IsNullOrWhiteSpace(Name)) return false;
            return !string.IsNullOrWhiteSpace(Blueprint);
        }
        
        #region Equals, Hash and ToString
        public override string ToString()
        {
            return $"{Name} [{Blueprint}]";
        }

        protected bool Equals(Model other)
        {
            return string.Equals(Name, other.Name) && string.Equals(Blueprint, other.Blueprint);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((Model)obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                return ((Name != null ? Name.GetHashCode() : 0) * 397) ^ (Blueprint != null ? Blueprint.GetHashCode() : 0);
            }
        }
        #endregion
    }
}