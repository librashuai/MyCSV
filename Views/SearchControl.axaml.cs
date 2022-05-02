using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;

namespace MyCSV.Views
{
    public partial class SearchControl : UserControl
    {
        public SearchControl()
        {
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            AvaloniaXamlLoader.Load(this);
        }
    }
}
