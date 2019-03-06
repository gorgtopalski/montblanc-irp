using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using System.Windows.Threading;
using MvvmFoundation.Wpf;
using Vanilla_IRP.Domain;
using Vanilla_IRP.Services;
using Vanilla_IRP.View;
using static System.Windows.Application;

namespace Vanilla_IRP.ViewModel
{
   public class ListModelViewModel : ListDomainViewModel<Model>
   {
       public ListModelViewModel() : base() { }
   }
}
