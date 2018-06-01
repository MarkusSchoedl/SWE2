﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace PicDB
{
    /// <summary>
    /// Interaction logic for CreateCameraWindow.xaml
    /// </summary>
    public partial class CreateCameraWindow : Window
    {
        public CreateCameraWindow()
        {
            DataContext = new CreateCameraViewModel();
            InitializeComponent();
        }

        private void TextBox_CheckNumericInput(object sender, TextCompositionEventArgs e)
        {
            if (!char.IsDigit(e.Text, e.Text.Length - 1))
                e.Handled = true;
        }

    }
}
