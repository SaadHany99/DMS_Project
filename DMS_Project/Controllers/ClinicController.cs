using DMS_Project.Models.Entities;
using DMS_Project.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace DMS_Project.Controllers
{
    public class ClinicController : Controller
    {
        private readonly IGenericRepository<Clinic> _repository;
        public ClinicController(IGenericRepository<Clinic> repository)
        {
            _repository = repository;
        }
        // GET: Clinic
        public async Task<IActionResult> Index()
        {
            var clinics = await _repository.GetAllAsync();
            return View(clinics);
        }
        public IActionResult New()
        {
            return View("Create");
        }
        //Handel Submit requets (Method Post)
        [HttpPost]
        public async Task<IActionResult> SaveNew(Clinic clinic)
        {
            if (ModelState.IsValid)
            {
                await _repository.AddAsync(clinic);
                return RedirectToAction("Index");
            }
            return View("Create", clinic);
        }
        public async Task<IActionResult> Edit(int id)
        {
            var clinic = await _repository.GetByIdAsync(id);
            if (clinic == null)
            {
                return NotFound();
            }
            return View("Edit", clinic);
        }
        [HttpPost]
        public async Task<IActionResult> SaveEdit(Clinic clinic)
        {
            if (ModelState.IsValid)
            {
                await _repository.UpdateAsync(clinic);
                return RedirectToAction("Index");
            }
            return View("Edit", clinic);
        }
        public async Task<IActionResult> Delete(int id)
        {
            await _repository.DeleteAsync(id);
            return RedirectToAction("Index");
        }
    }
}
