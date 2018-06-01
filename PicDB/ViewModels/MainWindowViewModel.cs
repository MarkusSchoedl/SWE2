using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using BIF.SWE2.Interfaces.ViewModels;
using PicDB.Models;

namespace PicDB.ViewModels
{
    class MainWindowViewModel : ViewModel, IMainWindowViewModel
    {
        private static readonly BusinessLayer _bl = BusinessLayer.GetInstance();

        public MainWindowViewModel()
        {
            if (!_bl.GetPictures().Any())
            {
                MessageBox.Show("The Pictures Folder didnt contain any images. Add images and restart the app.", "PictureDB: Error", MessageBoxButton.OK, MessageBoxImage.Exclamation);

                // Shutdown the application.
                Application.Current.Shutdown();
            }
        }

        private IPictureViewModel _currentPicture = new PictureViewModel(_bl.GetPicture(0));
        private readonly IPictureListViewModel _list = new PictureListViewModel();
        private readonly ISearchViewModel _search = new SearchViewModel();

        public IPictureViewModel CurrentPicture
        {
            get { return _currentPicture; }
            set
            {
                if (_currentPicture != value)
                {
                    _currentPicture = value;
                    OnPropertyChanged("CurrentPicture");
                }

            }
        }

        public IPictureListViewModel List => _list;
        public ISearchViewModel Search => _search;

        private ICommandViewModel _applyChanges;
        public ICommandViewModel ApplyChanges
        {
            get
            {
                if (_applyChanges == null)
                {
                    _applyChanges = new SimpleCommandViewModel(
                        "Apply Changes",
                        "Apply changes from an input window to the picture",
                        () =>
                        {
                            var mdl = new IPTCModel();
                            mdl.ApplyChanges(CurrentPicture.IPTC);
                            _bl.WriteIPTC(CurrentPicture.FileName, mdl);
                        },
                        () => true);
                }
                return _applyChanges;
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
                            createCameraWindow.Show();
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
                            createPhotographerWindow.Show();
                        },
                        () => true);
                }
                return _openCreatePhotographerWindow;
            }
        }
    }
}
