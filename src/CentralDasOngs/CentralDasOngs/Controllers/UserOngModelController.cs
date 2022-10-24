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
    public class UserOngModelController : Controller
    {
        private readonly CentralDasOngsContext _context;

        public UserOngModelController(CentralDasOngsContext context)
        {
            _context = context;
        }

        // GET: UserOngModel
        public async Task<IActionResult> Index()
        {
            return View(await _context.UserOngModel.ToListAsync());
        }

        // GET: UserOngModel/Details/5
        public async Task<IActionResult> Details(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var userOngModel = await _context.UserOngModel
                .FirstOrDefaultAsync(m => m.Cnpj == id);
            if (userOngModel == null)
            {
                return NotFound();
            }

            return View(userOngModel);
        }

        // GET: UserOngModel/Create
        public IActionResult Create()
        {
            ViewData["State"] = new SelectList(_context.StateModel, "Uf", "Uf");
            ViewData["BankId"] = new SelectList(_context.BankModel, "Code", "Name");
            return View();
        }

        // POST: UserOngModel/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Cnpj,Name,Email,Password,Contact,UserType, AdressModel, OngBankInformation")] UserOngModel userOngModel)
        {
            if (ModelState.IsValid)
            {
                userOngModel.UserType = UserType.Ong;
                //userOngModel.OngBankInformation.UserOngId = userOngModel.Cnpj;
                //userOngModel.AdressModel.UserOngId = userOngModel.Cnpj;
                //userOngModel.AdressModel.UserVoluntarioId = 0;

                _context.Add(userOngModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["State"] = new SelectList(_context.StateModel, "Uf", "Uf");
            ViewData["BankId"] = new SelectList(_context.BankModel, "Code", "Name");
            return View(userOngModel);
        }

        // GET: UserOngModel/Edit/5
        public async Task<IActionResult> Edit(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var userOngModel = await _context.UserOngModel.FindAsync(id);
            if (userOngModel == null)
            {
                return NotFound();
            }
            return View(userOngModel);
        }

        // POST: UserOngModel/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(long id, [Bind("Cnpj,Name,Email,Password,Contact,UserType")] UserOngModel userOngModel)
        {
            if (id != userOngModel.Cnpj)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(userOngModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!UserOngModelExists(userOngModel.Cnpj))
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
            return View(userOngModel);
        }

        // GET: UserOngModel/Delete/5
        public async Task<IActionResult> Delete(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var userOngModel = await _context.UserOngModel
                .FirstOrDefaultAsync(m => m.Cnpj == id);
            if (userOngModel == null)
            {
                return NotFound();
            }

            return View(userOngModel);
        }

        // POST: UserOngModel/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(long id)
        {
            var userOngModel = await _context.UserOngModel.FindAsync(id);
            _context.UserOngModel.Remove(userOngModel);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool UserOngModelExists(long id)
        {
            return _context.UserOngModel.Any(e => e.Cnpj == id);
        }
    }
}
