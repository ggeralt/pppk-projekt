using Azure.Storage.Blobs.Models;
using BlobStorage.ViewModel;
using System.Windows;
using System.Windows.Forms;

namespace BlobStorage
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly ItemsViewModel itemsViewModel;

        public MainWindow()
        {
            InitializeComponent();
            itemsViewModel = new ItemsViewModel();
            Init();
        }

        private void Init()
        {
            lbItems.ItemsSource = itemsViewModel.Items;
            cbDirectories.ItemsSource = itemsViewModel.Directories;
        }

        private void LbItems_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            DataContext = lbItems.SelectedItem as BlobItem;
        }

        private void CbDirectories_KeyDown(object sender, System.Windows.Input.KeyEventArgs e)
        {
            if (e.Key == System.Windows.Input.Key.Enter)
            {
                itemsViewModel.Directory = cbDirectories.Text.Trim();
                cbDirectories.Text = itemsViewModel.Directory;
            }
        }

        private void CbDirectories_TextChanged(object sender, System.Windows.Controls.TextChangedEventArgs e)
        {
            if (itemsViewModel.Directories.Contains(cbDirectories.Text))
            {
                itemsViewModel.Directory = cbDirectories.Text;
                cbDirectories.SelectedItem = itemsViewModel.Directory;
            }
        }

        private async void BtnUpload_Click(object sender, RoutedEventArgs e)
        {
            var dialog = new OpenFileDialog();

            if (dialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                await itemsViewModel.UploadAsync(dialog.FileName, cbDirectories.Text);
            }

            cbDirectories.Text = itemsViewModel.Directory;
        }

        private async void BtnDownload_Click(object sender, RoutedEventArgs e)
        {
            if (!(lbItems.SelectedItem is BlobItem blobItem))
            {
                return;
            }

            var dialog = new SaveFileDialog
            {
                FileName = blobItem.Name.Substring(blobItem.Name.LastIndexOf(ItemsViewModel.ForwardSlash) + 1)
            };

            if (dialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                await itemsViewModel.DownloadAsync(blobItem, dialog.FileName);
            }

            cbDirectories.Text = itemsViewModel.Directory;
        }

        private async void BtnDelete_Click(object sender, RoutedEventArgs e)
        {
            if (!(lbItems.SelectedItem is BlobItem blobItem))
            {
                return;
            }

            await itemsViewModel.DeleteAsync(blobItem);
            cbDirectories.Text = itemsViewModel.Directory;
        }
    }
}
