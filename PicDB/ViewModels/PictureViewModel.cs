using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using BIF.SWE2.Interfaces.ViewModels;

namespace PicDB.ViewModels
{
    class PictureViewModel : IPictureViewModel
    {
        public int ID => throw new NotImplementedException();

        public string FileName => throw new NotImplementedException();

        public string FilePath => throw new NotImplementedException();

        public string DisplayName => throw new NotImplementedException();

        public IIPTCViewModel IPTC => throw new NotImplementedException();

        public IEXIFViewModel EXIF => throw new NotImplementedException();

        public IPhotographerViewModel Photographer => throw new NotImplementedException();

        public ICameraViewModel Camera => throw new NotImplementedException();
    }
}
