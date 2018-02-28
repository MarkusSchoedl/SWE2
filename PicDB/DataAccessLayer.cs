using BIF.SWE2.Interfaces;
using BIF.SWE2.Interfaces.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PicDB
{
    class DataAccessLayer : IDataAccessLayer
    {
        public void DeletePhotographer(int ID)
        {
            throw new NotImplementedException();
        }

        public void DeletePicture(int ID)
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
    }
}
