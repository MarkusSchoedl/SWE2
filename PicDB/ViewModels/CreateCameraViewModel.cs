using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using PicDB.Models;

namespace PicDB
{
    public class CreateCameraViewModel : ViewModel
    {
        private BusinessLayer _bl = BusinessLayer.GetInstance();

        public CameraModel NewCamera { get; set; } = new CameraModel();

        private ICommandViewModel _saveCamera;
        public ICommandViewModel SaveCamera
        {
            get
            {
                if (_saveCamera == null)
                {
                    _saveCamera = new SimpleCommandViewModel(
                        "Save Camera",
                        "Save Camera",
                        () =>
                        {
                            _bl.Save(NewCamera);
                        },
                        () => true);
                }
                return _saveCamera;
            }
        }
    }
}
