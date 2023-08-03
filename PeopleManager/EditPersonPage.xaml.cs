using PeopleManager.Model;
using PeopleManager.View;
using PeopleManager.ViewModel;

namespace PeopleManager
{
    /// <summary>
    /// Interaction logic for EditPersonPage.xaml
    /// </summary>
    public partial class EditPersonPage : FramedPage
    {
        private readonly Person person;

        public EditPersonPage(PersonViewModel personViewModel, Person person = null) : base(personViewModel)
        {
            InitializeComponent();
            this.person = person ?? new Person();
            DataContext = person;
        }
    }
}
