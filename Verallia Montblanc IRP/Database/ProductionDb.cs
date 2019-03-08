using IRP.Domain;
using LiteDB;

namespace IRP.Database
{
    public class ProductionDb
    {
        private static ProductionDb _instance =  new ProductionDb();
        private readonly LiteRepository _repository;

        private ProductionDb()
        {
            //TODO verify folder creation
            System.IO.Directory.CreateDirectory(Properties.Db.Default.ProductionDbPath);
            _repository = new LiteRepository(GenerateConnectionString());

            //Map relations
            
            //Index generation
            var db = _repository.Database;
        }

        public static ProductionDb Instance() => (_instance ?? (_instance = new ProductionDb()));

        public static LiteRepository Db() => (_instance ?? (_instance = new ProductionDb()))._repository;

        public static string GenerateConnectionString()
        {
            return Properties.Db.Default.ProductionDbPath + "." + Properties.Db.Default.DbSuffix;
        }
    }
}
