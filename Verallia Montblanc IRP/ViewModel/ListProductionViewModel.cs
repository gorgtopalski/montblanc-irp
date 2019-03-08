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
    public class ListProductionViewModel : BaseDomainListVM<Production>
    {
        public ObservableCollection<Model> Models { get; }
        public ObservableCollection<Line> Lines { get; }


        public ListProductionViewModel() : base(new ProductionService())
        {
            Models = new ObservableCollection<Model>();
            new BaseService<Model>().GetAll().ForEach(x => Models.Add(x));

            Lines = new ObservableCollection<Line>();
            new BaseService<Line>().GetAll().ForEach(x => Lines.Add(x));
        }
    }
}
