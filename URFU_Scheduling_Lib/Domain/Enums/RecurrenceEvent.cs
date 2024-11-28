using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace URFU_Scheduling_lib.Domain.Enums
{
    public enum RecurrenceEvent
    {
        Daily = 1,
        Weekly = 2,
        Weekdays = 3, 
        Weekends = 4, 
        Monthly = 5, 
        Yearly = 6,
        Never = 7, 
        OnceIn10000Years = 8
    }
}
