using SQLViewer.Model;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace SQLViewer.DAO
{
    internal static class Repository
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

        private static string cs;

        internal static void LogIn(string server, string username, string password)
        {
            using (SqlConnection sqlConnection = new SqlConnection(string.Format(ConnectionString, server, username, password)))
            {
                cs = sqlConnection.ConnectionString;
                sqlConnection.Open();
            }
        }

        internal static IEnumerable<Database> GetDatabases()
        {
            using (SqlConnection sqlConnection = new SqlConnection(cs))
            {
                sqlConnection.Open();
                using (SqlCommand sqlCommand = sqlConnection.CreateCommand())
                {
                    sqlCommand.CommandText = SelectDatabases;
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
    }
}
