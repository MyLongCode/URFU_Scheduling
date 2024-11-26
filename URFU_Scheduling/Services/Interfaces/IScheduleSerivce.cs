using URFU_Scheduling_lib.Domain.Entities;
using URFU_Scheduling_lib.Domain.Interfaces;

namespace URFU_Scheduling.Services.Interfaces
{
    public interface IScheduleService : ICRUDSerivce<Schedule>
    {
        public bool Export(IScheduleExportProvider provider, Schedule schedule);

        public Schedule Import(IScheduleImportProvider provider);
    }
}
