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
    public class VoluntariosController : Controller
    {
        protected readonly DatabaseContext _context;

        public VoluntariosController(DatabaseContext context)
        {
            _context = context;
        }
        // GET: UserOng
        [AllowAnonymous]
        public async Task<IActionResult> Index()
        {
            return View(await _context.UserVoluntarioModel.ToListAsync());
        }

        // GET: Details
        [AllowAnonymous]
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var userOngModel = await _context.UserVoluntarioModel
                .FirstOrDefaultAsync(o => o.Id == id);
            if (userOngModel == null)
            {
                return NotFound();
            }
            var userAddress = await _context.AddressModel
                .FirstOrDefaultAsync(oa => oa.UserId == id);

            var userState = await _context.StateModel
                .FirstOrDefaultAsync(s => s.Name == userAddress.StateName);
            return View(userOngModel);
        }

        // GET: Create
        [AllowAnonymous]
        public IActionResult Create()
        {
            ViewData["StateList"] = new SelectList(_context.StateModel, "Name", "Name");
            ViewData["BankList"] = new SelectList(_context.BankModel, "Code", "Name");
            return View();
        }

        // POST: Create
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(UserVoluntarioModel userVoluntarioModel)
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
                return RedirectToAction("Login");
            }

            ViewData["StateList"] = new SelectList(_context.StateModel, "Name", "Name");
            ViewData["BankList"] = new SelectList(_context.BankModel, "Code", "Name");
            return View(userVoluntarioModel);
        }

        // GET: Delete
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

        // POST: Delete
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var userVoluntarioModel = await _context.UserVoluntarioModel.FindAsync(id);
            _context.UserVoluntarioModel.Remove(userVoluntarioModel);
            await _context.SaveChangesAsync();
            return RedirectToAction("Logout");
        }

        [AllowAnonymous]
        public IActionResult AccessDenied()
        {
            return View();
        }

        private bool UserVoluntarioModelExists(int id)
        {
            return _context.UserVoluntarioModel.Any(e => e.Id == id);
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

        // GET: Edit
        public async Task<IActionResult> Edit(int? id)
        {
            ViewData["StateList"] = new SelectList(_context.StateModel, "Name", "Name");

            if (id == null)
            {
                return NotFound();
            }

            var userVoluntarioModel = await _context.UserVoluntarioModel.FindAsync(id);
            var userAdress = await _context.AddressModel.FirstOrDefaultAsync(oa => oa.UserId == id);
            var userState = await _context.StateModel.FirstOrDefaultAsync(s => s.Name == userAdress.StateName);

            if (userVoluntarioModel == null)
            {
                return NotFound();
            }
            return View(userVoluntarioModel);
        }

        //POST: Edit
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit([Bind("Id,Cpf,DateBirthDay,Name,Email,Password,Contact,UserType,Address")] UserVoluntarioModel userVoluntarioModel)
        {
            var userId = User.Claims.ElementAt(1).Value;

            var user = await _context.UserVoluntarioModel.FirstOrDefaultAsync(u => u.Id == int.Parse(userId));
            var userAdress = await _context.AddressModel.FirstOrDefaultAsync(oa => oa.UserId == int.Parse(userId));

            user.Name = userVoluntarioModel.Name;
            user.Contact = userVoluntarioModel.Name;


            user.Address.StateName = userVoluntarioModel.Address.StateName;
            user.Address.City = userVoluntarioModel.Address.City;
            user.Address.District = userVoluntarioModel.Address.District;
            user.Address.Street = userVoluntarioModel.Address.Street;
            user.Address.Number = userVoluntarioModel.Address.Number;
            user.Address.Complement = userVoluntarioModel.Address.Complement;

            if (user.Id != 0)
            {
                try
                {
                    _context.Update(user);
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
            ViewData["StateList"] = new SelectList(_context.StateModel, "Name", "Name");
            return View(userVoluntarioModel);
        }

        //Get: MyVacancies
        public async Task<IActionResult> MyVacancies(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var userOngModel = await _context.UserVoluntarioModel
                .FirstOrDefaultAsync(o => o.Id == id);
            if (userOngModel == null)
            {
                return NotFound();
            }

            var databaseContext = from p in _context.VacancyModel.Include(j => j.Job).Include(u => u.UserVoluntario) select p;

            databaseContext = databaseContext.Where(s => s.UserVoluntarioId == id);

            return View(await databaseContext.ToListAsync());
        }

        //GET: ForgotPassword	
        [AllowAnonymous]
        public IActionResult ForgotPassword()
        {
            return View();
        }
        //POST: ForgotPassword	
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ForgotPassword([Bind("Email, Cpf")] UserVoluntarioModel userVoluntarioModel)
        {
            var user = await _context.UserVoluntarioModel
                .FirstOrDefaultAsync(u => u.Email == userVoluntarioModel.Email);
            if (user == null)
            {
                ViewBag.MensageForgotPassword = "Usuario não encontrado";
                return View();
            }
            if (user.Cpf == userVoluntarioModel.Cpf)
            {
                //TempData["UserId"] = user.Id;	
                return RedirectToAction("UpdatePassword", new { id = user.Id });
            }
            ViewBag.MensageForgotPassword = "Usuario não encontrado";
            return View();
        }
        [AllowAnonymous]
        // GET: UpdatePassword	
        public async Task<IActionResult> UpdatePassword(int? id)
        {
            //int id = (int)TempData["UserId"];	
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
        //POST: UpdatePassword	
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> UpdatePassword(int id, [Bind("Id, Cpf,About,Name,Email,Password,Contact,UserType,Address")] UserVoluntarioModel userVoluntarioModel)
        {
            //var userId = User.Claims.ElementAt(1).Value;	
            //var user = await _context.UserOngModel.FirstOrDefaultAsync(u => u.Id == int.Parse(userId));	
            var user = await _context.UserVoluntarioModel.FirstOrDefaultAsync(u => u.Id == id);
            user.Password = userVoluntarioModel.Password;
            if (user.Id != 0)
            {
                try
                {
                    _context.Update(user);
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
                return Redirect("/");
            }
            ViewData["StateList"] = new SelectList(_context.StateModel, "UF", "UF");
            return View(userVoluntarioModel);
        }

    }
}

