using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IRP.Domain
{
    public class Audit
    {
        public int Number { get; set; }
        public string Comment { get; set; }
        public bool IsOk { get; set; }
    }
}
