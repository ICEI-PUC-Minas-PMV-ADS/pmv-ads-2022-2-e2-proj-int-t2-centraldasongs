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
    public class OngsController : Controller
    {
        protected readonly DatabaseContext _context;

        public OngsController(DatabaseContext context)
        {
            _context = context;
        }

        // GET: UserOng
        [AllowAnonymous]
        public async Task<IActionResult> Index()
        {
            List<UserOngModel> ongList = await _context.UserOngModel.ToListAsync();
            return View(ongList);
        }

        // GET: Details
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

            ViewData["StateList"] = new SelectList(_context.StateModel, "Name", "Name");
            ViewData["BankList"] = new SelectList(_context.BankModel, "Code", "Name");
            return View(userOngModel);
        }

        // GET: Delete
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

        // POST: Delete
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
        public IActionResult AccessDenied()
        {
            return View();
        }


        private bool UserOngModelExists(int id)
        {
            return _context.UserOngModel.Any(e => e.Id == id);
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
        public async Task<IActionResult> Login([Bind("Email, Password")] UserOngModel userOngModel)
        {
            var user = await _context.UserOngModel
                .FirstOrDefaultAsync(u => u.Email == userOngModel.Email);
            if (user == null)
            {
                ViewBag.MensageLogin = "Usuario e/ou Senha invalidos";
                return View();
            }


            if (user.Password == userOngModel.Password)
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
                    ExpiresUtc = DateTime.Now.ToLocalTime().AddDays(7), // Definindo tempo de login do usuario no sistema
                    IsPersistent = true
                };
                //Inserindo o usuario na sessão da aplicação com segurança e autenticado
                await HttpContext.SignInAsync(principal, properties);
                TempData["UserId"] = user.Id;
                return Redirect("/"); //Redirecionaria para a home principal
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
            ViewData["BankList"] = new SelectList(_context.BankModel, "Code", "Name");
            if (id == null)
            {
                return NotFound();
            }

            var userOngModel = await _context.UserOngModel.FindAsync(id);

            var userAddress = await _context.AddressModel.FirstOrDefaultAsync(oa => oa.UserId == id);
            var userState = await _context.StateModel.FirstOrDefaultAsync(s => s.Name == userAddress.StateName);
            var userBankAccount = await _context.BankAccountModel.FirstOrDefaultAsync(ba => ba.UserOngId == id);
            var userBank = await _context.BankModel.FirstOrDefaultAsync(b => b.Code == userBankAccount.BankId);


            if (userOngModel == null)
            {
                return NotFound();
            }
            return View(userOngModel);
        }

        //POST: Edit
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit([Bind("Id, Cnpj,About,Name,Email,Password,Contact,UserType,Address,BankAccount")] UserOngModel userOngModel)
        {
            var userId = User.Claims.ElementAt(1).Value;

            var user = await _context.UserOngModel.FirstOrDefaultAsync(u => u.Id == int.Parse(userId));
            var userAdress = await _context.AddressModel.FirstOrDefaultAsync(oa => oa.UserId == int.Parse(userId));
            var userBankAccount = await _context.BankAccountModel.FirstOrDefaultAsync(ba => ba.UserOngId == int.Parse(userId));

            user.Name = userOngModel.Name;
            user.Contact = userOngModel.Name;
            user.About = userOngModel.About;

            user.Address.StateName = userOngModel.Address.StateName;
            user.Address.City = userOngModel.Address.City;
            user.Address.District = userOngModel.Address.District;
            user.Address.Street = userOngModel.Address.Street;
            user.Address.Number = userOngModel.Address.Number;
            user.Address.Complement = userOngModel.Address.Complement;

            user.BankAccount.AccountNumber = userOngModel.BankAccount.AccountNumber;
            user.BankAccount.Branch = userOngModel.BankAccount.Branch;
            user.BankAccount.AccountType = userOngModel.BankAccount.AccountType;
            user.BankAccount.BankId = userOngModel.BankAccount.BankId;

            if (user.Id != 0)
            {
                try
                {
                    _context.Update(user);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!UserOngModelExists(userOngModel.Id))
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
            ViewData["BankList"] = new SelectList(_context.BankModel, "Code", "Name");
            return View(userOngModel);
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
        public async Task<IActionResult> ForgotPassword([Bind("Email, Cnpj")] UserOngModel userOngModel)
        {
            var user = await _context.UserOngModel
                .FirstOrDefaultAsync(u => u.Email == userOngModel.Email);
            if (user == null)
            {
                ViewBag.MensageForgotPassword = "Usuario não encontrado";
                return View();
            }

            if (user.Cnpj == userOngModel.Cnpj)
            {
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

            var userOngModel = await _context.UserOngModel.FindAsync(id);

            if (userOngModel == null)
            {
                return NotFound();
            }
            return View(userOngModel);
        }

        //POST: UpdatePassword
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> UpdatePassword(int id, [Bind("Id, Cnpj,About,Name,Email,Password,Contact,UserType,Address,BankAccount")] UserOngModel userOngModel)
        {
            //var userId = User.Claims.ElementAt(1).Value;

            //var user = await _context.UserOngModel.FirstOrDefaultAsync(u => u.Id == int.Parse(userId));

            var user = await _context.UserOngModel.FirstOrDefaultAsync(u => u.Id == id);

            user.Password = userOngModel.Password;

            if (user.Id != 0)
            {
                try
                {
                    _context.Update(user);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!UserOngModelExists(userOngModel.Id))
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
            ViewData["BankList"] = new SelectList(_context.BankModel, "Code", "Name");
            return View(userOngModel);
        }


        // POST: CreateJob
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateJob(JobModel jobModel, UserOngModel userOngModel)
        {
            var userId = User.Claims.ElementAt(1).Value;
            var user = await _context.UserOngModel.FirstOrDefaultAsync(u => u.Id == int.Parse(userId));
            jobModel.UserOng = user;
            jobModel.UserOngId = user.Id;

            if (user.Id != 0)
            {
                try
                {
                    _context.Add(jobModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!UserOngModelExists(userOngModel.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
            }
            return RedirectToAction("Details", new { id = user.Id });
        }

        //Get: MyJobs
        // GET: Job
        public async Task<IActionResult> MyJobs(int? id)
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

            var databaseContext = from p in _context.JobModel.Include(j => j.UserOng) select p;
            databaseContext = databaseContext.Where(s => s.UserOngId == id);

            return View(await databaseContext.ToListAsync());
        }

    }
}

