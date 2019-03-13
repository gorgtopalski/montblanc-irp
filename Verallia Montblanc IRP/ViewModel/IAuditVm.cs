using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IRP.Domain;
using MvvmFoundation.Wpf;

namespace IRP.ViewModel
{
    public interface IAuditVm
    {
        Audit Audit { get; set; }

        RelayCommand DeleteRowCommand { get; set; }
    }
}
