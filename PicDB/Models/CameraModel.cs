using BIF.SWE2.Interfaces.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PicDB.Models
{
    class CameraModel : ICameraModel
    {
        public int ID { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public string Producer { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public string Make { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public DateTime? BoughtOn { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public string Notes { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public decimal ISOLimitGood { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public decimal ISOLimitAcceptable { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
    }
}
