namespace URFU_Scheduling_lib.Domain.Entities
{
    public class CSVEvent
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime DateStart { get; set; }
        public TimeSpan Duration { get; set; }
    }
}
