using LiteDB;
using Vanilla_IRP.Domain;

namespace Vanilla_IRP.Database
{
    public class CommonsDb
    {
        private static CommonsDb _instance =  new CommonsDb();
        private readonly LiteRepository _repository;

        private CommonsDb()
        {
            System.IO.Directory.CreateDirectory(Properties.Db.Default.CommonsDbPath);
            _repository = new LiteRepository(GenerateConnectionString());

            //Map relations
            BsonMapper.Global.Entity<Defect>()
                .DbRef(x => x.DefectType, "DefectType");
            
            //Index generation
            var db = _repository.Database;
            db.GetCollection<Model>().EnsureIndex(x => x.Name, true);
            db.GetCollection<Model>().EnsureIndex(x => x.Blueprint, false);

            db.GetCollection<Line>().EnsureIndex(x => x.Name, true);

            db.GetCollection<DefectType>().EnsureIndex(x => x.Name, true);

            db.GetCollection<Defect>().EnsureIndex(x => x.Name, true);
        }

        public static CommonsDb Instance() => (_instance ?? (_instance = new CommonsDb()));

        public static LiteRepository Db() => (_instance ?? (_instance = new CommonsDb()))._repository;

        public static string GenerateConnectionString()
        {
            return Properties.Db.Default.CommonsDbPath + "." + Properties.Db.Default.DbSuffix;
        }
    }
}
