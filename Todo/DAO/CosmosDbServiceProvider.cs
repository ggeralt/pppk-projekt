using Microsoft.Azure.Cosmos;
using System.Threading.Tasks;

namespace Todo.DAO
{
    public static class CosmosDbServiceProvider
    {
        // constants for Azure Cosmos DB Emulator 
        private const string DatabaseName = "SampleDB";
        private const string ContainerName = "Todo";
        private const string PartitionKey = "/TodoPartitionKey";
        private const string Account = "https://localhost:8081";
        private const string Key = "C2y6yDjf5/R+ob0N8A7Cgv30VRDJIWEHLM+4QDU5DE2nQ9nDuVTqobD4b8mGGyPMbIZnqyMsEcaGQy67XIw/Jw==";
        //

        private static ICosmosDbService cosmosDbService;

        public static ICosmosDbService CosmosDbService { get => cosmosDbService; }

        public static async Task Init()
        {
            CosmosClient cosmosClient = new CosmosClient(Account, Key);
            cosmosDbService = new CosmosDbService(cosmosClient, DatabaseName, ContainerName);
            DatabaseResponse databaseResponse = await cosmosClient.CreateDatabaseIfNotExistsAsync(DatabaseName);
            await databaseResponse.Database.CreateContainerIfNotExistsAsync(ContainerName, PartitionKey);
        }
    }
}