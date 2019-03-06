using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using IRP.Domain;

namespace IRP.Services
{
    public class DefectService : BaseService<Defect>
    {
        public DefectService() : base() {}

        public override List<Defect> GetAll() => Db.Query<Defect>().Include(x => x.DefectType).ToList();
    }
}
