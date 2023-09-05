using System.Collections.Generic;
using System.Threading.Tasks;
using Todo.Models;

namespace Todo.DAO
{
    public interface ICosmosDbService
    {
        Task<IEnumerable<Item>> GetItemsAsync(string queryString);
        Task<Item> GetItemAsync(string id);
        Task AddItemAsync(Item item);
        Task UpdateItemAsync(Item item);
        Task DeleteItemAsync(Item item);

        Task<IEnumerable<Person>> GetPeopleAsync(string queryString);
        Task<Person> GetPersonAsync(string id);
        Task AddPersonAsync(Person person);
        Task UpdatePersonAsync(Person person);
        Task DeletePersonAsync(Person person);
    }
}
