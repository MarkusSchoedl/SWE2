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
            if (model != null)
            {
                Make = model.Make;
                FNumber = model.FNumber;
                ExposureTime = model.ExposureTime;
                ISOValue = model.ISOValue;
                Flash = model.Flash;
                ExposureProgram = model.ExposureProgram.ToString();
                ExposureProgramResource = model.ExposureProgram.ToString();
                Camera = new CameraViewModel();
                ISORatingResource = model.ISOValue.ToString();
            }
        }

        public string Make { get; set; }

        public decimal FNumber { get; set; }

        public decimal ExposureTime { get; set; }

        private decimal _ISOValue;
        public decimal ISOValue
        {
            get => _ISOValue;
            set
            {
                _ISOValue = value;
                if (value > 0 && value < 500)
                {
                    ISORating = ISORatings.Good;
                }
                else if (value > 0 && value < 1500)
                {
                    ISORating = ISORatings.Acceptable;
                }
                else if (value > 0 && value >= 1500)
                {
                    ISORating = ISORatings.Noisey;
                }
                else
                {
                    ISORating = ISORatings.NotDefined;
                }
            }
        }

        public bool Flash { get; set; }

        public string ExposureProgram { get; set; }

        public string ExposureProgramResource { get; set; }

        public ICameraViewModel Camera { get; set; }

        private ISORatings _ISORating;
        public ISORatings ISORating
        {
            get => _ISORating;
            set => _ISORating = value;
        }

        public string ISORatingResource { get; set; }
    }
}
