using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BIF.SWE2.Interfaces.Models;
using BIF.SWE2.Interfaces.ViewModels;

namespace PicDB.Models
{
    class PictureModel : IPictureModel
    {
        #region Constructor

        public PictureModel(string filename)
        {
            FileName = filename;
        }

        public PictureModel()
        {
        }

        #endregion

        public void ApplyChanges(IPictureViewModel mdl)
        {
            ID = mdl.ID;
            FileName = mdl.FileName;
            IPTC = new IPTCModel();
            ((IPTCModel) IPTC).ApplyChanges(mdl.IPTC);
            EXIF = new EXIFModel();
            ((EXIFModel)EXIF).ApplyChanges(mdl.EXIF);
            Camera = mdl.Camera == null ? null : new CameraModel();
            ((CameraModel)Camera)?.ApplyChanges(mdl.Camera);
            Photographer = mdl.Photographer == null ? null : new PhotographerModel();
            ((PhotographerModel)Photographer)?.ApplyChanges(mdl.Photographer);
        }

        public int ID { get; set; }
        public string FileName { get; set; }
        public IIPTCModel IPTC { get; set; }
        public IEXIFModel EXIF { get; set; }
        public ICameraModel Camera { get; set; }
        public IPhotographerModel Photographer { get; set; }
    }
}