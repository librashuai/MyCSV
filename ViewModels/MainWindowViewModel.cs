using Avalonia.Collections;
using Avalonia.Controls;
using ReactiveUI;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyCSV.ViewModels
{
    public class MainWindowViewModel : ViewModelBase
    {
        public AvaloniaList<List<string>> CsvData { get; set; }

        private bool showHeader;
        public bool ShowHeader
        {
            get => showHeader;
            set {
                App.I.modelCSV.ShowHeader = value;
                this.RaiseAndSetIfChanged(ref showHeader, value); 
            }
        }


        public Action<List<string>>? NotifyAddFirstRow;

        public MainWindowViewModel()
        {
            CsvData = new AvaloniaList<List<string>>();
            App.I.modelCSV.NotifyAddRow += OnAddRow;
        }

        async void MenuOpen()
        {
            var fileDialog = new OpenFileDialog();
            var filePaths = await fileDialog.ShowAsync(App.I.mainWindow);
            if(filePaths != null && filePaths.Length > 0 && !string.IsNullOrEmpty(filePaths[0]))
            {
                App.I.modelCSV.LoadCSV(filePaths[0]);
            }
        }

        void OnAddRow(List<string> row)
        {
            if(CsvData.Count == 0)
            {
                NotifyAddFirstRow?.Invoke(row);
            }
            CsvData.Add(row);
        }
    }
}
