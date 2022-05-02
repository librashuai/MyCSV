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
            var includeStart = StartCell == null;
            var cell = App.I.modelCSV.FindCell(text, StartCell, includeStart);
            if(cell != null)
            {
                StartCell = cell;
                NotifyFindCell?.Invoke(cell);
            }
        }

        void SearchPrevious(string text)
        {
            var includeStart = StartCell == null;
            var cell = App.I.modelCSV.FindCell(text, StartCell, includeStart, reverse:true);
            if (cell != null)
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

        void SearchLast(string text)
        {
            var cell = App.I.modelCSV.FindCell(text, null, reverse:true);
            if (cell != null)
            {
                StartCell = cell;
                NotifyFindCell?.Invoke(cell);
            }
        }
    }
}
