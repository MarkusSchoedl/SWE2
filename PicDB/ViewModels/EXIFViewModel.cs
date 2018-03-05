using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BIF.SWE2.Interfaces;
using BIF.SWE2.Interfaces.ViewModels;
using PicDB.Models;

namespace PicDB.ViewModels
{
    class EXIFViewModel : IEXIFViewModel
    {
        public EXIFViewModel()
        {

        }

        public EXIFViewModel(EXIFModel model)
        {
            if(model != null)
            {
                Make = model.Make;
                FNumber = model.FNumber;
                ExposureTime = model.ExposureTime;
                ISOValue = model.ISOValue;
                Flash = model.Flash;
                ExposureProgram = model.ExposureProgram.ToString();
                ExposureProgramResource = model.ExposureProgram.ToString();
                Camera = new CameraViewModel();
                ISORating = new ISORatings();
                ISORatingResource = model.ISOValue.ToString();
            }
        }

        public string Make { get; set; }

        public decimal FNumber { get; set; }

        public decimal ExposureTime { get; set; }

        public decimal ISOValue { get; set; }

        public bool Flash { get; set; }

        public string ExposureProgram { get; set; }

        public string ExposureProgramResource { get; set; }

        public ICameraViewModel Camera { get; set; }

        public ISORatings ISORating { get; set; }

        public string ISORatingResource { get; set; }
    }
}
