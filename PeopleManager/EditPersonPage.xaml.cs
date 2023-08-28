using Microsoft.Win32;
using PeopleManager.Model;
using PeopleManager.Utility;
using PeopleManager.View;
using PeopleManager.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Xml.Linq;

namespace PeopleManager
{
    /// <summary>
    /// Interaction logic for EditPersonPage.xaml
    /// </summary>
    public partial class EditPersonPage : FramedPage
    {
        private const string Filter = "All supported graphics|*.jpg;*.jpeg;*.png|JPEG (*.jpg;*.jpeg)|*.jpg;*.jpeg|Portable Network Graphic (*.png)|*.png";
        private readonly Person _person;

        public EditPersonPage(PersonViewModel personViewModel, Person person = null) : base(personViewModel)
        {
            InitializeComponent();
            LoadJobs();
            _person = person ?? new Person();
            DataContext = _person;
        }

        private void LoadJobs()
        {
            cbJobs.ItemsSource = new List<Job>(new JobViewModel().Jobs);
        }

        private bool FormValid()
        {
            bool valid = true;

            GridContainer.Children.OfType<TextBox>().ToList().ForEach(e =>
            {
                if (string.IsNullOrEmpty(e.Text.Trim())
                || "Int".Equals(e.Tag) && !int.TryParse(e.Text.Trim(), out int r)
                || "Email".Equals(e.Tag) && !ValidationUtilities.isValidEmail(e.Text.Trim()))
                {
                    e.Background = Brushes.LightCoral;
                    valid = false;
                }
                else
                {
                    e.Background = Brushes.White;
                }
            });

            if (Picture.Source == null)
            {
                PictureBorder.BorderBrush = Brushes.LightCoral;
                valid = false;
            }
            else
            {
                PictureBorder.BorderBrush = Brushes.White;
            }

            if (cbJobs.SelectedItem == null)
            {
                valid = false;
            }

            return valid;
        }

        private void BtnBack_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            Frame.NavigationService.GoBack();
        }

        private void BtnCommit_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            if (FormValid())
            {
                _person.FirstName = tbFirstName.Text.Trim();
                _person.LastName = tbLastName.Text.Trim();
                _person.Age = int.Parse(tbAge.Text.Trim());
                _person.Email = tbEmail.Text.Trim();
                _person.Picture = ImageUtilities.BitmapImageToByteArray(Picture.Source as BitmapImage);
                _person.JobID = (cbJobs.SelectedItem as Job).IDJob;

                if (_person.IDPerson == 0)
                {
                    PersonViewModel.People.Add(_person);
                }
                else
                {
                    PersonViewModel.Update(_person);
                }

                Frame.NavigationService.GoBack();
            }
        }

        private void BtnUpload_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            var dialog = new OpenFileDialog
            {
                Filter = Filter
            };

            if (dialog.ShowDialog() == true)
            {
                Picture.Source = new BitmapImage(new Uri(dialog.FileName));
            }
        }
    }
}
