using Avalonia.Controls;
using Avalonia.Controls.Primitives;
using Avalonia.Data;
using Avalonia.Interactivity;
using MyCSV.ViewModels;
using System;
using System.Collections.Generic;

namespace MyCSV.Views
{
    public partial class MainWindow : Window
    {
        MainWindowViewModel viewModel;
        public MainWindow()
        {
            InitializeComponent();

            this.DataContextChanged += MainWindow_DataContextChanged;
            this.uiTBShowHeader.Checked += UiTBShowHeader_Checked;
            this.uiTBShowHeader.Unchecked += UiTBShowHeader_Unchecked;
        }

        private void UiTBShowHeader_Unchecked(object? sender, RoutedEventArgs e)
        {
            uiDataGrid.HeadersVisibility = DataGridHeadersVisibility.None;
        }

        private void UiTBShowHeader_Checked(object? sender, RoutedEventArgs e)
        {
            var header = App.I.modelCSV.Header();
            if(header != null)
            {
                uiDataGrid.HeadersVisibility = DataGridHeadersVisibility.All;
                for (int i = 0; i < Math.Min(header.Count, uiDataGrid.Columns.Count); i++)
                {
                    uiDataGrid.Columns[i].Header = header[i];
                }
            }
        }

        private void MainWindow_DataContextChanged(object? sender, EventArgs e)
        {
            viewModel = DataContext as MainWindowViewModel;
            if (viewModel == null)
                return;
            viewModel.NotifyAddFirstRow += OnAddFirstRow;
        }

        public void AddDataGridColum(int index, string header)
        {
            var column = new DataGridTextColumn();
            column.Header = header;
            column.Binding = new Binding($"[{index}]");

            uiDataGrid.Columns.Add(column);
        }

        void OnAddFirstRow(List<string> row)
        {
            for(int i = 0; i < row.Count; i++)
            {
                var header = string.Empty;
                if(viewModel.ShowHeader)
                {
                    header = row[i];
                }
                AddDataGridColum(i, header);
            }
        }

        void OnToolbarRowToTabelClick(object? sender, RoutedEventArgs e)
        {
            var row = App.I.modelCSV.RowCellInfo(uiDataGrid.SelectedIndex);

            var rowToTableWnd = new RowToTableWindow
            {
                DataContext = new RowToTableViewModel { Row = row, WindowTitle=$"{row[0].Value}"}
            };

            rowToTableWnd.Show(this);
        }

        void OnToolbarFrozenColumn(object? sender, RoutedEventArgs e)
        {
            uiDataGrid.FrozenColumnCount = (sender as ToggleButton).IsChecked == true?1:0;
        }
    }
}
