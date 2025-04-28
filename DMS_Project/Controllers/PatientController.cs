using DMS_Project.Models.Entities;
using DMS_Project.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace DMS_Project.Controllers
{
    public class PatientController : Controller
    {
        private readonly IGenericRepository<Patient> _repository;
        public PatientController(IGenericRepository<Patient> repository)
        {
            _repository = repository;
        }

        public async Task<IActionResult> Index()
        {
            var patients = await _repository.GetAllAsync();
            return View(patients);
        }
        public IActionResult New()
        {
            return View("Create");
        }

        [HttpPost]
        public async Task<IActionResult> SaveNew(Patient patient)
        {
            if (ModelState.IsValid)
            {
                await _repository.AddAsync(patient);
                return RedirectToAction("Index");
            }
            return View("Create", patient);
        }

        public async Task<IActionResult> Edit(int id)
        {
            var patient = await _repository.GetByIdAsync(id);
            if (patient == null)
            {
                return NotFound();
            }
            return View("Edit", patient);
        }
        [HttpPost]
        public async Task<IActionResult> SaveEdit(Patient patient)
        {
            if (ModelState.IsValid)
            {
                await _repository.UpdateAsync(patient);
                return RedirectToAction("Index");
            }
            return View("Edit", patient);
        }
        public async Task<IActionResult> Delete(int id)
        {
            await _repository.DeleteAsync(id);
            return RedirectToAction("Index");
        }

    }
}
