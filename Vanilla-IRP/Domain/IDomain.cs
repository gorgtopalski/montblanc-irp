using LiteDB;

namespace Vanilla_IRP.Domain
{
    public interface IDomain
    {
        BsonValue Id();
    }
}