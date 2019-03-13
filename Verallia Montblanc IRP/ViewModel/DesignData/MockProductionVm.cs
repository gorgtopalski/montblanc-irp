using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;
using IRP.Domain;
using IRP.Services;
using IRP.Utils;
using MvvmFoundation.Wpf;

namespace IRP.ViewModel.DesignData
{
    public class MockProductionVm : IProductionVm
    {
        public Production Production { get; set; }
        public PaletCount Count { get; }
        public int LastPalet { get; set; }
        public Brush BorderColor { get; }
        public Brush BackgroundColor { get; }
        public RelayCommand UpdateLastPalet { get; }

        public MockProductionVm()
        {
            var model = new Model() {Blueprint = "1234ABC", Name = "Cava 75"};
            var line = new Line() {Name = "11"};
            Production = new Production() {Start = DateTime.Today, Line = line, Model = model};
            LastPalet = 100;
            Count = new PaletCount(100, 22);
            BorderColor = ProductionLineColor.GetColorForLine(line);
            BackgroundColor = ProductionLineColor.GetBackgroundForLine(line);
        }
    }
}
