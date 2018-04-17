using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using BIF.SWE2.Interfaces.Models;

namespace PicDB.Models
{
    class IPTCModel : IIPTCModel
    {
        public string Keywords { get; set; } = "";
        public string ByLine { get; set; } = "";
        public string CopyrightNotice { get; set; } = "";
        public string Headline { get; set; } = "";
        public string Caption { get; set; } = "";
    }
}
