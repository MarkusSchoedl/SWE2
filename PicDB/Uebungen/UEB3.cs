﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BIF.SWE2.Interfaces;
using BIF.SWE2.Interfaces.ViewModels;
using PicDB;
using PicDB.ViewModels;

namespace Uebungen
{
    public class UEB3 : IUEB3
    {
        public void HelloWorld()
        {
        }

        public IBusinessLayer GetBusinessLayer()
        {
            return MockBusinessLayer.GetInstance();
        }

        public void TestSetup(string picturePath)
        {
            //throw new NotImplementedException();
        }

        public IDataAccessLayer GetDataAccessLayer()
        {
            return new MockDataAccessLayer();
        }

        public ISearchViewModel GetSearchViewModel()
        {
            return new SearchViewModel();
        }
    }
}
