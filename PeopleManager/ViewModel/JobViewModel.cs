using PeopleManager.DAL;
using PeopleManager.Model;
using System.Collections.ObjectModel;
using System.Linq;

namespace PeopleManager.ViewModel
{
    public class JobViewModel
    {
        public ObservableCollection<Job> Jobs { get; }
        private JobRepository jobRepository;

        public JobViewModel()
        {
            jobRepository = RepositoryFactory.GetRepositoryInstance<Job, JobRepository>();
            Jobs = new ObservableCollection<Job>(jobRepository.Get());
            Jobs.CollectionChanged += Job_CollectionChanged;
        }

        private void Job_CollectionChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
            switch (e.Action)
            {
                case System.Collections.Specialized.NotifyCollectionChangedAction.Add:
                    jobRepository.Add(Jobs[e.NewStartingIndex]);
                    break;
                case System.Collections.Specialized.NotifyCollectionChangedAction.Remove:
                    jobRepository.Delete(e.OldItems.OfType<Job>().ToList()[0]);
                    break;
                case System.Collections.Specialized.NotifyCollectionChangedAction.Replace:
                    jobRepository.Update(e.NewItems.OfType<Job>().ToList()[0]);
                    break;
            }
        }

        public void Update(Job job) => Jobs[Jobs.IndexOf(job)] = job;
    }
}
