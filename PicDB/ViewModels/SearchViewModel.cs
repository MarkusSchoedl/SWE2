using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using BIF.SWE2.Interfaces.ViewModels;

namespace PicDB.ViewModels
{
    class SearchViewModel : ISearchViewModel
    {
        private string _SearchText;
        public string SearchText
        {
            get => _SearchText;
            set
            {
                _SearchText = value;
                IsActive = String.IsNullOrWhiteSpace(_SearchText) ? false : true;
            }
        }

        public bool IsActive { get; set; }

        public int ResultCount { get; set; }
    }
}
