using System.Collections.Generic;
using System;
using SQLViewer.DAL;

namespace SQLViewer.Model
{
    public class DatabaseEntity
    {
        private readonly Lazy<IEnumerable<Column>> columns;

        public string Schema { get; set; }
        public string Name { get; set; }
        public Database Database { get; set; }
        public IList<Column> Columns { get => new List<Column>(columns.Value); }

        public DatabaseEntity()
        {
            columns = new Lazy<IEnumerable<Column>>(() => RepositoryFactory.GetRepository().GetColumns(this));
        }

        public override string ToString()
        {
            return $"{Schema}.{Name}";
        }
    }
}
