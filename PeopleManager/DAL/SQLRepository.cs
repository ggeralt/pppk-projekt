using PeopleManager.Model;
using PeopleManager.Utility;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Reflection;

namespace PeopleManager.DAL
{
    internal class SQLRepository : IRepository
    {
        private const string IDPersonParameter = "@idPerson";
        private const string FirstNameParameter = "@firstname";
        private const string LastNameParameter = "@lastname";
        private const string AgeParameter = "@age";
        private const string EmailParameter = "@email";
        private const string PictureParameter = "@picture";
        private static string cs = ConfigurationManager.ConnectionStrings["cs"].ConnectionString;

        public void AddPerson(Person person)
        {
            using (SqlConnection sqlConnection = new SqlConnection(cs))
            {
                sqlConnection.Open();
                using (SqlCommand sqlCommand = sqlConnection.CreateCommand())
                {
                    sqlCommand.CommandText = MethodBase.GetCurrentMethod().Name;
                    sqlCommand.CommandType = System.Data.CommandType.StoredProcedure;

                    sqlCommand.Parameters.AddWithValue(nameof(Person.FirstName), person.FirstName);
                    sqlCommand.Parameters.AddWithValue(nameof(Person.LastName), person.LastName);
                    sqlCommand.Parameters.AddWithValue(nameof(Person.Age), person.Age);
                    sqlCommand.Parameters.AddWithValue(nameof(Person.Email), person.Email);

                    sqlCommand.Parameters.Add(new SqlParameter(
                        nameof(Person.Picture), 
                        System.Data.SqlDbType.Binary, 
                        person.Picture.Length)
                    {
                        Value = person.Picture
                    });

                    SqlParameter idPerson = new SqlParameter(nameof(Person.IDPerson), System.Data.SqlDbType.Int)
                    {
                        Direction = System.Data.ParameterDirection.Output
                    };

                    sqlCommand.Parameters.Add(idPerson);

                    sqlCommand.ExecuteNonQuery();

                    person.IDPerson = (int)idPerson.Value;
                }
            }
        }

        public void DeletePerson(Person person)
        {
            using (SqlConnection sqlConnection = new SqlConnection(cs))
            {
                sqlConnection.Open();
                using (SqlCommand sqlCommand = sqlConnection.CreateCommand())
                {
                    sqlCommand.CommandText = MethodBase.GetCurrentMethod().Name;
                    sqlCommand.CommandType = System.Data.CommandType.StoredProcedure;

                    sqlCommand.Parameters.AddWithValue(nameof(Person.IDPerson), person.IDPerson);

                    sqlCommand.ExecuteNonQuery();
                }
            }
        }

        public IList<Person> GetPeople()
        {
            IList<Person> people = new List<Person>();

            using (SqlConnection sqlConnection = new SqlConnection(cs))
            {
                sqlConnection.Open();
                using (SqlCommand sqlCommand = sqlConnection.CreateCommand())
                {
                    sqlCommand.CommandText = MethodBase.GetCurrentMethod().Name;
                    sqlCommand.CommandType = System.Data.CommandType.StoredProcedure;

                    using (SqlDataReader sqlDataReader = sqlCommand.ExecuteReader())
                    {
                        while (sqlDataReader.Read())
                        {
                            people.Add(ReadPerson(sqlDataReader));
                        }
                    }
                }
            }

            return people;
        }

        public Person GetPerson(int idPerson)
        {
            using (SqlConnection sqlConnection = new SqlConnection(cs))
            {
                sqlConnection.Open();
                using (SqlCommand sqlCommand = sqlConnection.CreateCommand())
                {
                    sqlCommand.CommandText = MethodBase.GetCurrentMethod().Name;
                    sqlCommand.CommandType = System.Data.CommandType.StoredProcedure;

                    sqlCommand.Parameters.AddWithValue(nameof(Person.IDPerson), idPerson);
                    using (SqlDataReader sqlDataReader = sqlCommand.ExecuteReader())
                    {
                        if (sqlDataReader.Read())
                        {
                            ReadPerson(sqlDataReader);
                        }
                    }
                }
            }

            throw new Exception("Wrong person ID.");
        }

        public void UpdatePerson(Person person)
        {
            using (SqlConnection sqlConnection = new SqlConnection(cs))
            {
                sqlConnection.Open();
                using (SqlCommand sqlCommand = sqlConnection.CreateCommand())
                {
                    sqlCommand.CommandText = MethodBase.GetCurrentMethod().Name;
                    sqlCommand.CommandType = System.Data.CommandType.StoredProcedure;

                    sqlCommand.Parameters.AddWithValue(nameof(Person.IDPerson), person.IDPerson);
                    sqlCommand.Parameters.AddWithValue(nameof(Person.FirstName), person.FirstName);
                    sqlCommand.Parameters.AddWithValue(nameof(Person.LastName), person.LastName);
                    sqlCommand.Parameters.AddWithValue(nameof(Person.Age), person.Age);
                    sqlCommand.Parameters.AddWithValue(nameof(Person.Email), person.Email);
                    
                    sqlCommand.Parameters.Add(new SqlParameter(
                        nameof(Person.Picture),
                        System.Data.SqlDbType.Binary,
                        person.Picture.Length)
                    {
                        Value = person.Picture
                    });

                    sqlCommand.ExecuteNonQuery();
                }
            }
        }

        private Person ReadPerson(SqlDataReader sqlDataReader)
        => new Person
        {
            IDPerson = (int)sqlDataReader[nameof(Person.IDPerson)],
            FirstName = sqlDataReader[nameof(Person.FirstName)].ToString(),
            LastName = sqlDataReader[nameof(Person.LastName)].ToString(),
            Age = (int)sqlDataReader[nameof(Person.Age)],
            Email = sqlDataReader[nameof(Person.Email)].ToString(),
            Picture = ImageUtilities.ByteArrayFromSqlDataReader(sqlDataReader, 5)
        };
    }
}
