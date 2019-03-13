using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;
using IRP.Domain;
using MvvmFoundation.Wpf;

namespace IRP.ViewModel
{
    public interface IProductionVm
    {
        Production Production { get; set; }

        PaletCount Count { get; }
        
        int LastPalet { get; set; }

        Brush BorderColor { get; }

        Brush BackgroundColor { get; }

        RelayCommand UpdateLastPalet { get; }
    }
}
