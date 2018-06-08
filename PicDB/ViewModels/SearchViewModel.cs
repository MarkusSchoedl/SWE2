using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BIF.SWE2.Interfaces.Models;
using BIF.SWE2.Interfaces.ViewModels;
using PicDB.Models;

namespace PicDB.ViewModels
{
    class SearchViewModel : ViewModel, ISearchViewModel
    {
        private string _searchText;
        public string SearchText
        {
            get => _searchText;
            set
            {
                _searchText = value;
                IsActive = !string.IsNullOrWhiteSpace(_searchText);
            }
        }

        public bool IsActive { get; set; }

        public int ResultCount { get; set; }

        private IPhotographerModel _photographer = new PhotographerModel();
        public IPhotographerModel Photographer
        {
            get { return _photographer; }
            set { _photographer = value; }
        }

        private IEXIFModel _exifModel = new EXIFModel();
        public IEXIFModel EXIF
        {
            get { return _exifModel; }
            set { _exifModel = value; }
        }

        private IIPTCModel _iptcModel = new IPTCModel();
        public IIPTCModel IPTC
        {
            get { return _iptcModel; }
            set { _iptcModel = value; }
        }

        public void ResetTextFields()
        {
            _iptcModel = new IPTCModel();
            _exifModel = new EXIFModel();
            _photographer = new PhotographerModel();

            OnPropertyChanged(nameof(Photographer));
            OnPropertyChanged(nameof(EXIF));
            OnPropertyChanged(nameof(IPTC));
        }
    }
}
