using PeopleManager.Model;
using System.Collections.Generic;

namespace PeopleManager.DAL
{
    public interface IRepository
    {
        void AddPerson(Person person);
        void UpdatePerson(Person person);
        void DeletePerson(Person person);
        IList<Person> GetPeople();
        Person GetPerson(int idPerson);
    }
}
