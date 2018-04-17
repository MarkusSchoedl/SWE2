using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using BIF.SWE2.Interfaces.Models;

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

        public int ID{ get; set; } 
        public string FileName{ get; set; } 
        public IIPTCModel IPTC{ get; set; } 
        public IEXIFModel EXIF{ get; set; } 
        public ICameraModel Camera{ get; set; } 
    }
}
