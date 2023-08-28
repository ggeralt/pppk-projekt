using PeopleManager.Model;
using PeopleManager.View;
using PeopleManager.ViewModel;
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
using System.Xml.Linq;

namespace PeopleManager
{
    /// <summary>
    /// Interaction logic for ListJobsPage.xaml
    /// </summary>
    public partial class ListJobsPage : FramedPage
    {
        public ListJobsPage(JobViewModel jobViewModel) : base(jobViewModel)
        {
            InitializeComponent();
            lvJobs.ItemsSource = jobViewModel.Jobs;
        }

        private void BtnPeople_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(new ListPeoplePage(new PersonViewModel()) 
            { 
                Frame = Frame 
            });
        }

        private void BtnDelete_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (lvJobs.SelectedItem != null)
                {
                    JobViewModel.Jobs.Remove(lvJobs.SelectedItem as Job);
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Job is in use! Remove the person first!");
            }
        }

        private void BtnEdit_Click(object sender, RoutedEventArgs e)
        {
            if (lvJobs.SelectedItem != null)
            {
                Frame.Navigate(new AddJobPage(JobViewModel, lvJobs.SelectedItem as Job) 
                { 
                    Frame = Frame 
                });
            }
        }

        private void BtnAdd_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(new AddJobPage(JobViewModel) 
            { 
                Frame = Frame 
            });
        }
    }
}
