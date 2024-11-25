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

        public Guid? Create(Event data) => _eventRepo.Add(data);

        public void Delete(Event schedule) => _eventRepo.Delete(schedule);

        public Event? Get(Guid id) => _eventRepo.GetById(id);

        public void Update(Event schedule) => _eventRepo.Update(schedule);
    }
}
