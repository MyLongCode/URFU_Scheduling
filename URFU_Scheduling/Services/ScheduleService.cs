using URFU_Scheduling.Controllers.DTO;
using URFU_Scheduling.Services.Interfaces;
using URFU_Scheduling_lib.Domain.Entities;
using URFU_Scheduling_lib.Domain.Interfaces;
using URFU_Scheduling_lib.Domain.Repositories;

namespace URFU_Scheduling.Services
{
    public class ScheduleService : CRUDService<Schedule>, IScheduleService
    {
        private readonly ScheduleRepository _scheduleRepo;
        private readonly IEventService _eventService;
        private readonly ITagService _tagService;

        public ScheduleService(
            ScheduleRepository scheduleRepository,
            IEventService eventService,
            ITagService tagService) : base(scheduleRepository)
        {
            _scheduleRepo = scheduleRepository;
            _eventService = eventService;
            _tagService = tagService;
        }

        public bool Export(IScheduleExportProvider provider, Schedule schedule, out object result)
        {
            try
            {
                result = provider.Export(schedule);
                return true;
            }
            catch
            {
                result = null;
                return false;
            }
        }

        public bool  Import(IScheduleImportProvider provider, byte[] bytes, out object result)
        {
            try
            {
                result = provider.Import(bytes);
                return true;
            }
            catch
            {
                result = null;
                return false;
            }
        }
    }
}
