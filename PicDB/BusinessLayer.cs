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
        DataAccessLayer _DAL = new DataAccessLayer();

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
                return new EXIFModel {ExposureTime = 1, FNumber = 1, ISOValue = 1, Make = "make" };
            }

            throw new NotImplementedException();
        }

        public IIPTCModel ExtractIPTC(string filename)
        {
            if (filename == "Img1.jpg")
            {
                return new IPTCModel {  };
            }

            throw new NotImplementedException();
        }

        public ICameraModel GetCamera(int ID)
        {
            return _DAL.GetCamera(ID);
        }

        public IEnumerable<ICameraModel> GetCameras()
        {
            return _DAL.GetCameras();
        }

        public IPhotographerModel GetPhotographer(int ID)
        {
            return _DAL.GetPhotographer(ID);
        }

        public IEnumerable<IPhotographerModel> GetPhotographers()
        {
            return _DAL.GetPhotographers();
        }

        public IPictureModel GetPicture(int ID)
        {
            return _DAL.GetPicture(ID);
        }

        public IEnumerable<IPictureModel> GetPictures()
        {
            return _DAL.GetPictures(null, null, null, null);
        }

        public IEnumerable<IPictureModel> GetPictures(string namePart, IPhotographerModel photographerParts, IIPTCModel iptcParts, IEXIFModel exifParts)
        {
            return _DAL.GetPictures(namePart, photographerParts, iptcParts, exifParts);
        }

        public void Save(IPictureModel picture)
        {
            throw new NotImplementedException();
        }

        public void Save(IPhotographerModel photographer)
        {
            throw new NotImplementedException();
        }

        public void Sync()
        {
            //throw new NotImplementedException();
        }

        public void WriteIPTC(string filename, IIPTCModel iptc)
        {
            throw new NotImplementedException();
        }
    }
}
