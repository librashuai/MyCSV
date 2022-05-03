using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using MyCSV.Models;
using MyCSV.ViewModels;
using System;

namespace MyCSV.Views
{
    public partial class SearchControl : UserControl
    {

        SearchControlViewModel viewModel;

        public Action<int, int>? NotifyFindCell;

        public SearchControl()
        {
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            AvaloniaXamlLoader.Load(this);

            this.DataContextChanged += SearchControl_DataContextChanged;
        }


        private void SearchControl_DataContextChanged(object? sender, System.EventArgs e)
        {
            viewModel = this.DataContext as SearchControlViewModel;
            if(viewModel == null)
            {
                return;
            }

            viewModel.NotifyFindCell += (e) =>
            {
                NotifyFindCell?.Invoke(e.Row, e.Column);
            };
        }
    }
}
