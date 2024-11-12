using URFU_Scheduling.Domain.Entities;
using URFU_Scheduling.Domain.Interfaces;
using URFU_Scheduling.Infrastructure.Data;
using System;

namespace URFU_Scheduling.Infrastructure.Data;

public abstract class BaseRepository : IRepository
{
    protected readonly SchedulingContext _dbContext;

    public BaseRepository(SchedulingContext dbContext)
    {
        _dbContext = dbContext;
    }

    public TEntity Add<TEntity>(TEntity entity) where TEntity : Entity
    {
        throw new NotImplementedException();
    }

    public void Delete<TEntity>(TEntity entity) where TEntity : Entity
    {
        throw new NotImplementedException();
    }

    public TEntity GetById<TEntity>(int id) where TEntity : Entity
    {
        throw new NotImplementedException();
    }

    public void Update<TEntity>(TEntity entity) where TEntity : Entity
    {
        throw new NotImplementedException();
    }
}

