using Azure.Storage.Blobs.Models;
using BlobStorage.DAO;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace BlobStorage.ViewModel
{
    internal class ItemsViewModel
    {
        private string directory;
        public const string ForwardSlash = "/";
        public ObservableCollection<BlobItem> Items { get; }
        public ObservableCollection<string> Directories { get; }
        public string Directory
        { 
            get => directory;
            set
            {
                directory = value;
                Refresh();
            }
        }

        public ItemsViewModel()
        {
            Items = new ObservableCollection<BlobItem>();
            Directories = new ObservableCollection<string>();
            Refresh();
        }

        private void Refresh()
        {
            Items.Clear();
            Directories.Clear();

            Repository.Container.GetBlobs().ToList().ForEach(blob =>
            {
                if (blob.Name.Contains(ForwardSlash))
                {
                    string _directory = blob.Name.Substring(0, blob.Name.LastIndexOf(ForwardSlash));

                    if (!Directories.Contains(_directory))
                    {
                        Directories.Add(_directory); 
                    }
                }

                if (string.IsNullOrEmpty(Directory) && !blob.Name.Contains(ForwardSlash))
                {
                    Items.Add(blob);
                }
                else if (!string.IsNullOrEmpty(Directory) && blob.Name.StartsWith($"{Directory}{ForwardSlash}"))
                {
                    Items.Add(blob);
                }
            });
        }

        public async Task DownloadAsync(BlobItem blobItem, string path)
        {
            using (var fs = File.OpenWrite(path))
            {
                await Repository.Container.GetBlobClient(blobItem.Name).DownloadToAsync(fs);
            }

            Refresh();
        }

        public async Task UploadAsync(string path, string directory)
        {
            string filename = path.Substring(path.LastIndexOf(Path.DirectorySeparatorChar) + 1);

            if (!string.IsNullOrEmpty(directory))
            {
                filename = $"{directory}{ForwardSlash}{filename}";
            }

            using (var fs = File.OpenRead(path))
            {
                await Repository.Container.GetBlobClient(filename).UploadAsync(fs, true);
            }

            Refresh();
        }

        public async Task DeleteAsync(BlobItem blobItem)
        {
            await Repository.Container.GetBlobClient(blobItem.Name).DeleteAsync();
            Refresh();
        }
    }
}
