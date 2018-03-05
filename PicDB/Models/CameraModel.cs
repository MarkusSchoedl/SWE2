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

        private int _ID;
        private string _Producer;
        private string _Make;
        private DateTime? _BoughtOn;
        private string _Notes;
        private decimal _ISOLimitGood;
        private decimal _ISOLimitAcceptable;


        public int ID { get => _ID; set => _ID = value; }
        public string Producer { get => _Producer; set => _Producer = value; }
        public string Make { get => _Make; set => _Make = value; }
        public DateTime? BoughtOn { get => _BoughtOn; set => _BoughtOn = value; }
        public string Notes { get => _Notes; set => _Notes = value; }
        public decimal ISOLimitGood { get => _ISOLimitGood; set => _ISOLimitGood = value; }
        public decimal ISOLimitAcceptable { get => _ISOLimitAcceptable; set => _ISOLimitAcceptable = value; }
    }
}
