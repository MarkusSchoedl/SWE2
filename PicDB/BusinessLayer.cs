using BIF.SWE2.Interfaces;
using BIF.SWE2.Interfaces.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PicDB
{
    class BusinessLayer : IBusinessLayer
    {
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
            throw new NotImplementedException();
        }

        public IIPTCModel ExtractIPTC(string filename)
        {
            throw new NotImplementedException();
        }

        public ICameraModel GetCamera(int ID)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<ICameraModel> GetCameras()
        {
            throw new NotImplementedException();
        }

        public IPhotographerModel GetPhotographer(int ID)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<IPhotographerModel> GetPhotographers()
        {
            throw new NotImplementedException();
        }

        public IPictureModel GetPicture(int ID)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<IPictureModel> GetPictures()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<IPictureModel> GetPictures(string namePart, IPhotographerModel photographerParts, IIPTCModel iptcParts, IEXIFModel exifParts)
        {
            throw new NotImplementedException();
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
            throw new NotImplementedException();
        }

        public void WriteIPTC(string filename, IIPTCModel iptc)
        {
            throw new NotImplementedException();
        }
    }
}
