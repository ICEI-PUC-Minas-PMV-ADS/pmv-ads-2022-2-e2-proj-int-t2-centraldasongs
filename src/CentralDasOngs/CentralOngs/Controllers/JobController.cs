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
    public class JobController : Controller
    {
        private readonly DatabaseContext _context;

        public JobController(DatabaseContext context)
        {
            _context = context;
        }


        // GET: Job
        [AllowAnonymous]
        public async Task<IActionResult> Index(string searchString, JobType? jobType, string? state)
        {
            var databaseContext = from p in _context.JobModel.Include(j => j.UserOng) select p;
            
            ViewBag.State = new SelectList(_context.StateModel, "Name", "Name");
            
            if (jobType.HasValue)
            {
                databaseContext = databaseContext.Where(j => j.JobType == jobType);
            }
            if (!String.IsNullOrEmpty(state))
            {
                databaseContext = databaseContext.Where(s => s.UserOng.Address.StateName == state);
            }
            if (!String.IsNullOrEmpty(searchString))
            {
                databaseContext = databaseContext.Where(s => s.Name.ToUpper().Contains(searchString.ToUpper()));
            }

            return View(await databaseContext.ToListAsync());
        }

        // GET: Job/Details/5
        [AllowAnonymous]
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

        //Post: Job/Details
        [HttpPost]
        public async Task<IActionResult> Details(int? id, JobModel jobModel)
        {
            if (id == null || _context.JobModel == null)
            {
                return NotFound();
            }

            jobModel = await _context.JobModel
                .Include(j => j.UserOng)
                .FirstOrDefaultAsync(m => m.Id == id);
            var userId = User.Claims.ElementAt(1).Value;

            VacancyModel vacancy = await _context.VacancyModel
                .Include(j => j.Job)
                .Include(u => u.UserVoluntario)
                .Where(s => s.UserVoluntarioId == int.Parse(userId) && s.JobId == jobModel.Id)
                .FirstOrDefaultAsync<VacancyModel>();

            if (vacancy != null)
            {
                ViewBag.MensageErrorVacancy = "Você já se candidatou a essa vaga";
                return View(jobModel);
            }

            TempData["jobId"] = jobModel.Id;

            if (jobModel == null)
            {
                return NotFound();
            }

            return RedirectToAction("ApplyVacancy");
        }

        // GET: Job/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Job/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(JobModel jobModel)
        {
            var userId = User.Claims.ElementAt(1).Value;
            var user = await _context.UserOngModel.FirstOrDefaultAsync(u => u.Id == int.Parse(userId));
            jobModel.UserOng = user;
            jobModel.UserOngId = user.Id;

            if (user.Id != 0)
            {
                _context.Add(jobModel);
                
                await _context.SaveChangesAsync();
            }
            else
            {
                return View(jobModel);
            }

            return RedirectToAction("Index", new { id = user.Id });
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
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Description,UserOngId")] JobModel jobModel)
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

        // GET: ApplyVacancy
        public IActionResult ApplyVacancy()
        {
            return View();
        }

        // POST: ApplyVacancy
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ApplyVacancy(JobModel jobModel, VacancyModel vacancyModel)
        {
            var userId = User.Claims.ElementAt(1).Value;
            var user = await _context.UserVoluntarioModel.FirstOrDefaultAsync(u => u.Id == int.Parse(userId));
            var job = TempData["jobId"].ToString();

            var jobContext = await _context.JobModel.FirstOrDefaultAsync(j => j.Id == int.Parse(job));
            
            vacancyModel.UserVoluntario = user;
            vacancyModel.UserVoluntarioId = user.Id;
            vacancyModel.Job = jobContext;
            vacancyModel.JobId = jobContext.Id;

            if (jobContext.Id != 0)
            {
                try
                {
                    _context.Add(vacancyModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!JobModelExists(jobContext.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
            }
            return RedirectToAction("MyVacancies", "Voluntarios", new {id = userId});
        }

        
        // GET: ApplyVacancy
        public async Task<IActionResult> AllCandidates(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var jobModel = await _context.JobModel
                .FirstOrDefaultAsync(j => j.Id == id);
            
            if (jobModel == null)
            {
                return NotFound();
            }

            var databaseContext = from p in _context.VacancyModel.Include(j => j.Job).Include(u => u.UserVoluntario) select p;

            databaseContext = databaseContext.Where(s => s.JobId == id);

            return View(await databaseContext.ToListAsync());
        }

    }
}


