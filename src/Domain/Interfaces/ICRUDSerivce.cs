public interface ICRUDSerivce<TEntity>
    {

        public TEntity? Create(object? data);

        public TEntity? Get(object? data);

        public bool Update(TEntity entity);

        public bool Delete(TEntity entity);
    }