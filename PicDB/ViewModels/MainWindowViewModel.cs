using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using BIF.SWE2.Interfaces.ViewModels;

namespace PicDB.ViewModels
{
    class MainWindowViewModel : IMainWindowViewModel
    {
        public IPictureViewModel CurrentPicture => new PictureViewModel();

        public IPictureListViewModel List => new PictureListViewModel();

        public ISearchViewModel Search => new SearchViewModel();
    }
}
