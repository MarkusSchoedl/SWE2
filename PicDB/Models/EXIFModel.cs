using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BIF.SWE2.Interfaces;
using BIF.SWE2.Interfaces.Models;

namespace PicDB.Models
{
    class EXIFModel : IEXIFModel
    {
        public string Make { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public decimal FNumber { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public decimal ExposureTime { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public decimal ISOValue { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public bool Flash { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public ExposurePrograms ExposureProgram { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
    }
}
