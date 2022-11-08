using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CentralDasOngs.Data;
using CentralDasOngs.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authentication;
using System.Security.Claims;
using StackExchange.Redis;

namespace CentralDasOngs.Controllers
{
    [Authorize(Roles = "Ong")]
    public class UserOngController : Controller
    {
        private readonly CentralDasOngsContext _context;

        public UserOngController(CentralDasOngsContext context)
        {
            _context = context;
        }

        // GET: UserOng
        [AllowAnonymous]
        public async Task<IActionResult> Index()
        {
            return View(await _context.UserOngModel.ToListAsync());
        }

        // GET: UserOng/Details/5
        [AllowAnonymous]
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var userOng = await _context.UserOngModel
                .FirstOrDefaultAsync(o => o.Id == id);
            if (userOng == null)
            {
                return NotFound();
            }
            var userAdress = await _context.AddressModel
                .FirstOrDefaultAsync(oa => oa.UserId == id);

            var userState = await _context.StateModel
                .FirstOrDefaultAsync(s => s.UF == userAdress.StateId);

            var userBankAccount = await _context.BankAccount
                .FirstOrDefaultAsync(ba => ba.UserOngId == id);

            var userBank = await _context.BankModel
                .FirstOrDefaultAsync(b => b.Code == userBankAccount.BankId);
            return View(userOng);
        }

        // GET: UserOng/Create
        [AllowAnonymous]
        public IActionResult Create()
        {
            ViewData["StateList"] = new SelectList(_context.StateModel, "UF", "UF");
            ViewData["BankList"] = new SelectList(_context.BankModel, "Code", "Name");
            return View();
        }

        // POST: UserOng/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Cnpj,About,Name,Email,Password,Contact,UserType,Address,BankAccount")] UserOngModel userOngModel)
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
            ViewData["StateList"] = new SelectList(_context.StateModel, "UF", "UF");
            ViewData["BankList"] = new SelectList(_context.BankModel, "Code", "Name");
            return View(userOngModel);
        }

        // GET: UserOngModels/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            ViewData["StateList"] = new SelectList(_context.StateModel, "UF", "UF");
            ViewData["BankList"] = new SelectList(_context.BankModel, "Code", "Name");
            if (id == null)
            {
                return NotFound();
            }

            var userOngModel = await _context.UserOngModel.FindAsync(id);
            var userAdress = await _context.AddressModel.FirstOrDefaultAsync(oa => oa.UserId == id);
            var userState = await _context.StateModel.FirstOrDefaultAsync(s => s.UF == userAdress.StateId);
            var userBankAccount = await _context.BankAccount.FirstOrDefaultAsync(ba => ba.UserOngId == id);
            var userBank = await _context.BankModel.FirstOrDefaultAsync(b => b.Code == userBankAccount.BankId);

            if (userOngModel == null)
            {
                return NotFound();
            }
            return View(userOngModel);
        }

        //POST: UserOngModels/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit([Bind("Id, Cnpj,About,Name,Email,Password,Contact,UserType,Address,BankAccount")] UserOngModel userOngModel)
        {
            var userId = User.Claims.ElementAt(1).Value;

            var user = await _context.UserOngModel.FirstOrDefaultAsync(u => u.Id == int.Parse(userId));
            var userAdress = await _context.AddressModel.FirstOrDefaultAsync(oa => oa.UserId == int.Parse(userId));
            var userBankAccount = await _context.BankAccount.FirstOrDefaultAsync(ba => ba.UserOngId == int.Parse(userId));

            user.Name = userOngModel.Name;
            user.Contact = userOngModel.Name;
            user.About = userOngModel.About;

            user.Address.StateId = userOngModel.Address.StateId;
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

            ViewData["StateList"] = new SelectList(_context.StateModel, "UF", "UF");
            ViewData["BankList"] = new SelectList(_context.BankModel, "Code", "Name");
            return View(userOngModel);
        }


        //GET: UserOng/Delete/5
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
                    ExpiresUtc = DateTime.Now.ToLocalTime().AddDays(7), 
                    IsPersistent = true
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
                //TempData["UserId"] = user.Id;
                return RedirectToAction("UpdatePassword", new {id = user.Id}); 
            }
            ViewBag.MensageForgotPassword = "Usuario não encontrado";
            return View();
        }

        [AllowAnonymous]
        // GET: UserOngModels/UpdatePassword/5
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

        //POST: UserOngModels/UpdatePassword/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
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


        private bool UserOngModelExists(int id)
        {
            return _context.UserOngModel.Any(e => e.Id == id);
        }
    }
}
