using URFU_Scheduling.Services.Interfaces;
using URFU_Scheduling_lib.Domain.Entities;
using URFU_Scheduling_lib.Domain.Repositories;

namespace URFU_Scheduling.Services
{
    public class EventService : IEventSerivce
    {
        private readonly EventRepository _eventRepo;
        private readonly ITagService _tagService;

        public EventService(
            EventRepository eventRepository,
            ITagService tagService)
        {
            _eventRepo = eventRepository;
            _tagService = tagService;
        }

        public Event? Create(object? data)
        {
            throw new NotImplementedException();
        }

        public bool Delete(Event schedule)
        {
            throw new NotImplementedException();
        }

        public Event? Get(object? data)
        {
            throw new NotImplementedException();
        }

        public bool Update(Event schedule)
        {
            throw new NotImplementedException();
        }
    }
}
