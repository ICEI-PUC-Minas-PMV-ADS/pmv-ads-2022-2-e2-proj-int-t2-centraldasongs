using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CentralOngs.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CentralOngs.Controllers
{
    public class OngsController : Controller
    {
        private readonly DatabaseContext _context;

        public OngsController(DatabaseContext context)
        {
            _context = context;
        }

        // GET: /<controller>/
        public async Task<IActionResult> Index()
        {
            return View(await _context.UserOngModel.ToListAsync());
        }


        // POST: /<controller>/Create
        public async Task<IActionResult> Create(UserOngModel userOngModel)
        {
            if (ModelState.IsValid)
            {
                var userOng = await _context.UserOngModel
                    .FirstOrDefaultAsync(u => u.Cnpj == userOngModel.Cnpj);
                if (userOng != null)
                {
                    ViewBag.MensageCreate = "CNPJ já cadastrado";
                    return View();
                }
                userOng = await _context.UserOngModel
                    .FirstOrDefaultAsync(u => u.Email == userOngModel.Email);
                if (userOng != null)
                {
                    ViewBag.MensageCreate = "Email já cadastrado";
                    return View();
                }

                userOngModel.UserType = UserType.Ong;
                userOngModel.Password = userOngModel.Password;
                _context.Add(userOngModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["StateList"] = new SelectList(_context.StateModel, "Id", "UF");
            ViewData["BankList"] = new SelectList(_context.BankModel, "Code", "Name");
            return View(userOngModel);
        }
    }
}

