namespace DMS_Project.Models.Entities
{
    public class Schedule
    {
        public int Id { get; set; }
        public int DoctorId { get; set; }
        public virtual Doctor Doctor { get; set; }
        public string DayOfWeek { get; set; } = string.Empty;
        public TimeSpan StartTime { get; set; }
        public TimeSpan EndTime { get; set; }
    
    }
}
