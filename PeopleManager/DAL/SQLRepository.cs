using PeopleManager.Model;
using System;
using System.Collections.Generic;

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

        public void AddPerson(Person person)
        {
            throw new NotImplementedException();
        }

        public void DeletePerson(Person person)
        {
            throw new NotImplementedException();
        }

        public IList<Person> GetPeople()
        {
            throw new NotImplementedException();
        }

        public Person GetPerson(int idPerson)
        {
            throw new NotImplementedException();
        }

        public void UpdatePerson(Person person)
        {
            throw new NotImplementedException();
        }
    }
}
