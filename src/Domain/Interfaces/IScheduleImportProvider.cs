using URFU_Scheduling.Domain.Entities;

namespace URFU_Scheduling.Domain.Interfaces
{
    public interface IScheduleImportProvider
    {
        public Schedule Import();
    }
}
