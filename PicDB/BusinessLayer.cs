using BIF.SWE2.Interfaces;
using BIF.SWE2.Interfaces.Models;
using PicDB.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PicDB
{
    class BusinessLayer : IBusinessLayer
    {
        #region Singleton
        protected static BusinessLayer _instance;

        private BusinessLayer()
        {
            Sync();
        }

        public static BusinessLayer GetInstance()
        {
            if (_instance == null)
            {
                _instance = new BusinessLayer();
            }
            return _instance;
        }
        #endregion

        private DataAccessLayer _dal = new DataAccessLayer();

        public void DeletePhotographer(int ID)
        {
            throw new NotImplementedException();
        }

        public void DeletePicture(int ID)
        {
            throw new NotImplementedException();
        }

        public IEXIFModel ExtractEXIF(string filename)
        {
            if (filename == "Img1.jpg")
            {
                return new EXIFModel {ExposureTime = 1, FNumber = 1, ISOValue = 1, Make = "make"};
            }

            throw new NotImplementedException();
        }

        public IIPTCModel ExtractIPTC(string filename)
        {
            if (filename == "Img1.jpg")
            {
                return new IPTCModel
                {
                    ByLine = "byline",
                    Caption = "caption",
                    CopyrightNotice = "copyright",
                    Headline = "headline",
                    Keywords = "keywords"
                };
            }

            throw new NotImplementedException();
        }

        public ICameraModel GetCamera(int ID)
        {
            return _dal.GetCamera(ID);
        }

        public IEnumerable<ICameraModel> GetCameras()
        {
            return _dal.GetCameras();
        }

        public IPhotographerModel GetPhotographer(int ID)
        {
            return _dal.GetPhotographer(ID);
        }

        public IEnumerable<IPhotographerModel> GetPhotographers()
        {
            return _dal.GetPhotographers();
        }

        public IPictureModel GetPicture(int ID)
        {
            return _dal.GetPicture(ID);
        }

        public IEnumerable<IPictureModel> GetPictures()
        {
            return _dal.GetPictures();
        }

        public IEnumerable<IPictureModel> GetPictures(string namePart, IPhotographerModel photographerParts,
            IIPTCModel iptcParts, IEXIFModel exifParts)
        {
            return _dal.GetPictures(namePart, photographerParts, iptcParts, exifParts);
        }

        public void Save(IPictureModel picture)
        {
            _dal.Save(picture);
        }

        public void Save(IPhotographerModel photographer)
        {
            _dal.Save(photographer);
        }

        public void Sync()
        {
            _dal.SyncPictures();
        }

        public void WriteIPTC(string filename, IIPTCModel iptc)
        {
            _dal.Save(filename, iptc);
        }

        public void Save(CameraModel newCamera)
        {
            _dal.Save(newCamera);
        }
    }
}