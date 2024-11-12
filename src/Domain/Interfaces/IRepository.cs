using URFU_Scheduling.Domain.Entities;

namespace URFU_Scheduling.Domain.Interfaces;
public interface IRepository
{
    TEntity GetById<TEntity>(int id) where TEntity : Entity;
    TEntity Add<TEntity>(TEntity entity) where TEntity : Entity;
    void Update<TEntity>(TEntity entity) where TEntity : Entity;
    void Delete<TEntity>(TEntity entity) where TEntity : Entity;
}