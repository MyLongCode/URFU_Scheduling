using Microsoft.EntityFrameworkCore.Metadata;
using URFU_Scheduling.Services.Interfaces;
using URFU_Scheduling_lib.Domain.Entities;
using URFU_Scheduling_lib.Domain.Repositories;

namespace URFU_Scheduling.Services
{
    public class RecurrenceService : CRUDService<Recurrence>, IRecurrenceService
    {
        public readonly RecurrenceRepository _recurrenceRepository;

        public RecurrenceService(RecurrenceRepository recurrenceRepository) : base(recurrenceRepository)
        {
            _recurrenceRepository = recurrenceRepository;
        }

        public Recurrence[] GetAllRecurrences()
        {
            return _recurrenceRepository.GetAll();
        }
    }
}
