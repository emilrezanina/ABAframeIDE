using System.Windows.Controls;

namespace ControlsLibrary
{
    /// <summary>
    /// Interaction logic for AgentControl.xaml
    /// </summary>
    public partial class AgentControl : UserControl
    {
        public string Text
        {
            get { return AgentLabel.Text; }
            set { AgentLabel.Text = value; }
        }

        public AgentControl()
        {
            this.InitializeComponent();
        }
    }
}
