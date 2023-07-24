using System;

namespace SQLViewer.DAL
{
    public static class RepositoryFactory
    {
        private static readonly Lazy<IRepository> sqlRepository = new Lazy<IRepository>(() => new SQLRepository());
        public static IRepository GetRepository() => sqlRepository.Value;
    }
}
