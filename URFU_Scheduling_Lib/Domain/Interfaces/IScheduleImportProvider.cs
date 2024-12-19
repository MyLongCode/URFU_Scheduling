using URFU_Scheduling_lib.Domain.Entities;

namespace URFU_Scheduling_lib.Domain.Interfaces
{
    public interface IScheduleImportProvider
    {
        public List<Event> Import(byte[] bytes);
    }
}
