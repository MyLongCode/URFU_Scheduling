using URFU_Scheduling.Services.Interfaces;
using URFU_Scheduling_lib.Domain.Entities;
using URFU_Scheduling_lib.Domain.Interfaces;
using URFU_Scheduling_lib.Domain.Repositories;

namespace URFU_Scheduling.Services
{
    public class ScheduleService : IScheduleService
    {
        private readonly ScheduleRepository _scheduleRepo;
        private readonly IEventSerivce _eventService;
        private readonly ITagService _tagService;


        public ScheduleService(
            ScheduleRepository scheduleRepository,
            IEventSerivce eventService,
            ITagService tagService)
        {
            _scheduleRepo = scheduleRepository;
            _eventService = eventService;
            _tagService = tagService;
        }

        public bool Export(IScheduleExportProvider provider, Schedule schedule)
        {
            throw new NotImplementedException();
        }

        public Schedule Import(IScheduleImportProvider provider)
        {
            throw new NotImplementedException();
        }

        public bool Update(Schedule schedule)
        {
            throw new NotImplementedException();
        }

        public Schedule? Create(object? data)
        {
            throw new NotImplementedException();
        }

        public bool Delete(Schedule schedule)
        {
            throw new NotImplementedException();
        }

        public Schedule? Get(object? data)
        {
            throw new NotImplementedException();
        }
    }
}
