using BIF.SWE2.Interfaces.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PicDB.Models
{
    class CameraModel : ICameraModel
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

        private int _id;
        private string _producer;
        private string _make;
        private DateTime? _boughtOn;
        private string _notes;
        private decimal _isoLimitGood;
        private decimal _isoLimitAcceptable;


        public int ID { get => _id; set => _id = value; }
        public string Producer { get => _producer; set => _producer = value; }
        public string Make { get => _make; set => _make = value; }
        public DateTime? BoughtOn { get => _boughtOn; set => _boughtOn = value; }
        public string Notes { get => _notes; set => _notes = value; }
        public decimal ISOLimitGood { get => _isoLimitGood; set => _isoLimitGood = value; }
        public decimal ISOLimitAcceptable { get => _isoLimitAcceptable; set => _isoLimitAcceptable = value; }
    }
}
