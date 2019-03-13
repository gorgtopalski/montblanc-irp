using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;
using IRP.Domain;

namespace IRP.ViewModel
{
    public interface IPaletVm
    {
        Palet Palet {get;}

        Brush BackgroundColor { get; }

        Brush BorderColor { get; }
    }
}
