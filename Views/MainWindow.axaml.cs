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
        }

        private void MainWindow_DataContextChanged(object? sender, EventArgs e)
        {
            if (IsDesignPreview())
            {
                uiDataGrid.HeadersVisibility = DataGridHeadersVisibility.All;

                AddDataGridColum(0, "Name");
                AddDataGridColum(1, "Age");
                AddDataGridColum(2, "Gender");
                AddDataGridColum(3, "Phone");
                return;
            }

            viewModel = DataContext as MainWindowViewModel;
            if (viewModel == null)
                return;

            viewModel.NotifyAddFirstRow += OnAddFirstRow;
            
            this.uiTBShowHeader.Checked += UiTBShowHeader_Checked;
            this.uiTBShowHeader.Unchecked += UiTBShowHeader_Unchecked;

            this.uiDataGrid.SelectionChanged += UiDataGrid_SelectionChanged;

            this.uiSearchControl.DataContext = viewModel.SearchControlVM;
            this.uiSearchControl.NotifyFindCell += OnFindCell;
            
        }

        private void UiDataGrid_SelectionChanged(object? sender, SelectionChangedEventArgs e)
        {
            viewModel.SelectedRow = this.uiDataGrid.SelectedIndex;
        }

        bool IsDesignPreview()
        {
            return this.DataContext is DesignData.MainWindowDesignData;
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
            if (IsDesignPreview())
                return;

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

        void OnToolbarFrozenColumnIncrease(object? sender, RoutedEventArgs e)
        {
            if (uiDataGrid.FrozenColumnCount == uiDataGrid.Columns.Count)
                return;
            uiDataGrid.FrozenColumnCount += 1;
        }

        void OnToolbarFrozenColumnDecrease(object? sender, RoutedEventArgs e)
        {
            if (uiDataGrid.FrozenColumnCount == 1)
                return;
            uiDataGrid.FrozenColumnCount -= 1;
        }

        void OnToolbarSearch(object? sender, RoutedEventArgs e)
        {

        }

        void OnFindCell(int row, int column)
        {
            var index = 0;
            foreach(var item in uiDataGrid.Items)
            {
                if(index++ == row)
                {
                    uiDataGrid.ScrollIntoView(item, uiDataGrid.Columns[column]);
                    uiDataGrid.SelectedIndex = row;
                    uiDataGrid.CurrentColumn = uiDataGrid.Columns[column];
                    var cell = uiDataGrid.CurrentColumn.GetCellContent(item) as TextBlock;
                    var dataGridCell = cell.Parent as DataGridCell;
                    
                    dataGridCell.Focus();
                    uiDataGrid.Focus();
                    break;
                }
            }         
        }
    }
}
