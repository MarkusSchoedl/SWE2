using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using BIF.SWE2.Interfaces.ViewModels;

namespace PicDB.ViewModels
{
    class PhotographerViewModel : IPhotographerViewModel
    {
        public int ID => throw new NotImplementedException();

        public string FirstName { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public string LastName { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public DateTime? BirthDay { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public string Notes { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public int NumberOfPictures => throw new NotImplementedException();

        public bool IsValid => throw new NotImplementedException();

        public string ValidationSummary => throw new NotImplementedException();

        public bool IsValidLastName => throw new NotImplementedException();

        public bool IsValidBirthDay => throw new NotImplementedException();
    }
}
