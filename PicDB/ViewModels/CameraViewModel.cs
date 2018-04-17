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
            if (model != null)
            {
                ID = model.ID;
                Producer = model.Producer;
                Make = model.Make;

                BoughtOn = model.BoughtOn;
                Notes = model.Notes;

                ISOLimitAcceptable = model.ISOLimitAcceptable;
                ISOLimitGood = model.ISOLimitGood;
            }
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

        public bool IsValid => IsValidBoughtOn && IsValidMake && IsValidProducer;

        public string ValidationSummary
        {
            get
            {
                string summary = "";

                if(!IsValidBoughtOn)
                {
                    summary += "The given Date is not valid. ";
                }
                if(!IsValidMake)
                {
                    summary += "The given Make is not valid. ";
                }
                if(!IsValidProducer)
                {
                    summary += "The given Producer is not valid. ";
                }

                summary = String.IsNullOrEmpty(summary) ? null : summary;

                return summary;
            }
        }

        public bool IsValidProducer => !String.IsNullOrEmpty(Producer);

        public bool IsValidMake => !String.IsNullOrEmpty(Make);

        public bool IsValidBoughtOn => BoughtOn == null ? true : DateTime.Today > BoughtOn;

        public decimal ISOLimitGood { get; set; }
        public decimal ISOLimitAcceptable { get; set; }

        public ISORatings TranslateISORating(decimal iso)
        {
            throw new NotImplementedException();
        }
    }
}
