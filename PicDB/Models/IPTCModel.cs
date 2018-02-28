using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using BIF.SWE2.Interfaces.Models;

namespace PicDB.Models
{
    class IPTCModel : IIPTCModel
    {
        public string Keywords { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public string ByLine { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public string CopyrightNotice { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public string Headline { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public string Caption { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
    }
}
