using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LiteDB;

namespace IRP.Domain
{
    public class Palet : IDomain
    {
        public ObjectId PaletId { get; set; }
        public int Number { get; set; }
        public PaletState State { get; set; }
        public RejectionState RejectionState { get; set; }
        public Production Production { get; set; }

        public BsonValue Id() => new BsonValue(PaletId);

        public bool Validate()
        {
            if (Production == null) return false;
            return Number >= 0;
        }
    }

}
