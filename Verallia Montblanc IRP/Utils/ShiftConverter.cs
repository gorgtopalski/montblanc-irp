using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using IRP.Domain;

namespace IRP.Utils
{
    public class ShiftConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is Shift shift)
            {
                switch (shift)
                {
                    case Shift.Afternoon:
                        return "Tarde";
                    case Shift.Morning:
                        return "Mañana";
                    case Shift.Night:
                        return "Noche";
                    default:
                        return "Noche";
                }
            }
            return "Noche";
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            switch (value?.ToString())
            {
                case "Tarde":
                    return Shift.Afternoon;
                case "Mañana":
                    return Shift.Morning;
                case "Noche":
                    return Shift.Night;
                default:
                    return Shift.Night;
            }
        }
    }
}
