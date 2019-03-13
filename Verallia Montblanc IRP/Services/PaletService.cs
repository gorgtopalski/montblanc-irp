using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using IRP.Database;
using IRP.Domain;

namespace IRP.Services
{
    public class PaletService : BaseService<Palet>
    {
        public PaletService() : base(ProductionDb.Db()) { }

        public List<Palet> GetAllForProduction(Production production)
        {
            return Db.Query<Palet>()
                .Include(x => x.Production)
                .Include(x => x.RejectionState)
                .Where(x => x.Production.Equals(production))
                .ToList();
        }

        public int CountForProductionTotal(Production production)
        {
            return Db.Query<Palet>()
                .Include(x => x.Production)
                .Where(x => x.Production.Equals(production))
                .Count();
        }

        public int CountForProductionAccepted(Production production)
        {
            return Db.Query<Palet>()
                .Include(x => x.Production)
                .Include(x => x.State)
                .Where(x => x.Production.Equals(production) && x.State == PaletState.Aceptado)
                .Count();
        }

        public int CountForProductionRejected(Production production)
        {
            return Db.Query<Palet>()
                .Include(x => x.Production)
                .Where(x => x.Production.Equals(production) && x.State == PaletState.Rechadazo)
                .Count();
        }

        public PaletCount CountForProduction(Production production)
        {
            PaletCount count = new PaletCount();
            
            Db.Query<Palet>()
                .Include(x => x.Production)
                .Where(x => x.Production.ProductionId == production.ProductionId)
                .ToList().ForEach(x => count.CountPalet(x));

            return count;
        }

        public void GeneratePaletsForProduction(Production production, int lastKnown)
        {   
            
            if (production == null) return;

            var lastRegistered = LastRegisteredPaletNumber(production);

            if (lastRegistered >= lastKnown) return;

            for (int i = lastRegistered; i < lastKnown; i++)
            {

                var p = new Palet() {Number = i, Production = production, State = PaletState.Aceptado};

                if (p.Validate())
                   this.Save(p);
            }
        }

        public int LastRegisteredPaletNumber(Production production)
        {
            if (production == null) return -1;
            return Db.Query<Palet>()
                .Include(x => x.Production)
                .Where(x => x.Production.ProductionId == production.ProductionId)
                .Count();
        }

    }
}
