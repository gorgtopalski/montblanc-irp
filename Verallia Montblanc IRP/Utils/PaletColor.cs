using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;
using IRP.Domain;
using IRP.Services;

namespace IRP.Utils
{
    class PaletColor
    {
        private static Color GetColor(Palet palet)
        {
            if (palet == null)
                return Colors.Black;

            return palet.State == PaletState.Aceptado ? Colors.ForestGreen : Colors.OrangeRed;
        }

        public static Brush GetBorderColor(Palet palet)
        {
            return new SolidColorBrush() { Color = GetColor(palet) };
        }

        public static Brush GetBackgroundColor(Palet palet)
        {
            return new SolidColorBrush() {Color = GetColor(palet), Opacity = 0.1 };
        }

        public static Brush GetColor(Palet palet, double opacity)
        {
            return new SolidColorBrush() { Color = GetColor(palet), Opacity = opacity };
        }
    }
}
