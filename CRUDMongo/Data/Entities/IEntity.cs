using MongoDB.Bson;

namespace Data.Entities
{
    public interface IEntity
    {
        ObjectId Id { get; set; }
    }
}