using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IRP.Domain;
using IRP.Services;

namespace IRP.ViewModel
{
    public class ListProductionViewModel : ListDomainViewModel<Production>
    {
        public ObservableCollection<Model> Models { get; }

        public ListProductionViewModel() : base(new ProductionService())
        {
            Models = new ObservableCollection<Model>();
            new BaseService<Model>().GetAll().ForEach( x => Models.Add(x));
        }
    }
}
