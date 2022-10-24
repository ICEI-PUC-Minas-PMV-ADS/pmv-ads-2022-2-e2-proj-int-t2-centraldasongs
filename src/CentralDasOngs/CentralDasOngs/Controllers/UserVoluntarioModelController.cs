using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CentralDasOngs.Data;
using CentralDasOngs.Models;

namespace CentralDasOngs.Controllers
{
    public class UserVoluntarioModelController : Controller
    {
        private readonly CentralDasOngsContext _context;

        public UserVoluntarioModelController(CentralDasOngsContext context)
        {
            _context = context;
        }

        // GET: UserVoluntarioModel
        public async Task<IActionResult> Index()
        {
            return View(await _context.UserVoluntarioModel.ToListAsync());
        }

        // GET: UserVoluntarioModel/Details/5
        public async Task<IActionResult> Details(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var userVoluntarioModel = await _context.UserVoluntarioModel
                .FirstOrDefaultAsync(m => m.Cpf == id);
            if (userVoluntarioModel == null)
            {
                return NotFound();
            }

            return View(userVoluntarioModel);
        }

        // GET: UserVoluntarioModel/Create
        public IActionResult Create()
        {
            ViewData["State"] = new SelectList(_context.StateModel, "Uf", "Uf");
            return View();
        }

        // POST: UserVoluntarioModel/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Cpf,DateBirthDay,Name,Email,Password,Contact,UserType, AdressModel")] UserVoluntarioModel userVoluntarioModel)
        {
            if (ModelState.IsValid)
            {
                userVoluntarioModel.UserType = UserType.Voluntario;
                //userVoluntarioModel.AdressModel.UserVoluntarioId = userVoluntarioModel.Cpf;
                //userVoluntarioModel.AdressModel.UserOngId = 0;

                _context.Add(userVoluntarioModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["State"] = new SelectList(_context.StateModel, "Uf", "Uf");
            return View(userVoluntarioModel);
        }

        // GET: UserVoluntarioModel/Edit/5
        public async Task<IActionResult> Edit(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var userVoluntarioModel = await _context.UserVoluntarioModel.FindAsync(id);
            if (userVoluntarioModel == null)
            {
                return NotFound();
            }
            return View(userVoluntarioModel);
        }

        // POST: UserVoluntarioModel/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(long id, [Bind("Cpf,DateBirthDay,Name,Email,Password,Contact,UserType")] UserVoluntarioModel userVoluntarioModel)
        {
            if (id != userVoluntarioModel.Cpf)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(userVoluntarioModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!UserVoluntarioModelExists(userVoluntarioModel.Cpf))
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
            return View(userVoluntarioModel);
        }

        // GET: UserVoluntarioModel/Delete/5
        public async Task<IActionResult> Delete(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var userVoluntarioModel = await _context.UserVoluntarioModel
                .FirstOrDefaultAsync(m => m.Cpf == id);
            if (userVoluntarioModel == null)
            {
                return NotFound();
            }

            return View(userVoluntarioModel);
        }

        // POST: UserVoluntarioModel/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(long id)
        {
            var userVoluntarioModel = await _context.UserVoluntarioModel.FindAsync(id);
            _context.UserVoluntarioModel.Remove(userVoluntarioModel);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool UserVoluntarioModelExists(long id)
        {
            return _context.UserVoluntarioModel.Any(e => e.Cpf == id);
        }
    }
}
