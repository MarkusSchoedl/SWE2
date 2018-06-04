using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using BIF.SWE2.Interfaces.ViewModels;

namespace PicDB.ViewModels
{
    public class PhotographerListViewModel : IPhotographerListViewModel
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

        private readonly List<IPhotographerViewModel> _photographers = new List<IPhotographerViewModel>();

        public IEnumerable<IPhotographerViewModel> List => _photographers;

        public IPhotographerViewModel CurrentPhotographer { get; set; } = null;
    }
}
