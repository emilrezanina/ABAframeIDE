using Xceed.Wpf.AvalonDock.Layout;

namespace ABAframeIDE.ViewModel.Base
{
    public class BaseViewModel
    {
        protected readonly LayoutAnchorable PanelLayoutAnchorable;

        public BaseViewModel(LayoutAnchorable panelLayoutAnchorable)
        {
            PanelLayoutAnchorable = panelLayoutAnchorable;
        }

        public bool IsVisible {
            get
            {
                return PanelLayoutAnchorable.IsVisible;
            }}

        public void Show()
        {
            PanelLayoutAnchorable.Show();
        }

        public void Hide()
        {
            PanelLayoutAnchorable.Hide();
        }

    }
}