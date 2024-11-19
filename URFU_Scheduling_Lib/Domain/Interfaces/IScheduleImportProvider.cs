using URFU_Scheduling_lib.Domain.Entities;

namespace URFU_Scheduling_lib.Domain.Interfaces
{
    public interface IScheduleImportProvider
    {
        public Schedule Import();
    }
}
