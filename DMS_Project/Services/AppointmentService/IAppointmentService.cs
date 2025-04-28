using DMS_Project.Models.Helper;

namespace DMS_Project.Services.AppointmentService
{
    public interface IAppointmentService
    {
        Task<GeneralResponse> ValidateAppointmentAsync(int doctorId, DateTime appointmentDateTime, TimeSpan appointmentTime, int Duration);
    }
}
