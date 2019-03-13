using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media;
using IRP.Domain;

namespace IRP.Utils
{
    public class ProductionLineColor
    {
        public static Brush GetColorForLine(string lineName)
        {
            return new SolidColorBrush(ColorFromLine(lineName));
        }

        public static Brush GetColorForLine(Line line)
        {
            return GetColorForLine(line.Name);
        }

        public static Brush GetBackgroundForLine(Line line)
        {
            return GetBackgroundForLine(line.Name);
        }

        public static Brush GetBackgroundForLine(String line)
        {
            return new SolidColorBrush() {Color = ColorFromLine(line), Opacity = 0.1};
        }

        private static Color ColorFromLine(string lineName)
        {
            Color color;

            if (string.IsNullOrWhiteSpace(lineName))
                color = Colors.White;

            switch (lineName)
            {
                case "11":
                    color = Colors.ForestGreen;
                    break;
                case "11A":
                    color = Colors.ForestGreen;
                    break;
                case "11B":
                    color = Colors.BlueViolet;
                    break;
                case "12":
                    color = Colors.Yellow;
                    break;
                case "12A":
                    color = Colors.Yellow;
                    break;
                case "12B":
                    color = Colors.DarkOrange;
                    break;
                case "13":
                    color = Colors.DodgerBlue;
                    break;
                default:
                    color = Colors.White;
                    break;
            }

            return color;
        }

    }
}
