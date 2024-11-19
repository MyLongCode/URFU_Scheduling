using URFU_Scheduling.Domain.Entities;

namespace URFU_Scheduling.Domain.Interfaces
{
    public interface IScheduleExportProvider
    {
        public void Export(Schedule shedule);
    }
}
