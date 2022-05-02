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
        List<List<string>> CsvData => new List<List<string>>
        {
            new List<string>{"Name",    "Age",  "Gender",   "Phone"},
            new List<string>{"Alice",   "18",   "Female",   "11111111"},
            new List<string>{"Bobo",    "19",   "Male",     "22222222"},
            new List<string>{"Jack",    "20",   "Male",     "33333333"},
        };
        public bool ShowHeader { get; set; }

        public string StatusInfo => "This is status information.";
    }
}
