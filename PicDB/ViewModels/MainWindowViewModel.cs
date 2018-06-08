using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Windows;
using BIF.SWE2.Interfaces.ViewModels;
using PicDB.Models;

namespace PicDB.ViewModels
{
    public class MainWindowViewModel : ViewModel, IMainWindowViewModel
    {
        private readonly BusinessLayer _bl = BusinessLayer.GetInstance();

        public MainWindowViewModel()
        {
            _currentPicture = List.CurrentPicture;
            
            if (!_bl.GetPictures().Any())
            {
                MessageBox.Show("The Pictures Folder didnt contain any images. Add images and restart the app.", "PictureDB: Error", MessageBoxButton.OK, MessageBoxImage.Exclamation);

                // Shutdown the application.
                Application.Current.Shutdown();
            }
        }
        
        private IPictureViewModel _currentPicture;
        public IPictureViewModel CurrentPicture
        {
            get { return _currentPicture; }
            set
            {
                if (_currentPicture != value)
                {
                    if (_currentPicture != null)
                    {
                        var picModel = new PictureModel();
                        picModel.ApplyChanges(_currentPicture);
                        _bl.Save(picModel);
                    }

                    _currentPicture = value;
                    OnPropertyChanged(nameof(CurrentPicture));
                }
            }
        }

        public IPictureListViewModel List { get; } = new PictureListViewModel();
        public ISearchViewModel Search { get; } = new SearchViewModel();

        public IPhotographerListViewModel Photographers { get; } = PhotographerListViewModel.GetInstance();
        public ICameraListViewModel Cameras { get; } = CameraListViewModel.GetInstance();
        
        public void OnWindowClosing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (_currentPicture != null)
            {
                var picModel = new PictureModel();
                picModel.ApplyChanges(_currentPicture);
                _bl.Save(picModel);
            }
        }

        #region Commands
        private ICommandViewModel _searchPictures;
        public ICommandViewModel SearchPicturesCommand
        {
            get
            {
                if (_searchPictures == null)
                {
                    _searchPictures = new SimpleCommandViewModel(
                        "Searches all Pictures",
                        "Searches all Pictures filtering by EXIF, IPTC and Photographer",
                        () =>
                        {
                            var search = (SearchViewModel)Search;
                            var searched = _bl.GetPictures(null, search.Photographer, search.IPTC, search.EXIF);
                            ObservableCollection<PictureViewModel> picList = new ObservableCollection<PictureViewModel>();
                            searched.ToList().ForEach(mdl => picList.Add(new PictureViewModel(mdl)));
                            CurrentPicture = ((PictureListViewModel)List).SetSearchList(picList);
                            OnPropertyChanged(nameof(CurrentPicture));
                        },
                        () => true);
                }
                return _searchPictures;
            }
        }

        private ICommandViewModel _resetPictures;
        public ICommandViewModel ResetPicturesCommand
        {
            get
            {
                if (_resetPictures == null)
                {
                    _resetPictures = new SimpleCommandViewModel(
                        "Reset Pictures",
                        "Resets the Pictures to the full list again",
                        () =>
                        {
                            CurrentPicture = ((PictureListViewModel)List).ResetSearch() ?? CurrentPicture;
                            ((SearchViewModel)Search).ResetTextFields();
                            OnPropertyChanged(nameof(CurrentPicture));
                        },
                        () => true);
                }
                return _resetPictures;
            }
        }

        private ICommandViewModel _openCreateCameraWindow;
        public ICommandViewModel OpenCreateCameraWindow
        {
            get
            {
                if (_openCreateCameraWindow == null)
                {
                    _openCreateCameraWindow = new SimpleCommandViewModel(
                        "Create a new Camera",
                        "Opens a Window to create a new Camera",
                        () =>
                        {
                            CreateCameraWindow createCameraWindow = new CreateCameraWindow();
                            createCameraWindow.ShowDialog();

                            OnPropertyChanged("Cameras");
                        },
                        () => true);
                }
                return _openCreateCameraWindow;
            }
        }

        private ICommandViewModel _openViewCameraWindow;
        public ICommandViewModel OpenViewCameraWindow
        {
            get
            {
                if (_openViewCameraWindow == null)
                {
                    _openViewCameraWindow = new SimpleCommandViewModel(
                        "Create a new Camera",
                        "Opens a Window to create a new Camera",
                        () =>
                        {
                            ViewCamerasWindow viewCamerasWindow = new ViewCamerasWindow();
                            viewCamerasWindow.ShowDialog();

                            OnPropertyChanged("Cameras");
                        },
                        () => true);
                }
                return _openViewCameraWindow;
            }
        }

        private ICommandViewModel _openCreatePhotographerWindow;
        public ICommandViewModel OpenCreatePhotographerWindow
        {
            get
            {
                if (_openCreatePhotographerWindow == null)
                {
                    _openCreatePhotographerWindow = new SimpleCommandViewModel(
                        "Create a new Photographer",
                        "Opens a Window to create a new Photographer",
                        () =>
                        {
                            CreatePhotographerWindow createPhotographerWindow = new CreatePhotographerWindow();
                            createPhotographerWindow.ShowDialog();

                            OnPropertyChanged("Photographers");
                        },
                        () => true);
                }
                return _openCreatePhotographerWindow;
            }
        }

        private ICommandViewModel _openViewPhotographerWindow;
        public ICommandViewModel OpenViewPhotographerWindow
        {
            get
            {
                if (_openViewPhotographerWindow == null)
                {
                    _openViewPhotographerWindow = new SimpleCommandViewModel(
                        "Create a new Photographer",
                        "Opens a Window to create a new Photographer",
                        () =>
                        {
                            ViewPhotographersWindow viewPhotographersWindow = new ViewPhotographersWindow();
                            viewPhotographersWindow.ShowDialog();

                            OnPropertyChanged("Photographers");
                        },
                        () => true);
                }
                return _openViewPhotographerWindow;
            }
        }
        #endregion
    }
}
