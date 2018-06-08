using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using BIF.SWE2.Interfaces.ViewModels;
using PicDB.Models;

namespace PicDB.ViewModels
{
    public class PhotographerListViewModel : ViewModel, IPhotographerListViewModel
    {
        #region Singleton
        private static PhotographerListViewModel _instance;

        protected PhotographerListViewModel()
        {
            _bl.GetPhotographers().ToList().ForEach(mdl => _photographers.Add(new PhotographerViewModel(mdl)));
        }

        public static PhotographerListViewModel GetInstance()
        {
            if (_instance == null)
            {
                _instance = new PhotographerListViewModel();
            }

            return _instance;
        }
        #endregion

        private BusinessLayer _bl = BusinessLayer.GetInstance();

        private readonly ObservableCollection<IPhotographerViewModel> _photographers = new ObservableCollection<IPhotographerViewModel>();

        public IEnumerable<IPhotographerViewModel> List => _photographers;

        public IPhotographerViewModel CurrentPhotographer { get; set; } = null;


        private ICommandViewModel _deletePhotographerCommand;
        public ICommandViewModel DeletePhotographerCommand
        {
            get
            {
                if (_deletePhotographerCommand == null)
                {
                    _deletePhotographerCommand = new RelayCommandViewModel(
                        "Delete Photographer",
                        "Deletes an existing Photographer",
                        (dataGrid) =>
                        {
                            if (dataGrid.GetType() != typeof(DataGrid))
                                throw new ArgumentException("The paramter has to be a type of DataGrid");

                            if (CurrentPhotographer != null)
                            {
                                _bl.DeletePhotographer(CurrentPhotographer.ID);
                                _photographers.Remove(CurrentPhotographer);
                                CurrentPhotographer = null;
                            }
                        },
                        () => true);
                }
                return _deletePhotographerCommand;
            }
        }


        public PhotographerModel NewPhotographer { get; set; } = new PhotographerModel();
        private ICommandViewModel _savePhotographer;
        public ICommandViewModel SavePhotographer
        {
            get
            {
                if (_savePhotographer == null)
                {
                    _savePhotographer = new RelayCommandViewModel(
                        "Create a new Photographer",
                        "Opens a Window to create a new Photographer",
                        window =>
                        {
                            if (window.GetType().BaseType != typeof(Window))
                                throw new ArgumentException("Argument must be type of window");

                            if (_photographers.Any(x =>
                                x.FirstName == NewPhotographer.FirstName && x.LastName == NewPhotographer.LastName))
                            {
                                MessageBoxResult result = MessageBox.Show("A photographer with that name already exists. Do you want to create another one?",
                                    "Confirmation",
                                    MessageBoxButton.YesNo,
                                    MessageBoxImage.Question);
                                if (result == MessageBoxResult.No)
                                {
                                    ((Window)window).Close();
                                    return;
                                }

                            }

                            _bl.Save(NewPhotographer);
                            _photographers.Add(new PhotographerViewModel(NewPhotographer));
                            NewPhotographer = new PhotographerModel();
                            ((Window)window).Close();
                        }, 
                        () => true);
                }
                return _savePhotographer;
            }
        }
    }
}
