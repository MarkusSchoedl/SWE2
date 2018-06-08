using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using BIF.SWE2.Interfaces.ViewModels;
using PicDB.Models;

namespace PicDB.ViewModels
{
    class PictureListViewModel : ViewModel, IPictureListViewModel
    {
        private IEnumerable<IPictureViewModel> _backupList;

        public PictureListViewModel()
        {
            var bl = BusinessLayer.GetInstance();
            var pics = bl.GetPictures().ToList();

            pics.ForEach(x =>
            {
                _list.Add(new PictureViewModel(x));
            });

            CurrentPicture = _list.FirstOrDefault();
        }

        private ObservableCollection<PictureViewModel> _list = new ObservableCollection<PictureViewModel>();

        private IPictureViewModel _currentPicture;
        public IPictureViewModel CurrentPicture
        {
            get => _currentPicture;
            set
            {
                _currentPicture = value;
                OnPropertyChanged(nameof(CurrentPicture));
            }
        }

        public IEnumerable<IPictureViewModel> List
        {
            get => _list;
            set
            {
                _list = (ObservableCollection<PictureViewModel>)value;
                OnPropertyChanged("List");
            }
        }

        public IEnumerable<IPictureViewModel> PrevPictures { get; set; }

        public IEnumerable<IPictureViewModel> NextPictures { get; set; }

        public int Count { get; set; }

        public int CurrentIndex { get; set; }

        public string CurrentPictureAsString { get; set; }

        public IPictureViewModel SetSearchList(IEnumerable<IPictureViewModel> list)
        {
            if (_backupList == null)
                _backupList = List;
            List = list;
            return List.FirstOrDefault();
        }

        public IPictureViewModel ResetSearch()
        {
            if (_backupList == null) return null;
            List = _backupList;
            _backupList = null;
            return List.FirstOrDefault();
        }
    }
}
