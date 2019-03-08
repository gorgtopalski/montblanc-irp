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
    public class ListDefectViewModel : BaseDomainListVM<Defect>
    {
        public ObservableCollection<DefectType> DefectTypes { get; }
        
        public ListDefectViewModel() : base(new DefectService())
        {
            DefectTypes = new ObservableCollection<DefectType>();
            new BaseService<DefectType>().GetAll().ForEach(x => DefectTypes.Add(x));
        }
    }
}
