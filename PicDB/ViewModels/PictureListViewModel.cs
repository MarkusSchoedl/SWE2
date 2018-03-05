using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using BIF.SWE2.Interfaces.ViewModels;

namespace PicDB.ViewModels
{
    class PictureListViewModel : IPictureListViewModel
    {
        public IPictureViewModel CurrentPicture { get; set; }

        public IEnumerable<IPictureViewModel> List { get; set; }

        public IEnumerable<IPictureViewModel> PrevPictures { get; set; }

        public IEnumerable<IPictureViewModel> NextPictures { get; set; }

        public int Count { get; set; }

        public int CurrentIndex { get; set; }

        public string CurrentPictureAsString { get; set; }
    }
}
