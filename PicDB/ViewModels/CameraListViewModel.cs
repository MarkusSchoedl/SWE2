﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using BIF.SWE2.Interfaces.ViewModels;

namespace PicDB.ViewModels
{
    class CameraListViewModel : ICameraListViewModel
    {
        public IEnumerable<ICameraViewModel> List => throw new NotImplementedException();

        public ICameraViewModel CurrentCamera => throw new NotImplementedException();
    }
}
