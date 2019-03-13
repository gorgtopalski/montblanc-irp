using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using IRP.Domain;
using MvvmFoundation.Wpf;

namespace IRP.ViewModel.DesignData
{
    class MockIrpVm : IIrpVm
    {
        public Irp Irp { get; set; }
        public List<Production> ActiveProductions { get; set; }
        public ObservableCollection<IAuditVm> Audits { get; set; }
        public ObservableCollection<IMotiveVm> Motives { get; set; }
        public RelayCommand AddAuditCommand { get; set; }
        public RelayCommand AddMotiveCommand { get; set; }
        public RelayCommand SaveIrpCommand { get; set; }
        public RelayCommand CriticalCommand { get; set; }


        public MockIrpVm()
        {
            var model = new Model() { Blueprint = "1234ABC", Name = "Cava 75" };
            var line = new Line() { Name = "11" };
            var production = new Production() { Start = DateTime.Today, Line = line, Model = model };

            var dt = new DefectType() { Name = "Mayor", Severity = 1 };
            var defect = new Defect() { Name = "BA", FullName = "Boca Arrancada", DefectType = dt };
           

            Irp = new Irp()
            {
                Production = production,
                FirstPalet = 415,
                LastPalet = 400,
                RejectDate = DateTime.Now
            };

            Motives = new ObservableCollection<IMotiveVm>();

            var motive = new MotiveViewModel()
                {Motive = new Motive() {Number = 11, Comment = "Auditado al 100%", Defect = defect}};
            Motives.Add(motive);

            motive = new MotiveViewModel()
                { Motive = new Motive() { Number = 32, Comment = "Auditado al 100%", Defect = defect }};
            Motives.Add(motive);

            
            Audits = new ObservableCollection<IAuditVm>();
            Audits.Add(new AuditViewModel() { Audit = new Audit() { Number = 414, IsOk = false }});
            Audits.Add(new AuditViewModel() { Audit = new Audit() { Number = 412, IsOk = false }});
            Audits.Add(new AuditViewModel() { Audit = new Audit() { Number = 410, IsOk = true }});
        }

        
    }
}
