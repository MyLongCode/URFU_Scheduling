using URFU_Scheduling.Domain.Entities;
using URFU_Scheduling.Domain.Interfaces;
using URFU_Scheduling.Domain.Repositories;

namespace URFU_Scheduling.Domain.Services
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