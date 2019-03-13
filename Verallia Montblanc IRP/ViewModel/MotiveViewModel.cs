using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IRP.Domain;
using IRP.Services;
using MvvmFoundation.Wpf;

namespace IRP.ViewModel
{
    class MotiveViewModel : IMotiveVm
    {
        public Motive Motive { get; set; }
        public List<Defect> Defects { get; }
        public RelayCommand DeleteRowCommand { get; set; }

        public MotiveViewModel()
        {
            Motive = new Motive();
            Defects = new BaseService<Defect>().GetAll();
        }

        public MotiveViewModel(Motive motive)
        {
            Motive = motive;
            Defects = new BaseService<Defect>().GetAll();
        }



    }
}
