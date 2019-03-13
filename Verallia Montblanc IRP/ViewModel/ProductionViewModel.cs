using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Media;
using IRP.Domain;
using IRP.Services;
using IRP.Utils;
using MvvmFoundation.Wpf;

namespace IRP.ViewModel
{
    public class ProductionViewModel : ObservableObject, IProductionVm
    {
        private ProductionService _service;
        private PaletService _paletService;

        public Brush BorderColor => ProductionLineColor.GetColorForLine(Production.Line);
        public Brush BackgroundColor => ProductionLineColor.GetBackgroundForLine(Production.Line);
        public RelayCommand UpdateLastPalet { get; }

        private string _header;
        public string Header => _header;
        
        private Production _production;

        public Production Production {
            get => _production;
            set
            {
                if (Equals(value,_production)) return;
                _production = value;

                RaisePropertyChanged(nameof(Production));
            }
        }

        private PaletCount _count;

        public PaletCount Count
        {
            get => _count;
            set
            {
                if (Equals(value, _count)) return;
                _count = value;

                RaisePropertyChanged(nameof(Count));
            }
        }


        private int _lastPalet;
        public int LastPalet
        {
            get => _lastPalet;
            set
            {
                if (value == _lastPalet) return;
                _lastPalet = value;

                RaisePropertyChanged(nameof(LastPalet));
            }
        }

        public ProductionViewModel()
        {
            Init();
        }

        public ProductionViewModel(Production production)
        {
            Production = production;
            Init();

            _header = $"{Production.Line.Name} - {Production.Model.Name}";
            UpdateLastPalet = new RelayCommand(GeneratePalets);
            _lastPalet = _paletService.LastRegisteredPaletNumber(Production);
        }

        private void Init()
        {
            _service = new ProductionService();
            _paletService = new PaletService();
            _count = _paletService.CountForProduction(Production);
        }

        public void GeneratePalets()
        {
            _paletService.GeneratePaletsForProduction(_production,_lastPalet);
            Count = _paletService.CountForProduction(Production);
            //RaisePropertyChanged(nameof(Count));
        }

    }
}
