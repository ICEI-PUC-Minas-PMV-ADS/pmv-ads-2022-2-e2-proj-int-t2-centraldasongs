using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CentralOngs;
using CentralOngs.Models;

namespace CentralOngs.Controllers
{
    public class JobController : Controller
    {
        private readonly DatabaseContext _context;

        public JobController(DatabaseContext context)
        {
            _context = context;
        }

        // GET: Job
        public async Task<IActionResult> Index()
        {
            var databaseContext = _context.JobModel.Include(j => j.UserOng);
            return View(await databaseContext.ToListAsync());
        }

        // GET: Job/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.JobModel == null)
            {
                return NotFound();
            }

            var jobModel = await _context.JobModel
                .Include(j => j.UserOng)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (jobModel == null)
            {
                return NotFound();
            }

            return View(jobModel);
        }

        // GET: Job/Create
        public IActionResult Create()
        {
            ViewData["UserOngId"] = new SelectList(_context.UserOngModel, "Id", "Contact");
            return View();
        }

        // POST: Job/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,NumberOfVacancies,Description,UserOngId")] JobModel jobModel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(jobModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["UserOngId"] = new SelectList(_context.UserOngModel, "Id", "Contact", jobModel.UserOngId);
            return View(jobModel);
        }

        // GET: Job/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.JobModel == null)
            {
                return NotFound();
            }

            var jobModel = await _context.JobModel.FindAsync(id);
            if (jobModel == null)
            {
                return NotFound();
            }
            ViewData["UserOngId"] = new SelectList(_context.UserOngModel, "Id", "Contact", jobModel.UserOngId);
            return View(jobModel);
        }

        // POST: Job/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,NumberOfVacancies,Description,UserOngId")] JobModel jobModel)
        {
            if (id != jobModel.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(jobModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!JobModelExists(jobModel.Id))
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
            ViewData["UserOngId"] = new SelectList(_context.UserOngModel, "Id", "Contact", jobModel.UserOngId);
            return View(jobModel);
        }

        // GET: Job/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.JobModel == null)
            {
                return NotFound();
            }

            var jobModel = await _context.JobModel
                .Include(j => j.UserOng)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (jobModel == null)
            {
                return NotFound();
            }

            return View(jobModel);
        }

        // POST: Job/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.JobModel == null)
            {
                return Problem("Entity set 'DatabaseContext.JobModel'  is null.");
            }
            var jobModel = await _context.JobModel.FindAsync(id);
            if (jobModel != null)
            {
                _context.JobModel.Remove(jobModel);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool JobModelExists(int id)
        {
          return _context.JobModel.Any(e => e.Id == id);
        }
    }
}
