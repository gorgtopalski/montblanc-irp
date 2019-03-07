using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Threading;
using IRP.Domain;
using MvvmFoundation.Wpf;
using IRP.Services;

namespace IRP.ViewModel
{
    public class ListDomainViewModel<T> : ObservableObject where T : IDomain, new()
    {
        private readonly ObservableCollection<T> _data;
        private readonly BaseService<T> _service;
        private PropertyObserver<BaseService<T>> _observer;
        
        public ObservableCollection<T> Data => _data;

        private T _selected;
        public T Selected
        {
            get => _selected;
            set
            {
                if (Equals(_selected, value)) return;
                _selected = value;
                IsSelected = _selected != null;
                RaisePropertyChanged(nameof(Selected));
            }
        }

        private bool _isSelected;
        public bool IsSelected
        {
            get => _isSelected;
            set
            {
                if (_isSelected == value) return; ;
                _isSelected = value;
                RaisePropertyChanged(nameof(IsSelected));
            }
        }

        private Visibility _isEditVisible = Visibility.Collapsed;
        public Visibility IsEditVisible
        {
            get => _isEditVisible;
            set
            {
                if (_isEditVisible == value) return;
                _isEditVisible = value;
                RaisePropertyChanged(nameof(IsEditVisible));
            }
        }

        public RelayCommand EditSelectedCommand { get; set; }
        public RelayCommand DeleteSelectedCommand { get; set; }
        public RelayCommand AddNewCommand { get; set; }
        public RelayCommand SaveCommand { get; set; }
        public RelayCommand CancelCommand { get; set; }

        public ListDomainViewModel()
        {
            _service = new BaseService<T>();
            _data = new ObservableCollection<T>();

            SetupViewModel(_service);
        }

        public ListDomainViewModel(BaseService<T> service)
        {
            _service = service;
            _service.GetAll();
            _data = new ObservableCollection<T>();

            SetupViewModel(_service);
        }

        private void SetupViewModel(BaseService<T> service)
        {  
            _observer = new PropertyObserver<BaseService<T>>(this._service)
                .RegisterHandler(x => x.Values, UpdateObservable);

            UpdateObservable(_service);

            EditSelectedCommand = new RelayCommand(DoEdit);
            DeleteSelectedCommand = new RelayCommand(DoDelete);
            AddNewCommand = new RelayCommand(DoAdd);
            CancelCommand = new RelayCommand(DoCancel);
            SaveCommand = new RelayCommand(DoSave);
        }


        private void DoSave()
        {
            if (Selected == null) return;
            _service.Save(Selected);
            DoCancel();
        }

        private void DoCancel()
        {
            IsEditVisible = Visibility.Collapsed;
            IsSelected = false;
            //Selected = default(T);
        }

        public void DoEdit()
        {
            if (Selected == null) return;
            IsEditVisible = Visibility.Visible;
        }

        private void DoDelete()
        {
            if (Selected == null) return;
            var msg = $"Estas seguro de borrar {Selected.ToString()}";
            var caption = "Borrar";

            var result = MessageBox.Show(
                msg,
                caption,
                MessageBoxButton.OKCancel,
                MessageBoxImage.Question,
                MessageBoxResult.Cancel);

            if (result == MessageBoxResult.OK)
                _service.Delete(Selected);

            DoCancel();
        }

        private void DoAdd()
        {
            IsEditVisible = Visibility.Visible;
            //Selected = default(T);
            Selected = new T();
        }

        private void UpdateObservable(IDomainService<T> service)
        {
            Data.Clear();
            foreach (var item in service.GetAll())
            {
                Data.Add(item);
                RaisePropertyChanged(nameof(Data));
            }
        }
    }
}
