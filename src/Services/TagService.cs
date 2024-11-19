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

        public Tag? Create(object? data)
        {
            throw new NotImplementedException();
        }

        public bool Delete(Tag tag)
        {
            throw new NotImplementedException();
        }

        public Tag? Get(object? data)
        {
            throw new NotImplementedException();
        }

        public bool Update(Tag tag)
        {
            throw new NotImplementedException();
        }
    }
}