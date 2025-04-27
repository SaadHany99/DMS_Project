using DMS_Project.Models.Entities;
using DMS_Project.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace DMS_Project.Controllers
{
    public class DoctorController : Controller
    {
        private readonly IGenericRepository<Doctor> _repository;
        public DoctorController(IGenericRepository<Doctor> repository)
        {
            _repository = repository;
        }
        public async Task<IActionResult> Index()
        {
            var doctors = await _repository.GetAllAsync();
            return View(doctors);
        }

        public IActionResult New()
        {
            return View("Create");
        }
        [HttpPost]
        public async Task<IActionResult> SaveNew(Doctor doctor)
        {
            if (ModelState.IsValid)
            {
                await _repository.AddAsync(doctor);
                return RedirectToAction("Index");
            }
            return View("Create", doctor);
        }
        public async Task<IActionResult> Edit(int id)
        {
            var doctor = await _repository.GetByIdAsync(id);
            if (doctor == null)
            {
                return NotFound();
            }
            return View("Edit", doctor);
        }
        [HttpPost]
        public async Task<IActionResult> SaveEdit(Doctor doctor)
        {
            if (ModelState.IsValid)
            {
                await _repository.UpdateAsync(doctor);
                return RedirectToAction("Index");
            }
            return View("Edit", doctor);
        }
        public async Task<IActionResult> Delete(int id)
        {
            await _repository.DeleteAsync(id);
            return RedirectToAction("Index");
        }
    }
}
