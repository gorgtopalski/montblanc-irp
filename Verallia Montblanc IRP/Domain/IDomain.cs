using LiteDB;

namespace IRP.Domain
{
    public interface IDomain
    {
        BsonValue Id();
        bool Validate();
    }
}