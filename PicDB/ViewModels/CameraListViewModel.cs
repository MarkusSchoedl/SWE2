 using System;
using System.Collections.Generic;
 using System.Collections.ObjectModel;
 using System.Linq;
using System.Text;
 using System.Windows;
 using BIF.SWE2.Interfaces.ViewModels;
 using PicDB.Models;

namespace PicDB.ViewModels
{
    public class MockCameraListViewModel : ViewModel, ICameraListViewModel
    {
        #region Singleton
        private static MockCameraListViewModel _instance;

        protected MockCameraListViewModel()
        {
            _bl.GetCameras().ToList().ForEach(cam => _cameras.Add(new CameraViewModel(cam)));
        }

        public static MockCameraListViewModel GetInstance()
        {
            if (_instance == null)
            {
                _instance = new MockCameraListViewModel();
            }

            return _instance;
        }

        #endregion

        private MockBusinessLayer _bl = MockBusinessLayer.GetInstance();
        
        private ObservableCollection<ICameraViewModel> _cameras = new ObservableCollection<ICameraViewModel>();
        public IEnumerable<ICameraViewModel> List
        {
            get => _cameras;
            private set => _cameras = value as ObservableCollection<ICameraViewModel>;
        }

        public ICameraViewModel CurrentCamera { get; set; }
    }
}
