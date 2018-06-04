using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using BIF.SWE2.Interfaces.Models;
using BIF.SWE2.Interfaces.ViewModels;
using PicDB.Models;
using PicDB.Properties;

namespace PicDB.ViewModels
{
    class PictureViewModel : ViewModel, IPictureViewModel
    {
        #region Constructor
        public PictureViewModel()
        {
        }

        public PictureViewModel(IPictureModel model)
        {
            ID = model.ID;

            IPTC = new IPTCViewModel((IPTCModel)model.IPTC);
            EXIF = new EXIFViewModel((EXIFModel)model.EXIF);

            if (model.Camera != null)
                Camera = CameraListViewModel.GetInstance().List.FirstOrDefault(x => x.ID == model.Camera.ID);

            if (((PictureModel)model).Photographer != null)
            {
                var pList = PhotographerListViewModel.GetInstance().List;

                Photographer = pList.FirstOrDefault(p => p.ID == ((PictureModel) model).Photographer.ID);
            }

            FileName = model.FileName;

            FilePath = Path.Combine(Directory.GetCurrentDirectory(), Resources.PictureFolder, FileName ?? "");
        }
        #endregion

        public int ID { get; set; }

        public string FileName { get; set; }

        public string FilePath { get; set; }

        public string DisplayName => FileName + " (by " + Photographer?.LastName + ")";

        public IIPTCViewModel IPTC { get; set; }

        public IEXIFViewModel EXIF { get; set; }

        private IPhotographerViewModel _photographer;
        public IPhotographerViewModel Photographer
        {
            get { return _photographer; }
            set
            {
                if (_photographer != value)
                {
                    _photographer = value;
                    OnPropertyChanged("Photographer");
                    OnPropertyChanged("DisplayName");
                }
            }
        }

        public ICameraViewModel Camera { get; set; }
    }
}
