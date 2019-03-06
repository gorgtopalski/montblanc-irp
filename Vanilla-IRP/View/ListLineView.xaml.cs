using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Vanilla_IRP.ViewModel;

namespace Vanilla_IRP.View
{
    public partial class ListLineView : UserControl
    {
        public ListLineView()
        {
            InitializeComponent();
        }

        private void ShowSelected(object sender, MouseButtonEventArgs e)
        {
            if (this.DataContext is ListLineViewModel vm)
                vm.EditSelectedCommand.Execute(null);
        }
    }
}
