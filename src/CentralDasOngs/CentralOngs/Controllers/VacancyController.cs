using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CentralOngs;
using CentralOngs.Models;
using Microsoft.AspNetCore.Authorization;

namespace CentralOngs.Controllers
{
    [Authorize]
    public class VacancyController : Controller
    {
        private readonly DatabaseContext _context;

        public VacancyController(DatabaseContext context)
        {
            _context = context;
        }

        // GET: Vacancy
        public async Task<IActionResult> Index()
        {
            var databaseContext = _context.VacancyModel.Include(v => v.Job).Include(v => v.UserVoluntario);
            return View(await databaseContext.ToListAsync());
        }

        // GET: Vacancy/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.VacancyModel == null)
            {
                return NotFound();
            }

            var vacancyModel = await _context.VacancyModel
                .Include(v => v.Job)
                .Include(v => v.UserVoluntario)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (vacancyModel == null)
            {
                return NotFound();
            }

            return View(vacancyModel);
        }

        // GET: Vacancy/Create
        public IActionResult Create()
        {
            ViewData["JobId"] = new SelectList(_context.JobModel, "Id", "Description");
            ViewData["UserVoluntarioId"] = new SelectList(_context.UserVoluntarioModel, "Id", "Contact");
            return View();
        }

        // POST: Vacancy/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,UserVoluntarioAbout,JobId,UserVoluntarioId")] VacancyModel vacancyModel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(vacancyModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["JobId"] = new SelectList(_context.JobModel, "Id", "Description", vacancyModel.JobId);
            ViewData["UserVoluntarioId"] = new SelectList(_context.UserVoluntarioModel, "Id", "Contact", vacancyModel.UserVoluntarioId);
            return View(vacancyModel);
        }

        // GET: Vacancy/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.VacancyModel == null)
            {
                return NotFound();
            }

            var vacancyModel = await _context.VacancyModel.FindAsync(id);
            if (vacancyModel == null)
            {
                return NotFound();
            }
            ViewData["JobId"] = new SelectList(_context.JobModel, "Id", "Description", vacancyModel.JobId);
            ViewData["UserVoluntarioId"] = new SelectList(_context.UserVoluntarioModel, "Id", "Contact", vacancyModel.UserVoluntarioId);
            return View(vacancyModel);
        }

        // POST: Vacancy/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,UserVoluntarioAbout,JobId,UserVoluntarioId")] VacancyModel vacancyModel)
        {
            if (id != vacancyModel.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(vacancyModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!VacancyModelExists(vacancyModel.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["JobId"] = new SelectList(_context.JobModel, "Id", "Description", vacancyModel.JobId);
            ViewData["UserVoluntarioId"] = new SelectList(_context.UserVoluntarioModel, "Id", "Contact", vacancyModel.UserVoluntarioId);
            return View(vacancyModel);
        }

        // GET: Vacancy/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.VacancyModel == null)
            {
                return NotFound();
            }

            var vacancyModel = await _context.VacancyModel
                .Include(v => v.Job)
                .Include(v => v.UserVoluntario)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (vacancyModel == null)
            {
                return NotFound();
            }

            return View(vacancyModel);
        }

        // POST: Vacancy/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.VacancyModel == null)
            {
                return Problem("Entity set 'DatabaseContext.VacancyModel'  is null.");
            }
            
            var vacancyModel = await _context.VacancyModel
                .Include(v => v.Job)
                .Include(v => v.UserVoluntario)
                .FirstOrDefaultAsync(m => m.Id == id);
            
            if (vacancyModel != null)
            {
                _context.VacancyModel.Remove(vacancyModel);
            }
            await _context.SaveChangesAsync();
            
            if (User.Claims.ElementAt(3).Value == "Ong")
            {
                return RedirectToAction("AllCandidates", "Job", new { id = vacancyModel.JobId });
            }

            else if (User.Claims.ElementAt(3).Value == "Voluntario")
            {
                return RedirectToAction("MyVacancies", "Voluntarios", new { id = vacancyModel.UserVoluntarioId });
            }
            return View();

        }

        private bool VacancyModelExists(int id)
        {
          return _context.VacancyModel.Any(e => e.Id == id);
        }
    }
}
