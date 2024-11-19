using URFU_Scheduling_lib.Domain.Entities;

namespace URFU_Scheduling_lib.Domain.Interfaces
{
    public interface IScheduleExportProvider
    {
        public void Export(Schedule shedule);
    }
}
