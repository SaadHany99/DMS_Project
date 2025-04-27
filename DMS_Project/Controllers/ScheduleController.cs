using DMS_Project.Models.Entities;
using DMS_Project.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace DMS_Project.Controllers
{
    public class ScheduleController : Controller
    {
        private readonly IGenericRepository<Schedule> _repository;
        public ScheduleController(IGenericRepository<Schedule> repository)
        {
            _repository = repository;
        }
        public async Task<IActionResult> Index()
        {
            var schedules = await _repository.GetAllAsync();
            return View(schedules);
        }
        //Handel link Open Empty View
        public IActionResult New()
        {
            return View("Create");
        }
        //Handel Submit requets (Method Post)
        [HttpPost]
        public async Task<IActionResult> SaveNew(Schedule schedule)
        {
            if (ModelState.IsValid)
            {
                // Save the schedule
                await _repository.AddAsync(schedule);
                return RedirectToAction("Index");
            }
            return View("Create", schedule);
        }
        public async Task<IActionResult> Edit(int id)
        {
            var schedule = await _repository.GetByIdAsync(id);
            if (schedule == null)
            {
                return NotFound();
            }
            return View("Edit", schedule);
        }
        [HttpPost]
        public async Task<IActionResult> SaveEdit(Schedule schedule)
        {
            if (ModelState.IsValid)
            {
                await _repository.UpdateAsync(schedule);
                return RedirectToAction("Index");
            }
            return View("Edit", schedule);
        }
        public async Task<IActionResult> Delete(int id)
        {
            await _repository.DeleteAsync(id);
            return RedirectToAction("Index");
        }
    }
}
