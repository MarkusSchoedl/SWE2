using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BIF.SWE2.Interfaces;
using BIF.SWE2.Interfaces.Models;
using BIF.SWE2.Interfaces.ViewModels;
using PicDB;
using PicDB.Models;
using PicDB.ViewModels;

namespace Uebungen
{
    public class UEB2 : IUEB2
    {
        public void HelloWorld()
        {
        }

        public IBusinessLayer GetBusinessLayer()
        {
            return MockBusinessLayer.GetInstance();
        }

        public IMainWindowViewModel GetMainWindowViewModel()
        {
            return new MockMainWindowViewModel();
        }

        public IPictureModel GetPictureModel(string filename)
        {
            return new PictureModel(filename);
        }

        public IPictureViewModel GetPictureViewModel(BIF.SWE2.Interfaces.Models.IPictureModel mdl)
        {
            return new MockPictureViewModel((PictureModel)mdl);
        }

        public void TestSetup(string picturePath)
        {
            //throw new NotImplementedException();
        }

        public ICameraModel GetCameraModel(string producer, string make)
        {
            return new CameraModel(producer, make);
        }

        public ICameraViewModel GetCameraViewModel(ICameraModel mdl)
        {
            return new CameraViewModel(mdl);
        }
    }
}
