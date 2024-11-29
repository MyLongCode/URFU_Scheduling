using URFU_Scheduling.Services.Interfaces;
using URFU_Scheduling_lib.Domain.Entities;
using URFU_Scheduling_lib.Domain.Interfaces;
using URFU_Scheduling_lib.Domain.Repositories;

namespace URFU_Scheduling.Services
{
    public class TagService : CRUDService<Tag>, ITagService
    {
        private readonly TagRepository _tagRepo;

        public TagService(TagRepository tagRepository) : base(tagRepository)
        {
            _tagRepo = tagRepository;
        }


    }
}