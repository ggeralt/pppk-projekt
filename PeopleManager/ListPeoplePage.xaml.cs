using PeopleManager.View;
using PeopleManager.ViewModel;

namespace PeopleManager
{
    /// <summary>
    /// Interaction logic for ListPeoplePage.xaml
    /// </summary>
    public partial class ListPeoplePage : FramedPage
    {
        public ListPeoplePage(PersonViewModel personViewModel) : base(personViewModel)
        {
            InitializeComponent();
            lvPeople.ItemsSource = personViewModel.People;
        }

        private void BtnAdd_Click(object sender, System.Windows.RoutedEventArgs e)
        {

        }

        private void BtnEdit_Click(object sender, System.Windows.RoutedEventArgs e)
        {

        }

        private void BtnDelete_Click(object sender, System.Windows.RoutedEventArgs e)
        {

        }
    }
}
