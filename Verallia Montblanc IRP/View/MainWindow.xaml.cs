﻿using System.Windows;
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
            ContentControl.Content = new ListModelView();
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
    }
}
