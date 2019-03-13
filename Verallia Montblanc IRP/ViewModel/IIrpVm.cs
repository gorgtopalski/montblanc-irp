using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IRP.Domain;
using MvvmFoundation.Wpf;

namespace IRP.ViewModel
{
    public interface IIrpVm
    {
        Irp Irp { get; set; }

        List<Production> ActiveProductions { get; set; }

        ObservableCollection<IAuditVm> Audits { get; set; }

        ObservableCollection<IMotiveVm> Motives { get; set; }
        
        RelayCommand AddAuditCommand { get; set; }

        RelayCommand AddMotiveCommand { get; set; }

        RelayCommand SaveIrpCommand { get; set; }

        RelayCommand CriticalCommand { get; set; }
        
    }
}
