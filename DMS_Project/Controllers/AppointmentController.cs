using DMS_Project.Models.Entities;
using DMS_Project.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace DMS_Project.Controllers
{
    public class AppointmentController : Controller
    {
        private readonly IGenericRepository<Appointment> _repository;
        public AppointmentController(IGenericRepository<Appointment> repository)
        {
            _repository = repository;
        }
        public async Task<IActionResult> Index()
        {
            var appointments =  await _repository.GetAllAsync();
            return View(appointments);
        }

        //Handel link Open Empty View 
        public IActionResult New()
        {
            return View("Create");//Model =Null
        }

        //Handel Submit requets (Method Post)
        [HttpPost]
        public async Task<IActionResult> SaveNew(Appointment appointment)//request method Post
        {
            if (ModelState.IsValid)
            {
                await _repository.AddAsync(appointment);
                return RedirectToAction("Index");//return to the index action in the same controller
            }
            return View("Create", appointment);

        }

        public async Task<IActionResult> DeleteAppointment(int id)
        {
            await _repository.DeleteAsync(id);
            return RedirectToAction("Index");
        }
    }
}
