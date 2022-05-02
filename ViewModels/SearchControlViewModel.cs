using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyCSV.Models;

namespace MyCSV.ViewModels
{
    internal class SearchControlViewModel:ViewModelBase
    {

        CellPosition StartCell { get; set; }


        public Action<CellPosition>? NotifyFindCell;

        void Search(string text)
        {
            var cell = App.I.modelCSV.FindCell(text, StartCell);
            if(cell != null)
            {
                StartCell = cell;
                NotifyFindCell?.Invoke(cell);
            }
        }

        void SearchFisrt(string text)
        {
            var cell = App.I.modelCSV.FindCell(text, null);
            if (cell != null)
            {
                StartCell = cell;
                NotifyFindCell?.Invoke(cell);
            }
        }
    }
}
