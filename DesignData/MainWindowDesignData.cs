using Avalonia.Collections;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyCSV.DesignData
{
    public class MainWindowDesignData
    {
        public AvaloniaList<List<string>> CsvData { get; set; }
        public bool ShowHeader { get; set; }

    }
}
