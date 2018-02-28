using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using BIF.SWE2.Interfaces.Models;

namespace PicDB.Models
{
    class PictureModel : IPictureModel
    {
        public int ID { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public string FileName { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public IIPTCModel IPTC { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public IEXIFModel EXIF { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public ICameraModel Camera { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
    }
}
