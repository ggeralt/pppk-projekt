using PeopleManager.Model;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Reflection;

namespace PeopleManager.DAL
{
    internal class JobRepository : IRepository<Job>
    {
        private static string cs = ConfigurationManager.ConnectionStrings["cs"].ConnectionString;

        public void Add(Job job)
        {
            using (SqlConnection sqlConnection = new SqlConnection(cs))
            {
                sqlConnection.Open();
                using (SqlCommand sqlCommand = sqlConnection.CreateCommand())
                {
                    sqlCommand.CommandText = MethodBase.GetCurrentMethod().Name + nameof(Job);
                    sqlCommand.CommandType = System.Data.CommandType.StoredProcedure;

                    sqlCommand.Parameters.AddWithValue(nameof(Job.Name), job.Name);

                    SqlParameter idJob = new SqlParameter(nameof(Job.IDJob), System.Data.SqlDbType.Int)
                    {
                        Direction = System.Data.ParameterDirection.Output
                    };

                    sqlCommand.Parameters.Add(idJob);
                    sqlCommand.ExecuteNonQuery();

                    job.IDJob = (int)idJob.Value;
                }
            }
        }

        public void Delete(Job job)
        {
            using (SqlConnection sqlConnection = new SqlConnection(cs))
            {
                sqlConnection.Open();
                using (SqlCommand sqlCommand = sqlConnection.CreateCommand())
                {
                    sqlCommand.CommandText = MethodBase.GetCurrentMethod().Name + nameof(Job);
                    sqlCommand.CommandType = System.Data.CommandType.StoredProcedure;

                    sqlCommand.Parameters.AddWithValue(nameof(Job.IDJob), job.IDJob);

                    sqlCommand.ExecuteNonQuery();
                }
            }
        }

        public Job Get(int id)
        {
            using (SqlConnection sqlConnection = new SqlConnection(cs))
            {
                sqlConnection.Open();
                using (SqlCommand sqlCommand = sqlConnection.CreateCommand())
                {
                    sqlCommand.CommandText = MethodBase.GetCurrentMethod().Name + nameof(Job);
                    sqlCommand.CommandType = System.Data.CommandType.StoredProcedure;

                    sqlCommand.Parameters.AddWithValue(nameof(Job.IDJob), id);

                    using (SqlDataReader sqlDataReader = sqlCommand.ExecuteReader())
                    {
                        if (sqlDataReader.Read())
                        {
                            ReadJob(sqlDataReader);
                        }
                    }

                    sqlCommand.ExecuteNonQuery();
                }
            }

            throw new Exception("Wrong id");
        }

        public IList<Job> Get()
        {
            IList<Job> list = new List<Job>();

            using (SqlConnection sqlConnection = new SqlConnection(cs))
            {
                sqlConnection.Open();
                using (SqlCommand sqlCommand = sqlConnection.CreateCommand())
                {
                    sqlCommand.CommandText = MethodBase.GetCurrentMethod().Name + "Jobs";
                    sqlCommand.CommandType = System.Data.CommandType.StoredProcedure;

                    using (SqlDataReader sqlDataReader = sqlCommand.ExecuteReader())
                    {
                        while (sqlDataReader.Read())
                        {
                            list.Add(ReadJob(sqlDataReader));
                        }
                    }

                    sqlCommand.ExecuteNonQuery();
                }

                return list;
            }
        }

        public void Update(Job job)
        {
            using (SqlConnection sqlConnection = new SqlConnection(cs))
            {
                sqlConnection.Open();
                using (SqlCommand sqlCommand = sqlConnection.CreateCommand())
                {
                    sqlCommand.CommandText = MethodBase.GetCurrentMethod().Name + nameof(Job);
                    sqlCommand.CommandType = System.Data.CommandType.StoredProcedure;

                    sqlCommand.Parameters.AddWithValue(nameof(Job.Name), job.Name);
                    sqlCommand.Parameters.AddWithValue(nameof(Job.IDJob), job.IDJob);

                    SqlParameter id = new SqlParameter(nameof(Person.JobID), System.Data.SqlDbType.Int)
                    {
                        Direction = System.Data.ParameterDirection.Output
                    };

                    sqlCommand.ExecuteNonQuery();
                }
            }
        }

        private Job ReadJob(SqlDataReader dr)
        {
            return new Job
            {
                IDJob = (int)dr[nameof(Job.IDJob)],
                Name = dr[nameof(Job.Name)].ToString()
            };
        }
    }
}
