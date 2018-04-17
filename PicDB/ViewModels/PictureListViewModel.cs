using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using BIF.SWE2.Interfaces.ViewModels;

namespace PicDB.ViewModels
{
    class PictureListViewModel : ViewModel, IPictureListViewModel
    {
        public PictureListViewModel()
        {
            var pics = BusinessLayer.GetInstance().GetPictures().ToList();

            pics.ForEach(x => _list.Add(new PictureViewModel(x)));
        }

        private List<PictureViewModel> _list = new List<PictureViewModel>();

        public IPictureViewModel CurrentPicture { get; set; }

        public IEnumerable<IPictureViewModel> List
        {
            get => _list;
            set
            {
                _list = (List<PictureViewModel>)value;
                OnPropertyChanged("List");
            }
        }

        public IEnumerable<IPictureViewModel> PrevPictures { get; set; }

        public IEnumerable<IPictureViewModel> NextPictures { get; set; }

        public int Count { get; set; }

        public int CurrentIndex { get; set; }

        public string CurrentPictureAsString { get; set; }
    }
}
