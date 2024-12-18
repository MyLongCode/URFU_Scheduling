using System.Diagnostics.Eventing.Reader;
using URFU_Scheduling_lib.Domain.Entities;
using URFU_Scheduling_lib.Domain.Interfaces;

namespace URFU_Scheduling.Services.Interfaces
{
    public interface IScheduleService : ICRUDSerivce<Schedule>
    {
        public bool Export(IScheduleExportProvider provider, Schedule schedule, out object result);

        public bool Import(IScheduleImportProvider provider, byte[] bytes, out object result);
    } 
}
