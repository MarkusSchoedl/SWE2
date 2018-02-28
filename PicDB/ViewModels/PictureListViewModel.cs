using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using BIF.SWE2.Interfaces.ViewModels;

namespace PicDB.ViewModels
{
    class PictureListViewModel : IPictureListViewModel
    {
        public IPictureViewModel CurrentPicture => throw new NotImplementedException();

        public IEnumerable<IPictureViewModel> List => throw new NotImplementedException();

        public IEnumerable<IPictureViewModel> PrevPictures => throw new NotImplementedException();

        public IEnumerable<IPictureViewModel> NextPictures => throw new NotImplementedException();

        public int Count => throw new NotImplementedException();

        public int CurrentIndex => throw new NotImplementedException();

        public string CurrentPictureAsString => throw new NotImplementedException();
    }
}
