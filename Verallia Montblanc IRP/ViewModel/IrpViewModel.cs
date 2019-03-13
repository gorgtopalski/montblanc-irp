using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms.VisualStyles;
using IRP.Domain;
using IRP.Services;
using IRP.ViewModel.DesignData;
using MvvmFoundation.Wpf;

namespace IRP.ViewModel
{
    public class IrpViewModel : ObservableObject, IIrpVm
    {
        private Irp _irp;

        public Irp Irp
        {
            get => _irp;
            set
            {
                if (Equals(value, _irp)) return;
                _irp = value;

                RaisePropertyChanged(nameof(Irp));
            }
        }
        
        public List<Production> ActiveProductions { get; set; }

        private ObservableCollection<IAuditVm> _audits;

        public ObservableCollection<IAuditVm> Audits
        {
            get => _audits;
            set
            {
                if (Equals(value,_audits)) return;
                _audits = value;

                RaisePropertyChanged(nameof(Audits));
            }
        }

        private ObservableCollection<IMotiveVm> _motives;

        public ObservableCollection<IMotiveVm> Motives
        {
            get => _motives;
            set
            {
                if (Equals(value,_motives)) return;
                _motives = value;
            
                RaisePropertyChanged(nameof(Motives));
            }
        }


        public IrpViewModel()
        {
            Irp = new Irp();
            Init();
        }

        public IrpViewModel(Irp irp)
        {
            Irp = irp;
            Init();
        }

        private void Init()
        {
            _audits = new ObservableCollection<IAuditVm>();
            _motives = new ObservableCollection<IMotiveVm>();
            AddMotive();

            ActiveProductions = new List<Production>();
            var prodService = new ProductionService();
            prodService.GetActiveProductions.ForEach(x => ActiveProductions.Add(x));

            AddAuditCommand = new RelayCommand(AddAudit);
            AddMotiveCommand = new RelayCommand(AddMotive);
        }

        public RelayCommand AddAuditCommand { get; set; }

        private void AddAudit()
        {
            var count = _audits.Count;
            _audits.Add(new AuditViewModel() { Audit = new Audit(), DeleteRowCommand = new RelayCommand(delegate()
            {
                if(_audits.Count > count)
                    _audits.RemoveAt(count);
                else
                    _audits.RemoveAt(_audits.Count-1);
                
            })});
        }
        
        public RelayCommand AddMotiveCommand { get; set; }

        private void AddMotive()
        {
            var count = _motives.Count;
            _motives.Add(new MotiveViewModel() { Motive = new Motive(), DeleteRowCommand = new RelayCommand(delegate()
                    {
                        if (_motives.Count > count)
                            _motives.RemoveAt(count);
                        else
                            _motives.RemoveAt(_motives.Count-1);
                    }
            )});
        }

        public RelayCommand SaveIrpCommand { get; set; }
        public RelayCommand CriticalCommand { get; set; }
    }
}
