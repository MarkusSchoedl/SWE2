using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BIF.SWE2.Interfaces;
using BIF.SWE2.Interfaces.Models;
using BIF.SWE2.Interfaces.ViewModels;
using PicDB.Models;

namespace PicDB.ViewModels
{
    class CameraViewModel : ICameraViewModel
    {
        public CameraViewModel(ICameraModel model)
        {
            Producer = model.Producer;
            Make = model.Make;
            
        }

        public CameraViewModel()
        {
        }

        public int ID { get; set; }

        public string Producer { get; set; }
        public string Make { get; set; }
        public DateTime? BoughtOn { get; set; }
        public string Notes { get; set; }

        public int NumberOfPictures { get; set; }

        public bool IsValid { get; set; }

        public string ValidationSummary { get; set; }

        public bool IsValidProducer { get; set; }

        public bool IsValidMake { get; set; }

        public bool IsValidBoughtOn { get; set; }

        public decimal ISOLimitGood { get; set; }
        public decimal ISOLimitAcceptable { get; set; }

        public ISORatings TranslateISORating(decimal iso)
        {
            throw new NotImplementedException();
        }
    }
}
