namespace DMS_Project.Services.AppointmentService
{
    public interface IAppointmentService
    {
        Task<bool> ValidateAppointmentAsync(int doctorId, DateTime appointmentDateTime, TimeSpan appointmentTime);
    }
}
