using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BIF.SWE2.Interfaces.Models;
using BIF.SWE2.Interfaces.ViewModels;

namespace PicDB.ViewModels
{
    class PhotographerViewModel : IPhotographerViewModel
    {
        public PhotographerViewModel()
        {
        }

        public PhotographerViewModel(IPhotographerModel mdl)
        {
            if (mdl != null)
            {
                FirstName = mdl.FirstName;
                LastName = mdl.LastName;
                BirthDay = mdl.BirthDay;
                Notes = mdl.Notes;
                _ID = mdl.ID;
            }
        }

        private int _ID;
        public int ID { get => _ID; }

        private string _FirstName;
        public string FirstName { get => _FirstName; set => _FirstName = value; }

        private string _LastName;
        public string LastName { get => _LastName; set => _LastName = value; }

        private DateTime? _BirthDay;
        public DateTime? BirthDay { get => _BirthDay; set => _BirthDay = value; }

        private string _Notes;
        public string Notes { get => _Notes; set => _Notes = value; }

        private int _NumberOfPictures;
        public int NumberOfPictures { get => _NumberOfPictures; }

        public bool IsValid => IsValidBirthDay && IsValidLastName;
        
        public string ValidationSummary
        {
            get {
                string _ValidationSummary = "";

                if (!IsValidBirthDay)
                {
                    _ValidationSummary = "Not a valid BirthDay. ";
                }
                if(!IsValidLastName)
                {
                    _ValidationSummary = "Not a valid Last Name. ";
                }

                _ValidationSummary = String.IsNullOrEmpty(_ValidationSummary) ? null : _ValidationSummary;

                return _ValidationSummary;
            }
        }

        public bool IsValidLastName => !String.IsNullOrEmpty(_LastName);

        public bool IsValidBirthDay => BirthDay == null ? true : DateTime.Today > BirthDay;
    }
}
