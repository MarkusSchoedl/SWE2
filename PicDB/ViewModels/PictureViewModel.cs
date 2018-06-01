using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using BIF.SWE2.Interfaces.Models;
using BIF.SWE2.Interfaces.ViewModels;
using PicDB.Models;
using PicDB.Properties;

namespace PicDB.ViewModels
{
    class PictureViewModel : IPictureViewModel
    {
        #region Constructor
        public PictureViewModel()
        {
        }

        public PictureViewModel(IPictureModel model)
        {
            ID = model.ID;

            IPTC = new IPTCViewModel((IPTCModel)model.IPTC);
            EXIF = new EXIFViewModel((EXIFModel)model.EXIF);
            if (model.Camera != null)
                Camera = new CameraViewModel((CameraModel)model.Camera);

            FileName = model.FileName;

            FilePath = Path.Combine(Directory.GetCurrentDirectory(), Resources.PictureFolder, FileName ?? "");
        }
        #endregion

        public int ID { get; set; }

        public string FileName { get; set; }

        public string FilePath { get; set; }

        public string DisplayName => FileName + " (by " + Photographer?.LastName + ")";

        public IIPTCViewModel IPTC { get; set; }

        public IEXIFViewModel EXIF { get; set; }

        public IPhotographerViewModel Photographer { get; set; }

        public ICameraViewModel Camera { get; set; }
    }
}
