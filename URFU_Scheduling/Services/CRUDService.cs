using URFU_Scheduling_lib.Domain.Entities;
using URFU_Scheduling_lib.Domain.Interfaces;
using URFU_Scheduling_lib.Domain.Repositories;

namespace URFU_Scheduling.Services
{
    public abstract class CRUDService<T> where T : Entity
    {
        private readonly BaseRepository<T> _repo;

        public CRUDService(BaseRepository<T> repo)
        {
            _repo = repo;
        }

        public Guid? Create(T data) => _repo.Add(data);

        public void Delete(T schedule) => _repo.Delete(schedule);

        public T? Get(Guid id) => _repo.GetById(id);

        public void Update(T schedule) => _repo.Update(schedule);

        public T[] GetAll() => _repo.GetAll();
    }
}
