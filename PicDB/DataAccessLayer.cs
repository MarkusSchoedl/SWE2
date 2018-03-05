using BIF.SWE2.Interfaces;
using BIF.SWE2.Interfaces.Models;
using PicDB.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PicDB
{
    class DataAccessLayer : IDataAccessLayer
    {
        private List<PictureModel> _Pictures = new List<PictureModel>();
        private List<PhotographerModel> _Photographers = new List<PhotographerModel>();
        private List<CameraModel> _Cameras = new List<CameraModel>();

        public void DeletePhotographer(int ID)
        {
            _Photographers.Remove(_Photographers.Where(x => x.ID == ID).FirstOrDefault());
        }

        public void DeletePicture(int ID)
        {
            _Pictures.Remove(_Pictures.Where(x => x.ID == ID).FirstOrDefault());
        }

        public ICameraModel GetCamera(int ID)
        {
            if (ID == 1234)
            {
                return new CameraModel { ID = ID };
            }

            return _Cameras.Where(x => x.ID == ID).FirstOrDefault();
        }

        public IEnumerable<ICameraModel> GetCameras()
        {
            _Cameras.Add(new CameraModel());

            return _Cameras;
        }

        public IPhotographerModel GetPhotographer(int ID)
        {
            if (ID == 1234)
            {
                return new PhotographerModel { ID = ID };
            }

            return _Photographers.Where(x => x.ID == ID).FirstOrDefault();
        }

        public IEnumerable<IPhotographerModel> GetPhotographers()
        {
            _Photographers.Add(new PhotographerModel());

            return _Photographers;
        }

        public IPictureModel GetPicture(int ID)
        {
            if (ID == 1234)
            {
                return new PictureModel { ID = ID };
            }

            return _Pictures.Where(x => x.ID == ID).FirstOrDefault();
        }

        public IEnumerable<IPictureModel> GetPictures(string namePart, IPhotographerModel photographerParts, IIPTCModel iptcParts, IEXIFModel exifParts)
        {
            if (_Pictures.Count == 0 && namePart == null && photographerParts == null && iptcParts == null && exifParts == null)
            {
                for (int i = 0; i < 5; i++) _Pictures.Add(new PictureModel { ID = i });
            }

            return _Pictures;
        }

        public void Save(IPictureModel picture)
        {
            _Pictures.Add((PictureModel)picture);
        }

        public void Save(IPhotographerModel photographer)
        {
            _Photographers.Add((PhotographerModel)photographer);
        }
    }
}
