using BIF.SWE2.Interfaces;
using BIF.SWE2.Interfaces.Models;
using PicDB.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text;
using PicDB.Properties;

namespace PicDB
{
    class MockDataAccessLayer : IDataAccessLayer
    {
        private List<CameraModel> _Cameras = new List<CameraModel>();
        private List<PictureModel> _Pictures = new List<PictureModel>();
        private List<PhotographerModel> _Photographers = new List<PhotographerModel>();

        #region Camera
        public ICameraModel GetCamera(int id)
        {
            if (id == 1234)
            {
                return new CameraModel { ID = id };
            }

            return _Cameras.FirstOrDefault(x => x.ID == id);
        }

        public IEnumerable<ICameraModel> GetCameras()
        {
            _Cameras.Add(new CameraModel());

            return _Cameras;
        }
        #endregion 

        #region Picture
        public IPictureModel GetPicture(int id)
        {
            if (id == 1234)
            {
                return new PictureModel { ID = id };
            }

            return _Pictures.FirstOrDefault(x => x.ID == id);
        }
        
        public IEnumerable<IPictureModel> GetPictures(string namePart, IPhotographerModel photographerParts, IIPTCModel iptcParts, IEXIFModel exifParts)
        {
            if (_Pictures.Count == 0 && namePart == null && photographerParts == null && iptcParts == null && exifParts == null)
            {
                for (int i = 0; i < 5; i++) _Pictures.Add(new PictureModel { ID = i });
            }

            if (namePart != null)
            {
                _Pictures.Add(new PictureModel(namePart));
            }

            return _Pictures;
        }
        
        public void DeletePicture(int id)
        {
            _Pictures.Remove(_Pictures.FirstOrDefault(x => x.ID == id));
        }

        public void Save(IPictureModel picture)
        {
            picture.ID = 1234;

            _Pictures.Add((PictureModel)picture);
        }
        #endregion

        #region EXIF & IPTC
        private IIPTCModel GetIptc(int id)
        {
            throw new NotImplementedException();
        }

        private IEXIFModel GetExif(int id)
        {
            throw new NotImplementedException();
        }
        #endregion

        #region Photographer
        public IPhotographerModel GetPhotographer(int id)
        {
            if (id == 1234)
            {
                return new PhotographerModel { ID = id };
            }

            return _Photographers.FirstOrDefault(x => x.ID == id);
        }

        public IEnumerable<IPhotographerModel> GetPhotographers()
        {
            _Photographers.Add(new PhotographerModel());

            return _Photographers;
        }

        public void Save(IPhotographerModel photographer)
        {
            photographer.ID = 1;
            _Photographers.Add((PhotographerModel)photographer);
        }
        
        public void DeletePhotographer(int id)
        {
            _Photographers.Remove(_Photographers.FirstOrDefault(x => x.ID == id));
        }
        #endregion
    }
}
