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
    public class MockPhotographerListViewModel : ViewModel, IPhotographerListViewModel
    {
        #region Singleton
        private static MockPhotographerListViewModel _instance;

        protected MockPhotographerListViewModel()
        {
            _bl.GetPhotographers().ToList().ForEach(mdl => _photographers.Add(new PhotographerViewModel(mdl)));
        }

        public static MockPhotographerListViewModel GetInstance()
        {
            if (_instance == null)
            {
                _instance = new MockPhotographerListViewModel();
            }

            return _instance;
        }
        #endregion

        private MockBusinessLayer _bl = MockBusinessLayer.GetInstance();

        private readonly ObservableCollection<IPhotographerViewModel> _photographers = new ObservableCollection<IPhotographerViewModel>();

        public IEnumerable<IPhotographerViewModel> List => _photographers;

        public IPhotographerViewModel CurrentPhotographer { get; set; } = null;
    }
}
