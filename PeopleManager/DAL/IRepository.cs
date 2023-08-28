using System.Collections.Generic;

namespace PeopleManager.DAL
{
    public interface IRepository<T>
    {
        void Add(T item);
        void Update(T item);
        void Delete(T item);
        IList<T> Get();
        T Get(int id);
    }
}
