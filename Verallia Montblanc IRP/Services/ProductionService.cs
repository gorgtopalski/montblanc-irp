using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IRP.Database;
using IRP.Domain;

namespace IRP.Services
{
    public class ProductionService : BaseService<Production>
    {
        public ProductionService() : base(ProductionDb.Db()) { }

        public override List<Production> GetAll() => Db.Query<Production>()
            .Include(x => x.Model)
            .Include(x => x.Line)
            .ToList();

        public List<Production> GetActiveProductions => Db.Query<Production>()
            .Include(x => x.Model)
            .Include(x => x.Line)
            .Where(x => x.End == null)
            .ToList();
    }
}
