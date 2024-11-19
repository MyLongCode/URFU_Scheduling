using URFU_Scheduling.Domain.Entities;

namespace URFU_Scheduling.Domain.Interfaces;
public interface IRepository<TEntity> where TEntity : Entity
{
    TEntity GetById(int id);
    TEntity Add(TEntity entity);
    void Update(TEntity entity);
    void Delete(TEntity entity);
}