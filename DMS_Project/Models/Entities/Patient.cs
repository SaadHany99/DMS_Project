using System.ComponentModel.DataAnnotations.Schema;

namespace DMS_Project.Models.Entities
{
    public class Patient : BaseModel
    {
        public DateTime BirthDate { get; set; }

        [NotMapped]
        public int Age
        {
            get
            {
                var today = DateTime.Today;
                var age = today.Year - BirthDate.Year;

                // Subtract 1 if the birthday hasn't occurred yet this year
                if (BirthDate.Date > today.AddYears(-age))
                {
                    age--;
                }

                return age;
            }
        }
    }
}
