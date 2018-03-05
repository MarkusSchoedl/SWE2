using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using BIF.SWE2.Interfaces.ViewModels;
using PicDB.Models;

namespace PicDB.ViewModels
{
    class PictureViewModel : IPictureViewModel
    {
        #region Constructor
        public PictureViewModel()
        {
        }

        public PictureViewModel(PictureModel model)
        {
            ID = model.ID;
            
            IPTC = new IPTCViewModel();
            EXIF = new EXIFViewModel();
            Camera = new CameraViewModel();

            FileName = model.FileName;
        }
        #endregion

        public int ID { get; set; }

        public string FileName { get; set; }

        public string FilePath { get; set; }

        public string DisplayName
        {
            get
            {
                return FileName + " (by " + Photographer?.LastName + ")";
            }
        }

        public IIPTCViewModel IPTC { get; set; }

        public IEXIFViewModel EXIF { get; set; }

        public IPhotographerViewModel Photographer { get; set; }

        public ICameraViewModel Camera { get; set; }
    }
}
