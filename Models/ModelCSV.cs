﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace MyCSV.Models
{
    public class CellInfo
    {
        public string Header { get; set; }
        public string Description { get; set; }
        public string Value { get; set; }
    }

    public class ModelCSV
    {
        List<List<string>> csvData = new List<List<string>>();

        public bool ShowHeader { get; set; }

        public delegate void DNotifyAddRow(List<string> row);

        public DNotifyAddRow? NotifyAddRow;

        public async void LoadCSV(string filePath)
        {
            csvData.Clear();
            csvData.Capacity = 0;

            var ext = Path.GetExtension(filePath);
            if(ext != ".csv")
            {
                return;
            }

            using(var file = File.OpenText(filePath))
            {
                while(true)
                {
                    var line = await file.ReadLineAsync();
                    if (line == null)
                        break;

                    var row = new List<string>(line.Split(','));
                    csvData.Add(row);
                    NotifyAddRow?.Invoke(row);
                }
            }
        }

        public List<CellInfo> RowCellInfo(int index)
        {
            var rowCellInfo = new List<CellInfo>();

            if (csvData.Count == 0)
                return rowCellInfo;

            if (index < 0 || index >= csvData.Count)
                return rowCellInfo;

            var firstRow = csvData[0];
            var targetRow = csvData[index];

            for (int i = 0; i < targetRow.Count; i++)
            {
                var cellInfo = new CellInfo
                {
                    Value = targetRow[i]
                };

                if (ShowHeader)
                {
                    cellInfo.Header = firstRow[i];
                }

                rowCellInfo.Add(cellInfo);
            }

            return rowCellInfo;
        }

        public List<string> Header()
        {
            if (csvData.Count == 0)
                return null;

            return csvData[0];
        }
    }
}
