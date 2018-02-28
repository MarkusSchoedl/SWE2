using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using BIF.SWE2.Interfaces.ViewModels;

namespace PicDB.ViewModels
{
    class MainWindowViewModel : IMainWindowViewModel
    {
        public IPictureViewModel CurrentPicture => throw new NotImplementedException();

        public IPictureListViewModel List => throw new NotImplementedException();

        public ISearchViewModel Search => throw new NotImplementedException();
    }
}
