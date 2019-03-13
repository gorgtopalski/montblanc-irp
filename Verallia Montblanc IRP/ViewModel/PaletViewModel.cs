using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;
using IRP.Domain;
using IRP.Utils;

namespace IRP.ViewModel
{
    public class PaletViewModel : IPaletVm
    {
        public Palet Palet { get; }
        public Brush BackgroundColor { get; }
        public Brush BorderColor { get; }

        public PaletViewModel() { }

        public PaletViewModel(Palet palet)
        {
            Palet = palet;
            BackgroundColor = PaletColor.GetBackgroundColor(palet);
            BorderColor = PaletColor.GetBorderColor(palet);
        }
    }
}
