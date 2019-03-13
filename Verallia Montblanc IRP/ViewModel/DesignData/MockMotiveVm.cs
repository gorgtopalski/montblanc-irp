using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IRP.Domain;
using MvvmFoundation.Wpf;

namespace IRP.ViewModel.DesignData
{
    class MockMotiveVm : IMotiveVm
    {
        public Motive Motive { get; set; }
        public List<Defect> Defects { get; }
        public RelayCommand DeleteRowCommand { get; set; }

        public MockMotiveVm()
        {
            var dt = new DefectType() {Name = "Mayor", Severity = 1};
            var defect = new Defect() {Name = "BA", FullName = "Boca Arrancada", DefectType = dt};
            var defect1 = new Defect() { Name = "BR", FullName = "Boca Rajada", DefectType = dt };
            var defect2 = new Defect() { Name = "FSB", FullName = "Fisura Boca", DefectType = dt };


            Motive = new Motive() {Number = 10, Comment = "Auditado al 100%", Defect = defect};
            Defects = new List<Defect>();
            Defects.Add(defect);
            Defects.Add(defect1);
            Defects.Add(defect2);
        }

    }
}
