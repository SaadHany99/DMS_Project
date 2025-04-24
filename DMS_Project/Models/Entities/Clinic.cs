namespace DMS_Project.Models.Entities
{
    public class Clinic : BaseModel
    {
        public virtual List<Doctor> Doctors { get; set; }
    }
}
