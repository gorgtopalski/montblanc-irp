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
using IRP.ViewModel;

namespace IRP.View
{
    public partial class ListModelView : UserControl
    {
        public ListModelView()
        {
            InitializeComponent();
        }

        private void ShowSelected(object sender, MouseButtonEventArgs e)
        {
            if (this.DataContext is ListModelViewModel vm)
                vm.EditSelectedCommand.Execute(null);
        }
    }
}
