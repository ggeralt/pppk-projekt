using System;

namespace PeopleManager.DAL
{
    public static class RepositoryFactory
    {
        public static TRepository GetRepositoryInstance<T, TRepository>(params object[] args) where TRepository : IRepository<T>
        {
            return (TRepository)Activator.CreateInstance(typeof(TRepository), args);
        }
    }
}
