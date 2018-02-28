using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BIF.SWE2.Interfaces;
using BIF.SWE2.Interfaces.ViewModels;

namespace PicDB.ViewModels
{
    class CameraViewModel : ICameraViewModel
    {
        public int ID => throw new NotImplementedException();

        public string Producer { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public string Make { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public DateTime? BoughtOn { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public string Notes { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public int NumberOfPictures => throw new NotImplementedException();

        public bool IsValid => throw new NotImplementedException();

        public string ValidationSummary => throw new NotImplementedException();

        public bool IsValidProducer => throw new NotImplementedException();

        public bool IsValidMake => throw new NotImplementedException();

        public bool IsValidBoughtOn => throw new NotImplementedException();

        public decimal ISOLimitGood { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public decimal ISOLimitAcceptable { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public ISORatings TranslateISORating(decimal iso)
        {
            throw new NotImplementedException();
        }
    }
}
