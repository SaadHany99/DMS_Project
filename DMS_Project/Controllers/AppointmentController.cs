using DMS_Project.Models.Data;
using DMS_Project.Models.Entities;
using DMS_Project.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace DMS_Project.Controllers
{
    public class AppointmentController : Controller
    {
        private readonly IGenericRepository<Appointment> _repository;
        private readonly ApplicationDbContext _context;
        public AppointmentController(IGenericRepository<Appointment> repository, ApplicationDbContext context)
        {
            _repository = repository;
            _context = context;
        }
        public async Task<IActionResult> Index()
        {
            var appointments =  await _repository.GetAllAsync();
            return View(appointments);
        }

        //Handel link Open Empty View 
        public IActionResult New()
        {
            ViewBag.Patients = new SelectList(_context.Patients, "Id", "Name");
            ViewBag.Doctors = new SelectList(_context.Doctors, "Id", "Name");
            return View("Create");//Model =Null
        }

        //Handel Submit requets (Method Post)
        [HttpPost]
        public async Task<IActionResult> SaveNew(Appointment appointment)
        {
            if (ModelState.IsValid)
            {
                await _repository.AddAsync(appointment);
                return RedirectToAction("Index");
            }

            // If model is not valid, refill the dropdowns
            ViewBag.Patients = new SelectList(_context.Patients.ToList(), "Id", "Name", appointment.PatientId);
            ViewBag.Doctors = new SelectList(_context.Doctors.ToList(), "Id", "Name", appointment.DoctorId);

            return View("Create", appointment);
        }

        public async Task<IActionResult> DeleteAppointment(int id)
        {
            await _repository.DeleteAsync(id);
            return RedirectToAction("Index");
        }
    }
}
