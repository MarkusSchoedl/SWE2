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

        private string _firstName;
        public string FirstName { get => _firstName; set => _firstName = value; }

        private string _lastName;
        public string LastName { get => _lastName; set => _lastName = value; }

        private DateTime? _birthDay;
        public DateTime? BirthDay { get => _birthDay; set => _birthDay = value; }

        private string _notes;
        public string Notes { get => _notes; set => _notes = value; }

        private int _numberOfPictures;
        public int NumberOfPictures { get => _numberOfPictures; }

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

        public bool IsValidLastName => !String.IsNullOrEmpty(_lastName);

        public bool IsValidBirthDay => BirthDay == null || DateTime.Today > BirthDay;
    }
}
