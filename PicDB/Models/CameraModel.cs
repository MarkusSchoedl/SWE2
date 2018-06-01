using BIF.SWE2.Interfaces.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BIF.SWE2.Interfaces.ViewModels;

namespace PicDB.Models
{
    public class CameraModel : ICameraModel
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="make"></param>
        /// <param name="producer"></param>
        public CameraModel(string producer, string make)
        {
            Make = make;
            Producer = producer;
        }

        /// <summary>
        /// 
        /// </summary>
        public CameraModel()
        {
        }

        public int ID { get; set; }

        public string Producer { get; set; }

        public string Make { get; set; }

        public DateTime? BoughtOn { get; set; }

        public string Notes { get; set; }

        public decimal ISOLimitGood { get; set; }

        public decimal ISOLimitAcceptable { get; set; }

        public void ApplyChanges(ICameraViewModel vmdl)
        {
            ID = vmdl.ID;
            Producer = vmdl.Producer;
            Make = vmdl.Make;
            BoughtOn = vmdl.BoughtOn;
            Notes = vmdl.Notes;
            ISOLimitGood = vmdl.ISOLimitGood;
            ISOLimitAcceptable = vmdl.ISOLimitAcceptable;
        }
    }
}
