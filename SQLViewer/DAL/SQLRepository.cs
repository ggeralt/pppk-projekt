using SQLViewer.Model;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace SQLViewer.DAL
{
    internal class SQLRepository : IRepository
    {
        private const string ConnectionString = "Server={0};Uid={1};Pwd={2}";
        private const string SelectDatabases = "SELECT name As Name FROM sys.databases";
        private const string SelectEntities = "SELECT TABLE_SCHEMA AS [Schema], TABLE_NAME AS Name FROM {0}.INFORMATION_SCHEMA.{1}S";
        private const string SelectProcedures = "SELECT SPECIFIC_NAME as Name, ROUTINE_DEFINITION as Definition FROM {0}.INFORMATION_SCHEMA.ROUTINES WHERE ROUTINE_TYPE = 'PROCEDURE'";
        private const string SelectColumns = "SELECT COLUMN_NAME as Name, DATA_TYPE as DataType FROM {0}.INFORMATION_SCHEMA.COLUMNS WHERE TABLE_NAME = '{1}'";
        private const string SelectProcedureParameters = "SELECT PARAMETER_NAME as Name, PARAMETER_MODE as Mode, DATA_TYPE as DataType FROM {0}.INFORMATION_SCHEMA.PARAMETERS WHERE SPECIFIC_NAME='{1}'";
        private const string SelectQuery = "SELECT * FROM {0}.{1}.{2}";
        private const string FileFilter = "XML files(*.xml)|*.xml|All files(*.*)|*.*";
        private const string FileName = "{0}.xml";

        private string cs;
        
        public void LogIn(string server, string username, string password)
        {
            using (SqlConnection sqlConnection = new SqlConnection(string.Format(ConnectionString, server, username, password)))
            {
                cs = sqlConnection.ConnectionString;
                sqlConnection.Open();
            }
        }

        public IEnumerable<Database> GetDatabases()
        {
            using (SqlConnection sqlConnection = new SqlConnection(cs))
            {
                sqlConnection.Open();
                using (SqlCommand sqlCommand = sqlConnection.CreateCommand())
                {
                    sqlCommand.CommandText = SelectDatabases;
                    sqlCommand.CommandType = System.Data.CommandType.Text;
                    using (SqlDataReader sqlDataReader = sqlCommand.ExecuteReader())
                    {
                        while (sqlDataReader.Read())
                        {
                            yield return new Database
                            {
                                Name = sqlDataReader[nameof(Database.Name)].ToString()
                            };
                        }
                    }
                }
            }
        }

        public IEnumerable<DatabaseEntity> GetDatabaseEntities(Database database, DatabaseEntityType databaseEntityType)
        {
            using (SqlConnection sqlConnection = new SqlConnection(cs))
            {
                sqlConnection.Open();
                using (SqlCommand sqlCommand = sqlConnection.CreateCommand())
                {
                    sqlCommand.CommandText = string.Format(SelectEntities, database.Name, databaseEntityType.ToString());
                    sqlCommand.CommandType = System.Data.CommandType.Text;
                    using (SqlDataReader sqlDataReader = sqlCommand.ExecuteReader())
                    {
                        while (sqlDataReader.Read())
                        {
                            yield return new DatabaseEntity
                            {
                                Schema = sqlDataReader[nameof(DatabaseEntity.Schema)].ToString(),
                                Name = sqlDataReader[nameof(DatabaseEntity.Name)].ToString(),
                                Database = database
                            };
                        }
                    }
                }
            }
        }

        public IEnumerable<Procedure> GetProcedures(Database database)
        {
            using (SqlConnection sqlConnection = new SqlConnection(cs))
            {
                sqlConnection.Open();
                using (SqlCommand sqlCommand = sqlConnection.CreateCommand())
                {
                    sqlCommand.CommandText = string.Format(SelectProcedures, database.Name);
                    sqlCommand.CommandType = System.Data.CommandType.Text;
                    using (SqlDataReader sqlDataReader = sqlCommand.ExecuteReader())
                    {
                        while (sqlDataReader.Read())
                        {
                            yield return new Procedure
                            {
                                Name = sqlDataReader[nameof(Procedure.Name)].ToString(),
                                Definition = sqlDataReader[nameof(Procedure.Definition)].ToString(),
                                Database = database
                            };
                        }
                    }
                }
            }
        }

        public IEnumerable<Column> GetColumns(DatabaseEntity databaseEntity)
        {
            using (SqlConnection sqlConnection = new SqlConnection(cs))
            {
                sqlConnection.Open();
                using (SqlCommand sqlCommand = sqlConnection.CreateCommand())
                {
                    sqlCommand.CommandText = string.Format(SelectColumns, databaseEntity.Database.Name, databaseEntity.Name);
                    sqlCommand.CommandType = System.Data.CommandType.Text;
                    using (SqlDataReader sqlDataReader = sqlCommand.ExecuteReader())
                    {
                        while (sqlDataReader.Read())
                        {
                            yield return new Column
                            {
                                Name = sqlDataReader[nameof(Column.Name)].ToString(),
                                DataType = sqlDataReader[nameof(Column.DataType)].ToString()
                            };
                        }
                    }
                }
            }
        }

        public IEnumerable<ProcedureParameter> GetProcedureParameters(Procedure procedure)
        {
            using (SqlConnection sqlConnection = new SqlConnection(cs))
            {
                sqlConnection.Open();
                using (SqlCommand sqlCommand = sqlConnection.CreateCommand())
                {
                    sqlCommand.CommandText = string.Format(SelectProcedureParameters, procedure.Database.Name, procedure.Name);
                    sqlCommand.CommandType = System.Data.CommandType.Text;
                    using (SqlDataReader sqlDataReader = sqlCommand.ExecuteReader())
                    {
                        while (sqlDataReader.Read())
                        {
                            yield return new ProcedureParameter
                            {
                                Name = sqlDataReader[nameof(ProcedureParameter.Name)].ToString(),
                                Mode = sqlDataReader[nameof(ProcedureParameter.Mode)].ToString(),
                                DataType = sqlDataReader[nameof(ProcedureParameter.DataType)].ToString()
                            };
                        }
                    }
                }
            }
        }

        public DataSet Execute(string query)
        {
            using (SqlConnection sqlConnection = new SqlConnection(cs))
            {
                SqlDataAdapter sqlDataAdapter = new SqlDataAdapter();
                sqlConnection.Open();
                using (SqlCommand sqlCommand = sqlConnection.CreateCommand())
                {
                    sqlCommand.CommandText = query;
                    sqlDataAdapter.SelectCommand = sqlCommand;

                    DataSet dataSet = new DataSet();
                    sqlDataAdapter.Fill(dataSet);

                    return dataSet;
                }
            }
        }
    }
}
