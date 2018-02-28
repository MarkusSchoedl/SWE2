using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using BIF.SWE2.Interfaces.ViewModels;

namespace PicDB.ViewModels
{
    class SearchViewModel : ISearchViewModel
    {
        public string SearchText { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public bool IsActive => throw new NotImplementedException();

        public int ResultCount => throw new NotImplementedException();
    }
}
