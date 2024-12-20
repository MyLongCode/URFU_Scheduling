using URFU_Scheduling_lib.Domain.Entities;
using URFU_Scheduling_lib.Domain.Interfaces;

namespace URFU_Scheduling.Services.Interfaces
{
    public interface IScheduleService : ICRUDSerivce<Schedule>
    {
        public List<Schedule> GetAllUserSchedules(Guid userId);
        public bool Export(IScheduleExportProvider provider, Schedule schedule, out object result);

        public Schedule Import(IScheduleImportProvider provider);
    }
}
