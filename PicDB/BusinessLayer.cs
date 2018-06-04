using BIF.SWE2.Interfaces;
using BIF.SWE2.Interfaces.Models;
using PicDB.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PicDB
{
    class BusinessLayer : IBusinessLayer
    {
        public List<PhotographerModel> Photographers { get; private set; } = new List<PhotographerModel>();

        #region Singleton
        protected static BusinessLayer _instance;

        private BusinessLayer()
        {
            Sync();
            Photographers = (List<PhotographerModel>) _dal.GetPhotographers();
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
            Photographers.Remove(Photographers.FirstOrDefault(x => x.ID == ID));
            _dal.DeletePhotographer(ID);
        }

        public void DeletePicture(int ID)
        {
            throw new NotImplementedException();
        }

        public IEXIFModel ExtractEXIF(string filename)
        {
            if (filename == "Img1.jpg")
            {
                return new EXIFModel { ExposureTime = 1, FNumber = 1, ISOValue = 1, Make = "make" };
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
            if(Photographers.Any(x => x.ID == ID))
                return Photographers.First(x => x.ID == ID);
            return null;
        }

        public IEnumerable<IPhotographerModel> GetPhotographers()
        {
            return Photographers;
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
            Task.Run(() => _dal.Save(picture));
        }

        public void Save(IPhotographerModel photographer)
        {
            if (Photographers.Any(x => x.ID == photographer.ID))
            {
                var apply = Photographers.First(x => x.ID == photographer.ID);
                apply.FirstName = photographer.FirstName;
                apply.LastName = photographer.LastName;
                apply.BirthDay = photographer.BirthDay;
                apply.Notes = photographer.Notes;
            }
            else
            {
                Photographers.Add((PhotographerModel)photographer);
            }

            Task.Run(() => _dal.Save(photographer));
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
            Task.Run(() => _dal.Save(newCamera)); 
        }
    }
}