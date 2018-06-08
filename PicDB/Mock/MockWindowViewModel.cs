using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using BIF.SWE2.Interfaces.ViewModels;

namespace PicDB.ViewModels
{
    class MockMainWindowViewModel : IMainWindowViewModel
    {
        private static MockBusinessLayer _bl = MockBusinessLayer.GetInstance();

        private IPictureViewModel _currentPicture = new PictureViewModel();
        private IPictureListViewModel _list = new MockPictureListViewModel();
        private ISearchViewModel _search = new SearchViewModel();

        public IPictureViewModel CurrentPicture => _currentPicture;
        public IPictureListViewModel List => _list;
        public ISearchViewModel Search => _search;
    }
}
