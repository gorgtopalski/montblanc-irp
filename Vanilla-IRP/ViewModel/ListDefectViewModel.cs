using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vanilla_IRP.Domain;
using Vanilla_IRP.Services;

namespace Vanilla_IRP.ViewModel
{
    public class ListDefectViewModel : ListDomainViewModel<Defect>
    {
        public ObservableCollection<DefectType> DefectTypes { get; }
        
        public ListDefectViewModel() : base(new DefectService())
        {
            DefectTypes = new ObservableCollection<DefectType>();
            new BaseService<DefectType>().GetAll().ForEach(x => DefectTypes.Add(x));
        }
    }
}
