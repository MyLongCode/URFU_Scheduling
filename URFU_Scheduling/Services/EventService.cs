using Microsoft.EntityFrameworkCore;
using URFU_Scheduling.Services.Interfaces;
using URFU_Scheduling_lib.Domain.Entities;
using URFU_Scheduling_lib.Domain.Repositories;

namespace URFU_Scheduling.Services
{
    public class EventService : CRUDService<Event>, IEventSerivce
    {
        private readonly EventRepository _eventRepo;
        private readonly ITagService _tagService;

        public EventService(
        EventRepository eventRepository,
            ITagService tagService) : base(eventRepository)
        {
            _eventRepo = eventRepository;
            _tagService = tagService;
        }
    }
}
