using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CentralDasOngs.Data;
using CentralDasOngs.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;

namespace CentralDasOngs.Controllers
{
    public class UserVoluntarioController : Controller
    {
        private readonly CentralDasOngsContext _context;

        public UserVoluntarioController(CentralDasOngsContext context)
        {
            _context = context;
        }

        // GET: UserVoluntario
        public async Task<IActionResult> Index()
        {
            return View(await _context.UserVoluntarioModel.ToListAsync());
        }

        // GET: UserVoluntario/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var userVoluntarioModel = await _context.UserVoluntarioModel
                .FirstOrDefaultAsync(m => m.Id == id);
            if (userVoluntarioModel == null)
            {
                return NotFound();
            }
            var userAdress = await _context.AddressModel
                .FirstOrDefaultAsync(m => m.UserId == id);

            return View(userVoluntarioModel);
        }

        // GET: UserVoluntario/Create
        [AllowAnonymous]
        public IActionResult Create()
        {
            ViewData["StateList"] = new SelectList(_context.StateModel, "UF", "UF");
            return View();
        }

        // POST: UserVoluntario/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Cpf,DateBirthDay,Id,Name,Email,Password,Contact,UserType,Address")] UserVoluntarioModel userVoluntarioModel)
        {
            if (ModelState.IsValid)
            {
                var user = await _context.UserVoluntarioModel
                    .FirstOrDefaultAsync(u => u.Cpf == userVoluntarioModel.Cpf);
                if (user != null)
                {
                    ViewBag.MensageCNPJ_CPF = "CPF já cadastrado";
                    return View();
                }
                user = await _context.UserVoluntarioModel
                    .FirstOrDefaultAsync(u => u.Email == userVoluntarioModel.Email);
                if (user != null)
                {
                    ViewBag.MensageEmail = "Email já cadastrado";
                    return View();
                }

                userVoluntarioModel.UserType = UserType.Voluntario;

                _context.Add(userVoluntarioModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["StateList"] = new SelectList(_context.StateModel, "UF", "UF");
            return View(userVoluntarioModel);
        }

        // GET: UserVoluntario/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var userAdress = await _context.AddressModel
                .FirstOrDefaultAsync(m => m.UserId == id);

            var userVoluntarioModel = await _context.UserVoluntarioModel.FindAsync(id);
            if (userVoluntarioModel == null)
            {
                return NotFound();
            }
            ViewData["State"] = new SelectList(_context.StateModel, "UF", "UF");
            return View(userVoluntarioModel);
        }

        // POST: UserVoluntario/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Cpf,DateBirthDay,Id,Name,Email,Password,Contact,UserType, AdressModel")] UserVoluntarioModel userVoluntarioModel)
        {
            if (id != userVoluntarioModel.Id)
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
                    if (!UserVoluntarioModelExists(userVoluntarioModel.Id))
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
            ViewData["State"] = new SelectList(_context.StateModel, "Uf", "Uf");
            return View(userVoluntarioModel);
        }

        //GET: Login
        [AllowAnonymous]
        public IActionResult Login()
        {
            return View();
        }

        //POST: Login
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login([Bind("Email, Password")] UserVoluntarioModel userVoluntarioModel)
        {
            var user = await _context.UserVoluntarioModel
                .FirstOrDefaultAsync(u => u.Email == userVoluntarioModel.Email);
            if (user == null)
            {
                ViewBag.MensageLogin = "Usuario e/ou Senha invalidos";
                return View();
            }

            if (user.Password == userVoluntarioModel.Password) 
            {
                var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name, user.Name),
                    new Claim(ClaimTypes.UserData, user.Id.ToString()),    
                    new Claim(ClaimTypes.NameIdentifier, user.Name),
                    new Claim(ClaimTypes.Role, user.UserType.ToString())
                };

                var userIdentity = new ClaimsIdentity(claims, "login");
                ClaimsPrincipal principal = new ClaimsPrincipal(userIdentity);
                var properties = new AuthenticationProperties
                {
                    AllowRefresh = true,
                    ExpiresUtc = DateTime.Now.ToLocalTime().AddDays(7), 
                };
                await HttpContext.SignInAsync(principal, properties);
                return Redirect("/"); 
            }
            ViewBag.MensageLogin = "Usuario e/ou Senha invalidos";
            return View();
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


        // GET: UserVoluntario/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var userVoluntarioModel = await _context.UserVoluntarioModel
                .FirstOrDefaultAsync(m => m.Id == id);
            if (userVoluntarioModel == null)
            {
                return NotFound();
            }

            return View(userVoluntarioModel);
        }

        // POST: UserVoluntario/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var userVoluntarioModel = await _context.UserVoluntarioModel.FindAsync(id);
            _context.UserVoluntarioModel.Remove(userVoluntarioModel);
            await _context.SaveChangesAsync();
            return RedirectToAction("Logout");
        }

        private bool UserVoluntarioModelExists(int id)
        {
            return _context.UserVoluntarioModel.Any(e => e.Id == id);
        }
    }
}
