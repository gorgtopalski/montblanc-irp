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
    public class TeamConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is Team team)
            {
                switch (team)
                {
                    case Team.One:
                        return "1";
                    case Team.Two:
                        return "2";
                    case Team.Three:
                        return "3";
                    case Team.Four:
                        return "4";
                    case Team.Five:
                        return "5";
                    default:
                        return "5";
                }
            }
            return "5";
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            switch (value?.ToString())
            {
                case "1":
                    return Team.One;
                case "2":
                    return Team.Two;
                case "3":
                    return Team.Three;
                case "4":
                    return Team.Four;
                case "5":
                    return Team.Five;
                default:
                    return Team.Five;
            }
        }
    }
}
