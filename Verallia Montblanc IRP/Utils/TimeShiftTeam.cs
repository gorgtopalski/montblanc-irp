using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using IRP.Domain;

namespace IRP.Utils
{
    public class TimeShiftTeam
    {
        private static readonly int[][] Calendar = new []
        {
            new int[]{3,5,4},
            new int[]{3,5,4},
            new int[]{4,2,5},
            new int[]{4,2,5},
            new int[]{5,3,2},
            new int[]{5,3,2},
            new int[]{5,3,2},

            new int[]{2,4,1},
            new int[]{2,4,1},
            new int[]{1,5,4},
            new int[]{1,5,4},
            new int[]{4,2,5},
            new int[]{4,2,5},
            new int[]{4,2,5},

            new int[]{5,1,3},
            new int[]{5,1,3},
            new int[]{3,4,1},
            new int[]{3,4,1},
            new int[]{1,5,4},
            new int[]{1,5,4},
            new int[]{1,5,4},

            new int[]{4,3,2},
            new int[]{4,3,2},
            new int[]{2,1,3},
            new int[]{2,1,3},
            new int[]{3,4,1},
            new int[]{3,4,1},
            new int[]{3,4,1},

            new int[]{1,2,5},
            new int[]{1,2,5},
            new int[]{5,3,2},
            new int[]{5,3,2},
            new int[]{2,1,3},
            new int[]{2,1,3},
            new int[]{2,1,3},
        };

        private static DateTime SeedDate()
        {
            return new DateTime(2019,2,4);
        }

        private static int[] GetIndex()
        {
            var today = DateTime.Today;
            var x = ((today - SeedDate()).Days) % Calendar.Length;
            int y = 0;

            if (today.Hour >= 22 && today.Hour < 6)
                y = 0;
            else if (today.Hour >= 6 && today.Hour < 14)
                y = 1;
            else
                y = 2;

            return new int[] {x, y};
        }

        public static Shift GetCurrentShift()
        {
            var today = DateTime.Today;
            if (today.Hour >= 22 && today.Hour < 6)
                return Shift.Night;
            else if (today.Hour >= 6 && today.Hour < 14)
                return Shift.Morning;
            else
                return Shift.Afternoon;
        }

        public static Team GetCurrentTeam()
        {
            var today = DateTime.Today;
            var x = ((today - SeedDate()).Days) % Calendar.Length;
            int y = 0;

            if (today.Hour >= 22 && today.Hour < 6)
                y = 0;
            else if (today.Hour >= 6 && today.Hour < 14)
                y = 1;
            else
                y = 2;

            var team = Calendar[x][y];

            switch (team)
            {
                case 1:
                    return Team.One;
                case 2:
                    return Team.Two;
                case 3:
                    return Team.Three;
                case 4:
                    return Team.Four;
                case 5:
                    return Team.Five;
                default:
                    return Team.Five;
            }
        }

    }
}
