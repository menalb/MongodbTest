using Data.Entities;

namespace Data.Repositories
{
    public interface IRepository<T> where T : IEntity
    {
        void Create(T entity);
        void Delete(string id);
        T GetById(string id);
        void Update(T entity);
    }
}