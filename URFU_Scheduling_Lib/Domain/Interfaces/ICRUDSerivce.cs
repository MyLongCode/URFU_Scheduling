namespace URFU_Scheduling_lib.Domain.Interfaces;
public interface ICRUDSerivce<TEntity>
{
    public Guid? Create(TEntity data);

    public TEntity? Get(Guid id);

    public void Update(TEntity entity);

    public void Delete(TEntity entity);
}