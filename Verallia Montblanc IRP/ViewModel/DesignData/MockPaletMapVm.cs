using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IRP.Domain;

namespace IRP.ViewModel.DesignData
{
    public class MockPaletMapVm : IPaletMapVm
    {
        public ObservableCollection<IPaletVm> Palets { get; }
        
        public MockPaletMapVm()
        {
            Palets = new ObservableCollection<IPaletVm>();
            var rand = new Random();

            for (int i = 123; i > 1; i--)
            {
                var rej = (i % 5 != rand.Next(5)) ? PaletState.Aceptado : PaletState.Rechadazo;
                Palets.Add(new PaletViewModel(new Palet() { Number = i, State = rej}));
            }
        }
    }
}
