using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IRP.Domain;

namespace IRP.Services
{
    public class ProductionService : BaseService<Production>
    {
        public ProductionService() : base() { }

        public override List<Production> GetAll() => Db.Query<Production>().Include(x => x.Model).ToList();
    }
}
