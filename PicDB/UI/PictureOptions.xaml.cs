using System;
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
    /// Interaction logic for PictureOptions.xaml
    /// </summary>
    public partial class PictureOptions : UserControl
    {
        public PictureOptions()
        {
            InitializeComponent();
        }

        private String _placeholder = "Enter your Search criteria here...";

        private void TextBoxSearchGotFocus(object sender, RoutedEventArgs e)
        {
            TextBox textBox = (TextBox)sender;
            if (textBox.Text == _placeholder)
            {
                textBox.Text = "";
                textBox.Foreground = new SolidColorBrush(Colors.Black);
            }
        }

        private void TextBoxSearchLostFocus(object sender, RoutedEventArgs e)
        {
            TextBox textBox = (TextBox)sender;
            if (String.IsNullOrWhiteSpace(textBox.Text))
            {
                textBox.Text = _placeholder;
                textBox.Foreground = new SolidColorBrush(Colors.DarkGray);
            }
        }

        private void TextBoxSearchInitialize(object sender, RoutedEventArgs e)
        {
            TextBox textBox = (TextBox)sender;
            if (String.IsNullOrWhiteSpace(textBox.Text))
            {
                textBox.Text = _placeholder;
                textBox.Foreground = new SolidColorBrush(Colors.DarkGray);
            }
        }
    }
}
