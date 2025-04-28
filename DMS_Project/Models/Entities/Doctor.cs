using System.ComponentModel.DataAnnotations;

namespace DMS_Project.Models.Entities
{
    public class Doctor : BaseModel
    {
        [Required(ErrorMessage = "Clinic is required.")]
        public int ClinicId { get; set; }

        public virtual Clinic Clinic { get; set; }

        public virtual List<Schedule> Schedules { get; set; }
    }
}
