using PeopleManager.Model;
using PeopleManager.View;
using PeopleManager.ViewModel;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace PeopleManager
{
    /// <summary>
    /// Interaction logic for AddJobPage.xaml
    /// </summary>
    public partial class AddJobPage : FramedPage
    {
        private readonly Job _job;

        public AddJobPage(JobViewModel jobViewModel, Job job = null) : base(jobViewModel)
        {
            InitializeComponent();
            _job = job ?? new Job();
            DataContext = _job;
        }

        private void btnCommit_Click(object sender, RoutedEventArgs e)
        {
            if (FormValid())
            {
                _job.Name = tbName.Text.Trim();
                Frame.NavigationService.GoBack();

                if (_job.IDJob == 0)
                {
                    JobViewModel.Jobs.Add(_job);
                }
                else
                {
                    JobViewModel.Update(_job);
                }
            }
        }

        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            Frame.NavigationService.GoBack();
        }

        private bool FormValid()
        {
            bool valid = true;

            GridContainer.Children.OfType<TextBox>().ToList().ForEach(e =>
            {
                if (string.IsNullOrEmpty(e.Text.Trim()))
                {
                    e.Background = Brushes.LightCoral;
                    valid = false;
                }
                else
                {
                    e.Background = Brushes.White;
                }
            });

            return valid;
        }
    }
}
