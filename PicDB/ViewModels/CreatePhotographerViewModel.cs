using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PicDB.Models;

namespace PicDB
{
    class CreatePhotographerViewModel
    {
        private BusinessLayer _bl = BusinessLayer.GetInstance();

        public PhotographerModel Photographer { get; } = new PhotographerModel();

        private ICommandViewModel _savePhotographer;
        public ICommandViewModel SavePhotographer
        {
            get
            {
                if (_savePhotographer == null)
                {
                    _savePhotographer = new SimpleCommandViewModel(
                        "Save Photographer",
                        "Save Photographer",
                        () =>
                        {
                            _bl.Save(Photographer);
                            
                        },
                        () => true);
                }
                return _savePhotographer;
            }
        }
    }
}

