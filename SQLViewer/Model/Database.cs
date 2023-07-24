using SQLViewer.DAL;
using System;
using System.Collections.Generic;

namespace SQLViewer.Model
{
    public class Database
    {
        private readonly Lazy<IEnumerable<DatabaseEntity>> tables;
        private readonly Lazy<IEnumerable<DatabaseEntity>> views;
        private readonly Lazy<IEnumerable<Procedure>> procedures;

        public string Name { get; set; }
        public IList<DatabaseEntity> Tables { get => new List<DatabaseEntity>(tables.Value); }
        public IList<DatabaseEntity> Views { get => new List<DatabaseEntity>(views.Value); }
        public IList<Procedure> Procedures { get => new List<Procedure>(procedures.Value); }

        public Database()
        {
            tables = new Lazy<IEnumerable<DatabaseEntity>>(() => RepositoryFactory.GetRepository().GetDatabaseEntities(this, DatabaseEntityType.Table));
            views = new Lazy<IEnumerable<DatabaseEntity>>(() => RepositoryFactory.GetRepository().GetDatabaseEntities(this, DatabaseEntityType.View));
            procedures = new Lazy<IEnumerable<Procedure>>(() => RepositoryFactory.GetRepository().GetProcedures(this));
        }

        public override string ToString()
        {
            return Name;
        }
    }
}
