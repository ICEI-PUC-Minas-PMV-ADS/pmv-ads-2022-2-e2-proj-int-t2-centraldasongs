using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using CentralOngs.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CentralOngs.Controllers
{
    public class OngsController : UserController<UserOngModel>
    {
        public OngsController(DatabaseContext context) : base(context)
        {
        }

        // GET: UserOng
        [AllowAnonymous]
        public async Task<IActionResult> Index()
        {
            //List<UserOngModel> ongList = await _context.UserOngModel.ToListAsync();
            return View();
        }

        // GET: UserOng/Details/5
        [AllowAnonymous]
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var userOngModel = await _context.UserOngModel
                .FirstOrDefaultAsync(o => o.Id == id);
            if (userOngModel == null)
            {
                return NotFound();
            }
            var userAddress = await _context.AddressModel
                .FirstOrDefaultAsync(oa => oa.UserId == id);

            var userState = await _context.StateModel
                .FirstOrDefaultAsync(s => s.Name == userAddress.StateName);

            var userBankAccount = await _context.BankAccountModel
                .FirstOrDefaultAsync(ba => ba.UserOngId == id);

            var userBank = await _context.BankModel
                .FirstOrDefaultAsync(b => b.Code == userBankAccount.BankId);
            return View(userOngModel);
        }

        // GET: UserOng/Create
        [AllowAnonymous]
        public IActionResult Create()
        {
            return base.createViewStateAndBank();
        }

        // POST: UserOng/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(UserOngModel userOngModel)
        {
            if (ModelState.IsValid)
            {
                var userOng = await _context.UserOngModel
                    .FirstOrDefaultAsync(u => u.Cnpj == userOngModel.Cnpj);
                if (userOng != null)
                {
                    ViewBag.MensageCNPJ_CPF = "CNPJ já cadastrado";
                    return View();
                }
                userOng = await _context.UserOngModel
                    .FirstOrDefaultAsync(u => u.Email == userOngModel.Email);
                if (userOng != null)
                {
                    ViewBag.MensageEmail = "Email já cadastrado";
                    return View();
                }

                userOngModel.UserType = UserType.Ong;
                _context.Add(userOngModel);
                await _context.SaveChangesAsync();
                return RedirectToAction("Login");
            }

            base.createViewStateAndBank();
            return View(userOngModel);
        }

        // GET: UserOng/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var userOngModel = await _context.UserOngModel
                .FirstOrDefaultAsync(m => m.Id == id);
            if (userOngModel == null)
            {
                return NotFound();
            }

            return View(userOngModel);
        }

        // POST: UserOng/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var userOngModel = await _context.UserOngModel.FindAsync(id);
            _context.UserOngModel.Remove(userOngModel);
            await _context.SaveChangesAsync();
            return RedirectToAction("Logout");
        }

        [AllowAnonymous]
        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync();
            return Redirect("/");
        }

        [AllowAnonymous]
        public IActionResult AccessDenied()
        {
            return View();
        }


        private bool UserOngModelExists(int id)
        {
            return _context.UserOngModel.Any(e => e.Id == id);
        }
    }
}

