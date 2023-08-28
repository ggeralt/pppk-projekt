using PeopleManager.ViewModel;
using System.Windows.Controls;

namespace PeopleManager.View
{
    public class FramedPage : Page
    {
        public Frame Frame { get; set; }
        public PersonViewModel PersonViewModel { get; }
        public JobViewModel JobViewModel { get; }

        public FramedPage(PersonViewModel personViewModel)
        {
            PersonViewModel = personViewModel;
        }

        public FramedPage(JobViewModel jobViewModel)
        {
            JobViewModel = jobViewModel;
        }
    }
}
