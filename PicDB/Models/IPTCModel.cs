using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BIF.SWE2.Interfaces.Models;
using BIF.SWE2.Interfaces.ViewModels;
using PicDB.ViewModels;

namespace PicDB.Models
{
    class IPTCModel : IIPTCModel
    {
        public int ID { get; set; }

        public string Keywords { get; set; } = "";
        public string ByLine { get; set; } = "";
        public string CopyrightNotice { get; set; } = "";
        public string Headline { get; set; } = "";
        public string Caption { get; set; } = "";

        public void ApplyChanges(IIPTCViewModel vmdl)
        {
            Keywords = vmdl.Keywords;
            ByLine = vmdl.ByLine;
            CopyrightNotice = vmdl.CopyrightNotice;
            Headline = vmdl.Headline;
            Caption = vmdl.Caption;
        }
    }
}