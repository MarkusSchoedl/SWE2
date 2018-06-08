using System.Windows;
using System.Windows.Input;
using PicDB.ViewModels;

namespace PicDB
{
    /// <summary>
    /// Interaction logic for CreatePhotographerWindow.xaml
    /// </summary>
    public partial class CreatePhotographerWindow : Window
    {
        public CreatePhotographerWindow()
        {
            DataContext = PhotographerListViewModel.GetInstance();
            InitializeComponent();
        }
    }
}
