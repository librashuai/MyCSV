using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyCSV.Models;

namespace MyCSV.DesignData
{
    public class RowToTableDesignData
    {
        private List<CellInfo> row = new List<CellInfo>
        {
            new CellInfo
            {
                Header = "Name",
                Description = "姓名",
                Value = "Bobo"
            },
            new CellInfo
            {
                Header = "Age",
                Description = "年龄",
                Value = "18"
            },
            new CellInfo
            {
                Header = "Gender",
                Description = "性别",
                Value = "Man"
            }
        };

        public List<CellInfo> Row => row;
    }
}
