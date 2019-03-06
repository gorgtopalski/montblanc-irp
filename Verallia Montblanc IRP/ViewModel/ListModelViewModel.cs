using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using System.Windows.Threading;
using IRP.Domain;
using MvvmFoundation.Wpf;
using IRP.Services;
using IRP.View;
using static System.Windows.Application;

namespace IRP.ViewModel
{
   public class ListModelViewModel : ListDomainViewModel<Model>
   {
       public ListModelViewModel() : base() { }
   }
}
