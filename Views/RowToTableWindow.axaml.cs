using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using MyCSV.ViewModels;

namespace MyCSV.Views
{
    public partial class RowToTableWindow : Window
    {
        RowToTableViewModel? viewModel;
        public RowToTableWindow()
        {
            WindowStartupLocation = WindowStartupLocation.CenterOwner;
            InitializeComponent();
#if DEBUG
            this.AttachDevTools();
#endif
            this.DataContextChanged += RowToTableWindow_DataContextChanged;
        }

        private void RowToTableWindow_DataContextChanged(object? sender, System.EventArgs e)
        {
            viewModel = this.DataContext as RowToTableViewModel;
        }

        private void InitializeComponent()
        {
            AvaloniaXamlLoader.Load(this);
        }
    }
}
