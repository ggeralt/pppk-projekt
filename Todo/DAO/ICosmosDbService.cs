using System.Collections.Generic;
using System.Threading.Tasks;
using Todo.Models;

namespace Todo.DAO
{
    public interface ICosmosDbService
    {
        Task<IEnumerable<Item>> GetItemsAsync(string query);
        Task<Item> GetItemAsync(string id);
        Task AddItemAsync(Item item);
        Task UpdateItemAsync(Item item);
        Task DeleteItemAsync(Item item);
    }
}
