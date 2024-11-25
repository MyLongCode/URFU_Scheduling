using URFU_Scheduling.Services.Interfaces;
using URFU_Scheduling_lib.Domain.Entities;
using URFU_Scheduling_lib.Domain.Interfaces;
using URFU_Scheduling_lib.Domain.Repositories;

namespace URFU_Scheduling.Services
{
    public class TagService : ITagService
    {
        private readonly TagRepository _tagRepo;

        public TagService(TagRepository tagRepository)
        {
            _tagRepo = tagRepository;
        }

        public Guid? Create(Tag data) => _tagRepo.Add(data);

        public void Delete(Tag tag) => _tagRepo.Delete(tag);

        public Tag? Get(Guid id) => _tagRepo.GetById(id);

        public void Update(Tag tag) => _tagRepo.Update(tag);
    }
}