using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms.VisualStyles;
using IRP.Utils;
using LiteDB;

namespace IRP.Domain
{
    public class Irp : IDomain
    {
        public long IrpId { get; set; }
        public Production Production{ get; set; }
        public DateTime RejectDate { get; set; }
        public Team Team { get; set; }
        public Shift Shift { get; set; }
        public List<Motive> Motives { get; set; }

        public int FirstPalet { get; set; }
        public int LastPalet { get; set; }
        public List<Audit> Audits { get; set; }

        public bool RejectWholeShift { get; set; }
        public bool RejectionLabel { get; set; }
        public bool Bounded { get; set; }
        public string Comments { get; set; }

        public bool IsCritical { get; set; }
        public CriticalIrp CriticalInfo { get; set; }

        public Irp()
        {
            Team = TimeShiftTeam.GetCurrentTeam();
            Shift = TimeShiftTeam.GetCurrentShift();
            RejectDate = DateTime.Now;
            Motives = new List<Motive>();
            Audits = new List<Audit>();
        }

        public BsonValue Id()
        {
           return IrpId <= 0 ? new BsonValue() : new BsonValue(IrpId);
        }

        public bool Validate()
        {
            throw new NotImplementedException();
        }
    }
}
