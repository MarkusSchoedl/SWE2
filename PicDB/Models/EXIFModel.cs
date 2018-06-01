using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BIF.SWE2.Interfaces;
using BIF.SWE2.Interfaces.Models;
using BIF.SWE2.Interfaces.ViewModels;

namespace PicDB.Models
{
    class EXIFModel : IEXIFModel
    {
        public int ID { get; set; }

        public string Make { get; set; } = "";
        public decimal FNumber { get; set; }
        public decimal ExposureTime { get; set; }
        public decimal ISOValue { get; set; }
        public bool Flash { get; set; }
        public ExposurePrograms ExposureProgram { get; set; } = ExposurePrograms.NotDefined;

        public void ApplyChanges(IEXIFViewModel mdlExif)
        {
            Make = mdlExif.Make;
            FNumber = mdlExif.FNumber;
            ExposureTime = mdlExif.ExposureTime;
            ISOValue = mdlExif.ISOValue;
            Flash = mdlExif.Flash;
            if (Enum.TryParse(mdlExif.ExposureProgram, true, out ExposurePrograms temp))
            {
                ExposureProgram = temp;
            }
        }
    }
}
