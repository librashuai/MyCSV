using Avalonia.Collections;
using Avalonia.Controls;
using ReactiveUI;
using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace MyCSV.ViewModels
{
    public class MainWindowViewModel : ViewModelBase
    {
        public AvaloniaList<List<string>> CsvData { get; set; }

        public SearchControlViewModel SearchControlVM => new SearchControlViewModel(this);

        private bool showHeader;
        public bool ShowHeader
        {
            get => showHeader;
            set {
                App.I.modelCSV.ShowHeader = value;
                this.RaiseAndSetIfChanged(ref showHeader, value); 
            }
        }

        private string windowTitle = "MyCSV";
        public string WindowTitle
        {
            get => windowTitle;
            set => this.RaiseAndSetIfChanged(ref windowTitle, value);
        }

        private int selectedRow;
        public int SelectedRow
        {
            get => selectedRow;
            set { 
                this.RaiseAndSetIfChanged(ref selectedRow, value); 
                StatusLine = $"Row {value}"; 
            }
        }

        private string statusLine;
        public string StatusLine
        {
            get => statusLine;
            set => this.RaiseAndSetIfChanged(ref statusLine, value);
        }

        private string statusInfo;
        public string StatusInfo
        {
            get => statusInfo;
            set => this.RaiseAndSetIfChanged(ref statusInfo, value);
        }

        public Action<List<string>>? NotifyAddFirstRow;

        public MainWindowViewModel()
        {
            CsvData = new AvaloniaList<List<string>>();
            App.I.modelCSV.NotifyAddRow += OnAddRow;
            App.I.modelCSV.NotifyOpenedFile += (e) =>
            {
                WindowTitle = $"MyCSV {Path.GetFileName(e)}";
            };
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
