using PeopleManager.Model;
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

        private void BtnDelete_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            if (lvPeople.SelectedItems != null)
            {
                PersonViewModel.People.Remove(lvPeople.SelectedItem as Person);
            }
        }

        private void BtnAdd_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            Frame.Navigate(new EditPersonPage(PersonViewModel)
            {
                Frame = Frame
            });
        }

        private void BtnEdit_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            if (lvPeople.SelectedItems != null)
            {
                Frame.Navigate(new EditPersonPage(PersonViewModel, lvPeople.SelectedItem as Person)
                {
                    Frame = Frame
                });
            }
        }

        private void BtnJobs_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            Frame.Navigate(new ListJobsPage(new JobViewModel()) 
            { 
                Frame = Frame 
            });
        }
    }
}
