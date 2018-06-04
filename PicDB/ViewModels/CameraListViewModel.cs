using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using BIF.SWE2.Interfaces.ViewModels;

namespace PicDB.ViewModels
{
    public class CameraListViewModel : ICameraListViewModel
    {
        #region Singleton
        private static CameraListViewModel _instance;

        protected CameraListViewModel()
        {
            _bl.GetCameras().ToList().ForEach(cam => _cameras.Add(new CameraViewModel(cam)));
        }

        public static CameraListViewModel GetInstance()
        {
            if (_instance == null)
            {
                _instance = new CameraListViewModel();
            }

            return _instance;
        }

        #endregion
        private BusinessLayer _bl = BusinessLayer.GetInstance();


        private List<ICameraViewModel> _cameras = new List<ICameraViewModel>();
        public IEnumerable<ICameraViewModel> List
        {
            get => _cameras;
            set => _cameras = value.ToList();
        }

        public ICameraViewModel CurrentCamera { get; set; }
    }
}
