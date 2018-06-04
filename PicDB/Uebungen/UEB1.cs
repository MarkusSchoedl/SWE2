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
    public class UEB1 : IUEB1
    {
        public IApplication GetApplication()
        {
            return new App();
        }

        public void HelloWorld()
        {
            // I'm fine
        }

        public IDataAccessLayer GetAnyDataAccessLayer()
        {
            return new MockDataAccessLayer();
        }

        public IBusinessLayer GetBusinessLayer()
        {
            return MockBusinessLayer.GetInstance();
        }

        public IEXIFModel GetEmptyEXIFModel()
        {
            return new EXIFModel();
        }

        public IEXIFViewModel GetEmptyEXIFViewModel()
        {
            return new EXIFViewModel();
        }

        public IIPTCModel GetEmptyIPTCModel()
        {
            return new IPTCModel();
        }

        public IIPTCViewModel GetEmptyIPTCViewModel()
        {
            return new IPTCViewModel();
        }

        public IMainWindowViewModel GetEmptyMainWindowViewModel()
        {
            return new MockMainWindowViewModel();
        }

        public IPhotographerListViewModel GetEmptyPhotographerListViewModel()
        {
            return PhotographerListViewModel.GetInstance();
        }

        public IPhotographerModel GetEmptyPhotographerModel()
        {
            return new PhotographerModel();
        }

        public IPhotographerViewModel GetEmptyPhotographerViewModel()
        {
            return new PhotographerViewModel();
        }

        public IPictureListViewModel GetEmptyPictureListViewModel()
        {
            return new PictureListViewModel();
        }

        public IPictureModel GetEmptyPictureModel()
        {
            return new PictureModel();
        }

        public IPictureViewModel GetEmptyPictureViewModel()
        {
            return new PictureViewModel();
        }

        public ISearchViewModel GetEmptySearchViewModel()
        {
            return new SearchViewModel();
        }

        public void TestSetup(string picturePath)
        {
            //throw new NotImplementedException();
        }

        public ICameraModel GetEmptyCameraModel()
        {
            return new CameraModel();
        }

        public ICameraListViewModel GetEmptyCameraListViewModel()
        {
            return CameraListViewModel.GetInstance();
        }

        public ICameraViewModel GetEmptyCameraViewModel()
        {
            return new CameraViewModel();
        }
    }
}
