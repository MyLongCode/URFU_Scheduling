using URFU_Scheduling.Domain.Entities;
using URFU_Scheduling.Domain.Interfaces;
using URFU_Scheduling.Infrastructure.Data;
using System;

namespace URFU_Scheduling.Domain.Repositories;

public abstract class BaseRepository<TEntity> : IRepository<TEntity> where TEntity : Entity
{
    protected readonly SchedulingContext _dbContext;

    public BaseRepository(SchedulingContext dbContext)
    {
        _dbContext = dbContext;
    }

    public void Add(TEntity entity)
    {
        _dbContext.Add(entity);
        _dbContext.SaveChanges();
    }

    public void Delete(TEntity entity)
    {
        _dbContext.Remove(entity);
        _dbContext.SaveChanges();
    }

    public TEntity? GetById(Guid id)
    {
        return _dbContext?.Find<TEntity>(id);
    }

    public TEntity[] GetAll()
    {
        return _dbContext.Set<TEntity>().ToArray();
    }

    public void Update(TEntity entity)
    {
        _dbContext.Update(entity);
        _dbContext.SaveChanges();
    }
}

