using System;

namespace PeopleManager.DAL
{
    public static class RepositoryFactory
    {
        private static readonly Lazy<IRepository> repository = new Lazy<IRepository>(() => new SQLRepository());
        public static IRepository GetRepository() => repository.Value;
    }
}
