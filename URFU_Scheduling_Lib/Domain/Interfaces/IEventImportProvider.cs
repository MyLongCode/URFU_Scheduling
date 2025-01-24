
using URFU_Scheduling_lib.Domain.Entities;

namespace URFU_Scheduling_lib.Domain.Interfaces
{
    public interface IEventImportProvider<TInput> : IEventImportProvider
    {
        public CSVEvent[] Import(TInput importData);
    }

    public interface IEventImportProvider { }
}