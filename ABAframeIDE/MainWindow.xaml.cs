using System;
using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using ABAframeIDE.ViewModel;
using ABAframeIDE.ViewModel.Base;
using MahApps.Metro.Controls;

namespace ABAframeIDE
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : MetroWindow
    {
        private MessageLogViewModel _messageLogViewModel;
        private ToolsPaleteViewModel _toolsPaleteModel;
        private PropertiesViewModel _propertiesViewModel;
        private StructureViewModel _structureViewModel;

        public MainWindow()
        {
            InitializeComponent();
            _messageLogViewModel = new MessageLogViewModel(MessageLogLayoutAnchorable);
            _toolsPaleteModel = new ToolsPaleteViewModel(ToolsPaleteLayoutAnchorable);
            _propertiesViewModel = new PropertiesViewModel(PropertiesLayoutAnchorable);
            _structureViewModel = new StructureViewModel(StructureLayoutAnchorable);
            DataContext = this;
        }

        private void ToolsPalete_OnClick(object sender, RoutedEventArgs e)
        {
            BaseViewModel viewModel = GetViewModelForMenuItem(sender as MenuItem);
            if (viewModel.IsVisible)
                viewModel.Hide();
            else
                viewModel.Show();
        }

        private BaseViewModel GetViewModelForMenuItem(MenuItem sender)
        {
            if (sender.Equals(MessageLogViewMenuItem))
                return _messageLogViewModel;

            if (sender.Equals(PropertiesViewMenuItem))
                return _propertiesViewModel;

            if (sender.Equals(StructureViewMenuItem))
                return _structureViewModel;

            if (sender.Equals(ToolsPaleteViewMenuItem))
                return _toolsPaleteModel;

            throw new Exception("MenuItem isn't from the view group.");
        }
    }
}
