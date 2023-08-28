using PeopleManager.DAL;
using PeopleManager.Model;
using System.Collections.ObjectModel;
using System.Linq;

namespace PeopleManager.ViewModel
{
    public class PersonViewModel
    {
        public ObservableCollection<Person> People { get; }
        private SQLRepository sqlRepository;

        public PersonViewModel()
        {
            sqlRepository = RepositoryFactory.GetRepositoryInstance<Person, SQLRepository>();
            People = new ObservableCollection<Person>(sqlRepository.Get());
            People.CollectionChanged += People_CollectionChanged;
        }

        private void People_CollectionChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
            switch (e.Action)
            {
                case System.Collections.Specialized.NotifyCollectionChangedAction.Add:
                    sqlRepository.Add(People[e.NewStartingIndex]);
                    break;
                case System.Collections.Specialized.NotifyCollectionChangedAction.Remove:
                    sqlRepository.Delete(e.OldItems.OfType<Person>().ToList()[0]);
                    break;
                case System.Collections.Specialized.NotifyCollectionChangedAction.Replace:
                    sqlRepository.Update(e.NewItems.OfType<Person>().ToList()[0]);
                    break;
            }
        }

        public void Update(Person person) => People[People.IndexOf(person)] = person;
    }
}
