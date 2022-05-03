using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyCSV.Models;

namespace MyCSV.ViewModels
{
    public class SearchControlViewModel:ViewModelBase
    {
        MainWindowViewModel mainWindowVM;

        CellPosition StartCell { get; set; }


        public Action<CellPosition>? NotifyFindCell;

        public SearchControlViewModel(MainWindowViewModel mainWindowVM)
        {
            this.mainWindowVM = mainWindowVM;
        }

        void Search(string text)
        {
            var includeStart = StartCell == null;
            var cell = App.I.modelCSV.FindCell(text, StartCell, includeStart);
            if(cell != null)
            {
                StartCell = cell;
                NotifyFindCell?.Invoke(cell);
                mainWindowVM.StatusInfo = $"Find: {text}";
            }
            else
            {
                mainWindowVM.StatusInfo = $"Can't find: {text}";
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
                mainWindowVM.StatusInfo = $"Find: {text}";
            }
            else
            {
                mainWindowVM.StatusInfo = $"Can't find: {text}";
            }
        }

        void SearchFisrt(string text)
        {
            var cell = App.I.modelCSV.FindCell(text, null);
            if (cell != null)
            {
                StartCell = cell;
                NotifyFindCell?.Invoke(cell);
                mainWindowVM.StatusInfo = $"Find: {text}";
            }
            else
            {
                mainWindowVM.StatusInfo = $"Can't find: {text}";
            }
        }

        void SearchLast(string text)
        {
            var cell = App.I.modelCSV.FindCell(text, null, reverse:true);
            if (cell != null)
            {
                StartCell = cell;
                NotifyFindCell?.Invoke(cell);
                mainWindowVM.StatusInfo = $"Find: {text}";
            }
            else
            {
                mainWindowVM.StatusInfo = $"Can't find: {text}";
            }
        }
    }
}
