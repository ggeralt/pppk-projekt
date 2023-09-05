using Microsoft.Azure.Cosmos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Todo.Models;

namespace Todo.DAO
{
    public class CosmosDbService : ICosmosDbService
    {
        private readonly Container container;

        public CosmosDbService(CosmosClient cosmosClient, string databaseName, string containerName)
        {
            container = cosmosClient.GetContainer(databaseName, containerName);
        }

        public async Task AddItemAsync(Item item)
            => await container.CreateItemAsync(item, new PartitionKey(item.Id));

        public async Task AddPersonAsync(Person person)
            => await container.CreateItemAsync(person, new PartitionKey(person.Id));

        public async Task DeleteItemAsync(Item item)
            => await container.DeleteItemAsync<Item>(item.Id, new PartitionKey(item.Id));

        public async Task DeletePersonAsync(Person person)
            => await container.DeleteItemAsync<Item>(person.Id, new PartitionKey(person.Id));

        public async Task<Item> GetItemAsync(string id)
        {
            try
            {
                return await container.ReadItemAsync<Item>(id, new PartitionKey(id));
            }
            catch (CosmosException e)
            when (e.StatusCode == System.Net.HttpStatusCode.NotFound)
            {
                return null;
            }
        }

        public async Task<IEnumerable<Item>> GetItemsAsync(string queryString)
        {
            List<Item> items = new List<Item>();
            var query = container.GetItemQueryIterator<Item>(new QueryDefinition(queryString));

            while (query.HasMoreResults)
            {
                var result = await query.ReadNextAsync();
                items.AddRange(result.ToList());
            }

            return items;
        }

        public async Task<Person> GetPersonAsync(string id)
        {
            try
            {
                return await container.ReadItemAsync<Person>(id, new PartitionKey(id));
            }
            catch (CosmosException e)
            when (e.StatusCode == System.Net.HttpStatusCode.NotFound)
            {
                return null;
            }
        }

        public async Task<IEnumerable<Person>> GetPeopleAsync(string queryString)
        {
            List<Person> people = new List<Person>();
            var query = container.GetItemQueryIterator<Person>(new QueryDefinition(queryString));

            while (query.HasMoreResults)
            {
                var result = await query.ReadNextAsync();
                people.AddRange(result.ToList());
            }

            return people;
        }

        public async Task UpdateItemAsync(Item item)
            => await container.UpsertItemAsync(item, new PartitionKey(item.Id));

        public async Task UpdatePersonAsync(Person person)
            => await container.UpsertItemAsync(person, new PartitionKey(person.Id));
    }
}