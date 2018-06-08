using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using BIF.SWE2.Interfaces.Models;
using BIF.SWE2.Interfaces.ViewModels;

namespace PicDB.Models
{
    public class PhotographerModel : IPhotographerModel
    {
        public int ID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime? BirthDay { get; set; }
        public string Notes { get; set; }

        public void ApplyChanges(IPhotographerViewModel photographer)
        {
            ID = photographer.ID;
            FirstName = photographer.FirstName;
            LastName = photographer.LastName;
            BirthDay = photographer.BirthDay;
            Notes = photographer.Notes;
        }
    }
}
