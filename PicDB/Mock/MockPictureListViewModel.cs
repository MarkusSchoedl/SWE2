using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using BIF.SWE2.Interfaces.ViewModels;
using PicDB.Models;

namespace PicDB.ViewModels
{
    class MockPictureListViewModel : ViewModel, IPictureListViewModel
    {
        private IEnumerable<IPictureViewModel> _backupList;


        private ObservableCollection<PictureViewModel> _list = new ObservableCollection<PictureViewModel>();

        public IPictureViewModel CurrentPicture { get; set; }

        public IEnumerable<IPictureViewModel> List { get; set; }

        public IEnumerable<IPictureViewModel> PrevPictures { get; set; }

        public IEnumerable<IPictureViewModel> NextPictures { get; set; }

        public int Count { get; set; }

        public int CurrentIndex { get; set; }

        public string CurrentPictureAsString { get; set; }
    }
}
