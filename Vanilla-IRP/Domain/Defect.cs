using LiteDB;

namespace Vanilla_IRP.Domain
{
    public class Defect : IDomain
    {
        public int DefectId { get; set; }
        public string Name { get; set; }
        public string FullName { get; set; }

        public  DefectType DefectType { get; set; }

        public BsonValue Id() => new BsonValue(DefectId);

        #region Equls, Hash, ToString
        public override string ToString() => $"{Name} {FullName} [{DefectType.Name}]";

        protected bool Equals(Defect other)
        {
            return string.Equals(Name, other.Name) && string.Equals(FullName, other.FullName) && Equals(DefectType, other.DefectType);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((Defect) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                var hashCode = (Name != null ? Name.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (FullName != null ? FullName.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (DefectType != null ? DefectType.GetHashCode() : 0);
                return hashCode;
            }
        }
        #endregion
    }
}
