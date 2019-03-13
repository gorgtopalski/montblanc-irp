using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using IRP.Domain;
using IRP.Services;

namespace IRP.ViewModel
{
    public class PaletMapViewModel
    {
        private ObservableCollection<IPaletVm> _palets;

        public ObservableCollection<IPaletVm> Palets => _palets;
        
        public PaletMapViewModel() { }

        public PaletMapViewModel(Production production)
        {
            var service = new PaletService();

            _palets = new ObservableCollection<IPaletVm>();
            service.GetAllForProduction(production).ForEach( x => _palets.Add(new PaletViewModel(x)));
        }
    }
}
