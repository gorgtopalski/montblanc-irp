using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IRP.Domain;
using MvvmFoundation.Wpf;

namespace IRP.ViewModel
{
    class AuditViewModel  : IAuditVm
    {
        public Audit Audit { get; set; }

        public RelayCommand DeleteRowCommand { get; set; }
    }
}
