using URFU_Scheduling.Domain.Entities;

namespace URFU_Scheduling.Domain.Interfaces
{
    public interface IScheduleService : ICRUDSerivce<Schedule>
    {
        public bool Export(IScheduleExportProvider provider, Schedule schedule);

        public Schedule Import(IScheduleImportProvider provider);
    }
}
