using System.Collections.Generic;
using System;
using SQLViewer.DAL;

namespace SQLViewer.Model
{
    public class Procedure
    {
        private readonly Lazy<IEnumerable<ProcedureParameter>> procedureParameters;

        public string Name { get; set; }
        public string Definition { get; set; }
        public Database Database { get; set; }
        public IList<ProcedureParameter> ProcedureParameters { get => new List<ProcedureParameter>(procedureParameters.Value); }

        public Procedure()
        {
            procedureParameters = new Lazy<IEnumerable<ProcedureParameter>>(() 
                => RepositoryFactory.GetRepository().GetProcedureParameters(this));
        }

        public override string ToString()
        {
            return Name;
        }
    }
}
