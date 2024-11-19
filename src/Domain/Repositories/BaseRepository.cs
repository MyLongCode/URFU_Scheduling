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

    public TEntity Add(TEntity entity)
    {
        throw new NotImplementedException();
    }

    public void Delete(TEntity entity)
    {
        throw new NotImplementedException();
    }

    public TEntity GetById(int id)
    {
        throw new NotImplementedException();
    }

    public void Update(TEntity entity)
    {
        throw new NotImplementedException();
    }
}

