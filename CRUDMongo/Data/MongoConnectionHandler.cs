using Data.Entities;
using MongoDB.Driver;

namespace Data
{
    public class MongoConnectionHandler<T> where T: IEntity
    {
        public MongoCollection<T> MongoCollection { get; private set; }

        public MongoConnectionHandler(string connectionString, string dbName, string collectionName)
        {
            var client = new MongoClient(connectionString);
            var server = client.GetServer();
            var db = server.GetDatabase(dbName);
            MongoCollection = db.GetCollection<T>(collectionName);
        } 
    }
}