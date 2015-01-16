using Data.Entities;
using MongoDB.Bson;
using MongoDB.Driver;
using MongoDB.Driver.Builders;

namespace Data.Repositories
{
    public abstract class Repository<T> : IRepository<T> where T : IEntity
    {
        protected readonly MongoConnectionHandler<T> MongoConnectionHandler;

        public virtual void Create(T entity)
        {
            var result = MongoConnectionHandler.MongoCollection.Save(entity,
                                                                          new MongoInsertOptions
                                                                              {
                                                                                  WriteConcern = WriteConcern.Acknowledged
                                                                              });
            if (!result.Ok)
            {

            }
        }

        public virtual void Delete(string id)
        {
            var result =
                MongoConnectionHandler.MongoCollection.Remove(Query<T>.EQ(e => e.Id, new ObjectId(id)), RemoveFlags.None,
                                                                          WriteConcern.Acknowledged);
            if (!result.Ok)
            {

            }
        }

        protected Repository(string connectionString, string dbName)
        {
            MongoConnectionHandler = new MongoConnectionHandler<T>(connectionString, dbName, "library");
        }

        public virtual T GetById(string id)
        {
            var entityQuery = Query<T>.EQ(e => e.Id, new ObjectId(id));
            return MongoConnectionHandler.MongoCollection.FindOne(entityQuery);
        }

        public abstract void Update(T enity);

    }
}