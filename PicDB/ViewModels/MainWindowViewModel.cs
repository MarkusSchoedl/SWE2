using System;
using System.Collections.Generic;
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
                    var picModel = new PictureModel();
                    picModel.ApplyChanges(_currentPicture);
                    _bl.Save(picModel);

                    _currentPicture = value;
                    OnPropertyChanged("CurrentPicture");
                }
            }
        }

        public IPictureListViewModel List { get; } = new PictureListViewModel();
        public ISearchViewModel Search { get; } = new SearchViewModel();

        public IPhotographerListViewModel Photographers { get; } = PhotographerListViewModel.GetInstance();
        public ICameraListViewModel Cameras { get; } = CameraListViewModel.GetInstance();

        public void OnWindowClosing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            var picModel = new PictureModel();
            picModel.ApplyChanges(_currentPicture);
            _bl.Save(picModel);
        }

        #region Commands
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
                        },
                        () => true);
                }
                return _openCreateCameraWindow;
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
                        },
                        () => true);
                }
                return _openViewPhotographerWindow;
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
                        },
                        () => true);
                }
                return _openViewCameraWindow;
            }
        }
        #endregion
    }
}
