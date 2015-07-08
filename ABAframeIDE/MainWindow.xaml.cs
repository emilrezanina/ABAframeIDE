using System;
using System.ComponentModel;
using System.Globalization;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using ABAframeIDE.ViewModel;
using ABAframeIDE.ViewModel.Base;
using ControlsLibrary;
using MahApps.Metro.Controls;

namespace ABAframeIDE
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : MetroWindow
    {
        private MessageLogViewModel _messageLogViewModel;
        private ToolboxViewModel _toolsPaleteModel;
        private PropertiesViewModel _propertiesViewModel;
        private StructureViewModel _structureViewModel;

        public MainWindow()
        {
            InitializeComponent();
            _messageLogViewModel = new MessageLogViewModel(MessageLogLayoutAnchorable);
            _toolsPaleteModel = new ToolboxViewModel(ToolboxLayoutAnchorable);
            _propertiesViewModel = new PropertiesViewModel(PropertiesLayoutAnchorable);
            _structureViewModel = new StructureViewModel(StructureLayoutAnchorable);

            SetMessageBoxExample();
            DataContext = this;
        }

        private void SetMessageBoxExample()
        {
            var stringBuilder = new StringBuilder();
            string format = "MM/dd/yyyy HH:mm";
            DateTime messageTime = DateTime.Now;
            stringBuilder.AppendLine(messageTime.ToString(format) + ": Create agent1.");
            stringBuilder.AppendLine(messageTime.ToString(format) + ": Create agent2.");
            stringBuilder.AppendLine(messageTime.ToString(format) + ": Create agent3.");
            messageTime = messageTime.AddMinutes(1);
            stringBuilder.AppendLine(messageTime.ToString(format) + ": Change name of agent from agent1 to Agent Surroudings.");
            stringBuilder.AppendLine(messageTime.ToString(format) + ": Change name of agent from agent2 to Agent Services.");
            stringBuilder.AppendLine(messageTime.ToString(format) + ": Change name of agent from agent3 to Agent Resource manager.");
            messageTime = messageTime.AddMinutes(2);
            stringBuilder.AppendLine(messageTime.ToString(format) + ": Create link1 between Agent Surroundings and Agent Services.");
            stringBuilder.AppendLine(messageTime.ToString(format) + ": Change name of link from link1 to Incoming customer.");
            messageTime = messageTime.AddMinutes(1);
            stringBuilder.AppendLine(messageTime.ToString(format) + ": Create link2 between Agent Services and Agent Surroudings.");
            stringBuilder.AppendLine(messageTime.ToString(format) + ": Change name of link from link2 to Outgoing customer.");
            messageTime = messageTime.AddMinutes(3);
            stringBuilder.AppendLine(messageTime.ToString(format) + ": Create link3 between Agent Services and Agent Resource manager.");
            stringBuilder.AppendLine(messageTime.ToString(format) + ": Change name of link from link3 to Deliver resource.");
            messageTime = messageTime.AddMinutes(1);
            stringBuilder.AppendLine(messageTime.ToString(format) + ": Link Deliver resource has Request type");
            messageTime = messageTime.AddMinutes(1);
            stringBuilder.AppendLine(messageTime.ToString(format) + ": Create link4 between Agent Resource manager and Agent Services.");
            stringBuilder.AppendLine(messageTime.ToString(format) + ": Change name of link from link4 to Deliver resource.");
            messageTime = messageTime.AddMinutes(1);
            stringBuilder.AppendLine(messageTime.ToString(format) + ": Link Deliver resource has Request type");                           
            messageTime = messageTime.AddMinutes(3);
            stringBuilder.AppendLine(messageTime.ToString(format) + ": Create link5 between Agent Services and Agent Resource manager.");
            stringBuilder.AppendLine(messageTime.ToString(format) + ": Change name of link from link5 to Return resource.");
            MessageLogTextBlock.Text = stringBuilder.ToString();
        }

        private void ShiftOnCanvas(UIElement element, Point startPoint)
        {
            Canvas.SetTop(element, startPoint.Y);
            Canvas.SetLeft(element, startPoint.X);
        }

        private void ViewMenuItem_OnClick(object sender, RoutedEventArgs e)
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
