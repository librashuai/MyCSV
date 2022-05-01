using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyCSV.Models;

namespace MyCSV.ViewModels
{
    public class RowToTableViewModel: ViewModelBase
    {

        public int SelectedIndex { get; set; }

        public List<CellInfo> Row
        {
            get;set;
        }

        public string WindowTitle { get; set; }



        void CopySelectedHeader()
        {
            if(SelectedIndex != -1)
            {
                App.Current.Clipboard.SetTextAsync(Row[SelectedIndex].Header);
            }
        }

        void CopySelectedValue()
        {
            if (SelectedIndex != -1)
            {
                App.Current.Clipboard.SetTextAsync(Row[SelectedIndex].Value);
            }
        }
    }
}
