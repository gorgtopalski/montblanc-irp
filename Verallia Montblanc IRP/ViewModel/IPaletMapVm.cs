using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IRP.ViewModel
{
    interface IPaletMapVm
    {
        ObservableCollection<IPaletVm> Palets { get; }
    }
}
