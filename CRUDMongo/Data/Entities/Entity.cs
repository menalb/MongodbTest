using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Data.Entities
{
    public class Entity : IEntity
    {
        [BsonId]
        public ObjectId Id { get; set; }
    }
}