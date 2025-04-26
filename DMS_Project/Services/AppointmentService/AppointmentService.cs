using DMS_Project.Models.Data;
using Microsoft.EntityFrameworkCore;
using System;

namespace DMS_Project.Services.AppointmentService
{
    public class AppointmentService : IAppointmentService
    {
        private readonly ApplicationDbContext _context;
        public AppointmentService(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<bool> ValidateAppointmentAsync(int doctorId, DateTime appointmentDateTime, TimeSpan appoinmetTime)
        {
            var dayOfWeek = appointmentDateTime.DayOfWeek.ToString();

            // 1. تأكد الدكتور عنده جدول عمل في اليوم ده
            var schedule = await _context.Schedules
                .FirstOrDefaultAsync(s => s.DoctorId == doctorId && s.DayOfWeek == dayOfWeek);

            if (schedule == null)
                return false; // مفيش جدول للدكتور في اليوم ده

            // 2. تأكد ميعاد الحجز داخل ساعات العمل
            //var appointmentTime = appointmentDateTime.TimeOfDay;


            //if (appoinmetTime.Hours > 12)
            //{
            //    appoinmetTime= appoinmetTime.Hours-12;
            //}
            // Convert appointment time to 12-hour format if necessary
            TimeSpan adjustedAppointmentTime = appoinmetTime.Hours > 12
                ? appoinmetTime.Subtract(TimeSpan.FromHours(12))
                : appoinmetTime;

            if (adjustedAppointmentTime < schedule.StartTime || adjustedAppointmentTime > schedule.EndTime)
                return false; // الحجز خارج ساعات العمل

            // 3. تأكد مفيش حجز تاني في نفس الوقت
            bool conflict = await _context.Appointments
                .AnyAsync(a => a.DoctorId == doctorId && a.AppointmentDate == appointmentDateTime);

            if (conflict)
                return false; // فيه حجز تاني في نفس الميعاد

            return true; // ✅ الميعاد متاح
        }
    }

}
