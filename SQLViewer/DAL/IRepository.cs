﻿using SQLViewer.Model;
using System.Collections.Generic;
using System.Data;

namespace SQLViewer.DAL
{
    public interface IRepository
    {
        IEnumerable<Column> GetColumns(DatabaseEntity databaseEntity);
        IEnumerable<DatabaseEntity> GetDatabaseEntities(Database database, DatabaseEntityType databaseEntityType);
        IEnumerable<Database> GetDatabases();
        IEnumerable<ProcedureParameter> GetProcedureParameters(Procedure procedure);
        IEnumerable<Procedure> GetProcedures(Database database);
        void LogIn(string server, string username, string password);
        DataSet Execute(string query);
        DataSet CreateDataSet(DatabaseEntity databaseEntity);
    }
}