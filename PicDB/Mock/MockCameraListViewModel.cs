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
    public class CameraListViewModel : ViewModel, ICameraListViewModel
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
        
        private ObservableCollection<ICameraViewModel> _cameras = new ObservableCollection<ICameraViewModel>();
        public IEnumerable<ICameraViewModel> List
        {
            get => _cameras;
            private set => _cameras = value as ObservableCollection<ICameraViewModel>;
        }

        public ICameraViewModel CurrentCamera { get; set; }

        #region Create Camera Window

        private CameraModel _newCamera = new CameraModel();
        public CameraModel NewCamera => _newCamera;
        private ICommandViewModel _saveCamera;
        public ICommandViewModel SaveCamera
        {
            get
            {
                if (_saveCamera == null)
                {
                    _saveCamera = new RelayCommandViewModel(
                        "Save Camera",
                        "Save Camera",
                        (window) =>
                        {
                            if (window.GetType().BaseType != typeof(Window))
                                throw new ArgumentException("Parameter must be type of window");

                            _bl.Save(_newCamera);
                            _cameras.Add(new CameraViewModel(_newCamera));
                            _newCamera = new CameraModel();

                            ((Window)window).Close();
                        },
                        () => true);
                }
                return _saveCamera;
            }
        }
        #endregion
    }
}
