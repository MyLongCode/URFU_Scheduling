using URFU_Scheduling_lib.Domain.Entities;

namespace URFU_Scheduling_lib.Domain.Interfaces;
public interface IRepository<TEntity> where TEntity : Entity
{
    TEntity? GetById(Guid id);
    TEntity[] GetAll();
    Guid Add(TEntity entity);
    void Update(TEntity entity);
    void Delete(TEntity entity);
}