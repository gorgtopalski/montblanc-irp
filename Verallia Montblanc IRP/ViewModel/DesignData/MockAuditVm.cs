using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;
using IRP.Domain;
using MvvmFoundation.Wpf;

namespace IRP.ViewModel.DesignData
{
    public class MockAuditVm : IAuditVm
    {
        public Audit Audit { get; set; }

        public RelayCommand DeleteRowCommand { get; set; }

        public MockAuditVm()
        {
            Audit = new Audit() {Number = 40, Comment = "Auditado al 100 %", IsOk = true};
        }
    }
}
