using System.Windows;
using System.Windows.Input;

namespace PicDB
{
    /// <summary>
    /// Interaction logic for CreatePhotographerWindow.xaml
    /// </summary>
    public partial class CreatePhotographerWindow : Window
    {
        public CreatePhotographerWindow()
        {
            DataContext = new CreatePhotographerViewModel();
            InitializeComponent();
        }
    }
}
