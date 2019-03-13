using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;
using IRP.Domain;
using IRP.Utils;

namespace IRP.ViewModel.DesignData
{
    public class MockPaletVm : IPaletVm
    {
        public Palet Palet { get; }

        public Brush BackgroundColor { get; }

        public Brush BorderColor { get; }

        public MockPaletVm()
        {
            Palet = new Palet();
            Palet.Number = 10;
            Palet.State = PaletState.Rechadazo;
            BackgroundColor = PaletColor.GetBackgroundColor(Palet);
            BorderColor = PaletColor.GetBorderColor(Palet);
        }
    }
}
