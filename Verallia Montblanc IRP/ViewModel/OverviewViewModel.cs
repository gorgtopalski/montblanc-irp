using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IRP.Services;
using MvvmFoundation.Wpf;

namespace IRP.ViewModel
{
    public class OverviewViewModel : ObservableObject
    {
        private ObservableCollection<ProductionViewModel> _active;
        public ObservableCollection<ProductionViewModel> ActiveProductions
        {
            get => _active;
            set
            {
                if (Equals(_active,value)) return;
                _active = value;
                
                RaisePropertyChanged(nameof(ActiveProductions));
            }
        }

        private readonly ProductionService _productionService;

        public OverviewViewModel()
        {
            _active = new ObservableCollection<ProductionViewModel>();
            _productionService = new ProductionService();

            //TODO Clean Sorting
            var tempList = new List<ProductionViewModel>();
            _productionService.GetActiveProductions.ForEach(x => tempList.Add(new ProductionViewModel(x)));
            var sorted = from item in tempList orderby item.Production.Line select item;
            _active = new ObservableCollection<ProductionViewModel>(sorted);

        }

    }
}
