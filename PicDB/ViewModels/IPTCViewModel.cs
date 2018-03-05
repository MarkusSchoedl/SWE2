using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using BIF.SWE2.Interfaces.ViewModels;
using PicDB.Models;

namespace PicDB.ViewModels
{
    class IPTCViewModel : IIPTCViewModel
    {
        public IPTCViewModel()
        {

        }
        public IPTCViewModel(IPTCModel model)
        {
            if (model != null)
            {
                ByLine = model.ByLine;
                Headline = model.Headline;
                Caption = model.Caption;
                Keywords = model.Keywords;
                CopyrightNotices = model.CopyrightNotice.Split(',');
                CopyrightNotice = model.CopyrightNotice;
            }
        }

        public string Keywords{ get; set; }
        public string ByLine{ get; set; }
        public string CopyrightNotice{ get; set; }

        public IEnumerable<string> CopyrightNotices { get; set; }

        public string Headline{ get; set; }
        public string Caption{ get; set; }
    }
}
