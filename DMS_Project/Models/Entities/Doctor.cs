namespace DMS_Project.Models.Entities
{
    public class Doctor : BaseModel
    {
        public int ClinicId { get; set; }
        public virtual Clinic Clinic { get; set; }
        public virtual List<Schedule> Schedules { get; set; }
    }
}
