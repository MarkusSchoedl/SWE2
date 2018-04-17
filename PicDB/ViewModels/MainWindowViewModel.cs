using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using BIF.SWE2.Interfaces.ViewModels;

namespace PicDB.ViewModels
{
    class MainWindowViewModel : ViewModel, IMainWindowViewModel
    {
        private static BusinessLayer _bl = BusinessLayer.GetInstance();

        private IPictureViewModel _currentPicture = new PictureViewModel(_bl.GetPicture(0));
        private readonly IPictureListViewModel _list = new PictureListViewModel();
        private readonly ISearchViewModel _search = new SearchViewModel();

        public IPictureViewModel CurrentPicture
        {
            get { return _currentPicture; }
            set
            {
                if (_currentPicture != value)
                {
                    _currentPicture = value;
                    OnPropertyChanged("CurrentPicture");
                }

            }
        }

        public IPictureListViewModel List => _list;
        public ISearchViewModel Search => _search;
    }
}
