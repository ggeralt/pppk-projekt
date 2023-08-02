using System.Windows;

namespace PeopleManager
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            Frame.Navigate(new ListPeoplePage(new ViewModel.PersonViewModel()) { Frame = Frame });
        }
    }
}
