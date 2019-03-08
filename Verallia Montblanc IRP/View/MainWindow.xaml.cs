using System.ComponentModel;
using System.Windows;
using IRP.Database;
using IRP.ViewModel;

namespace IRP.View
{
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            //Restore size and position from previous session
            this.Top = Properties.Settings.Default.Top;
            this.Left = Properties.Settings.Default.Left;
            this.Height = Properties.Settings.Default.Height;
            this.Width = Properties.Settings.Default.Width;
            if (Properties.Settings.Default.Maximized)
            {
                WindowState = WindowState.Maximized;
            }
            
            //Default "home page"
            ContentControl.Content = new Overview();
        }

        private void ShowModels(object sender, RoutedEventArgs e)
        {
            ContentControl.Content = new ListModelView();
        }

        private void AddNewModel(object sender, RoutedEventArgs e)
        {
            var ctx = new ListModelViewModel();
            ctx.AddNewCommand.Execute(null);
            ContentControl.Content = new ListModelView() {DataContext = ctx};
        }

        private void Exit(object sender, RoutedEventArgs e)
        {
           this.Close();
        }

        private void LoadSampleData(object sender, RoutedEventArgs e)
        {
            Bootstrap.LoadData();
        }

        private void ShowLines(object sender, RoutedEventArgs e)
        {
            ContentControl.Content = new ListLineView();
        }

        private void ShowDefectTypes(object sender, RoutedEventArgs e)
        {
            ContentControl.Content = new ListDefectTypeView();
        }

        private void ShowDefects(object sender, RoutedEventArgs e)
        {
            var ctx = new ListDefectViewModel();
            ContentControl.Content = new ListDefectView() {DataContext = ctx};
        }

        private void AddNewProduction(object sender, RoutedEventArgs e)
        {
            var ctx = new ListProductionViewModel();
            ctx.AddNewCommand.Execute(null);
            ContentControl.Content = new ListProductionView() { DataContext = ctx };
        }

        private void ShowProductions(object sender, RoutedEventArgs e)
        {
            ContentControl.Content = new ListProductionView();
        }

        private void ShowPaletRejectStates(object sender, RoutedEventArgs e)
        {
            ContentControl.Content = new ListPaletRejectStateView();
        }

        private void OnClosing(object sender, CancelEventArgs e)
        {
            //Persist window state from current session
            if (WindowState == WindowState.Maximized)
            {
                // Use the RestoreBounds as the current values will be 0, 0 and the size of the screen
                Properties.Settings.Default.Top = RestoreBounds.Top;
                Properties.Settings.Default.Left = RestoreBounds.Left;
                Properties.Settings.Default.Height = RestoreBounds.Height;
                Properties.Settings.Default.Width = RestoreBounds.Width;
                Properties.Settings.Default.Maximized = true;
            }
            else
            {
                Properties.Settings.Default.Top = this.Top;
                Properties.Settings.Default.Left = this.Left;
                Properties.Settings.Default.Height = this.Height;
                Properties.Settings.Default.Width = this.Width;
                Properties.Settings.Default.Maximized = false;
            }

            Properties.Settings.Default.Save();
        }
    }
}
