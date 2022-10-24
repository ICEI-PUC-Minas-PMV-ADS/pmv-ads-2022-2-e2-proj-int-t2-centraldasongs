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
using System.Security.Claims;
using System.Data;
using Microsoft.AspNetCore.Authorization;

namespace CentralDasOngs.Controllers
{
    [Authorize(Roles = "Ong")]
    public class UserOngModelController : Controller
    {
        private readonly CentralDasOngsContext _context;

        public UserOngModelController(CentralDasOngsContext context)
        {
            _context = context;
        }

        // GET: UserOngModel
        [AllowAnonymous]
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
        [AllowAnonymous]
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
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Cnpj,Name,Email,Password,Contact,UserType, AdressModel, OngBankInformation")] UserOngModel userOngModel)
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
                userOngModel.Password = BCrypt.Net.BCrypt.HashPassword(userOngModel.Password);
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
                    userOngModel.Password = BCrypt.Net.BCrypt.HashPassword(userOngModel.Password);
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
            //caso o id informado seja encontrado ele inica o processo de verificação de senha com o BCrypt (Pois a senha ja esta criptografada)
            bool checkPassword = BCrypt.Net.BCrypt.Verify(userOngModel.Password, user.Password);
            if (checkPassword) //Caso a senha encontrada (senha do user) seja igual a informada pelo usuario entra nessa condição
            {
                // usando o Identity, para carregar as credenciais no cache e ficar fazendo validações e trafegos com os dados do usuario. Claim são credenciais 
                string teste = user.Cnpj.ToString();
                var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name, user.Name),
                    new Claim(ClaimTypes.NameIdentifier, user.Name),
                    new Claim(ClaimTypes.UserData, teste),
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

        [AllowAnonymous]
        public IActionResult AccessDenied()
        {
            return View();
        }

        //GET:ForgotPassword
        [AllowAnonymous]
        public IActionResult ForgotPassword()
        {
            TempData["UserId"] = null;
            return View();
        }
        //POST:ForgotPassword
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ForgotPassword([Bind("Email, Cnpj")] UserOngModel userOngModel)
        {
            var user = await _context.UserOngModel
                .FirstOrDefaultAsync(u => u.Email == userOngModel.Email);
            if (user == null)
            {
                ViewBag.MensageLogin = "Email e/ou Cnpj invalidos";
                return View();
            }
            user = await _context.UserOngModel
                .FirstOrDefaultAsync(u => u.Cnpj == userOngModel.Cnpj);
            if (user == null)
            {
                ViewBag.MensageLogin = "Email e/ou Cnpj invalidos";
                return View();
            }
            TempData["userId"] = user.Cnpj;
            return RedirectToAction("UpdatePassword", userOngModel);
        }

        //GET: UpdatePassword
        [AllowAnonymous]
        public async Task<IActionResult> UpdatePassword(long? id, [Bind("Cnpj ,Password")] UserOngModel user)
        {
            if (id == null)
            {
                return NotFound();
            }

            var userOngModel = await _context.UserVoluntarioModel.FindAsync(id);
            if (userOngModel == null)
            {
                return NotFound();
            }
            return View(userOngModel);
        }

        //POST:UpdatePassword
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> UpdatePassword(long id, [Bind("Cnpj ,Password")] UserOngModel userOngModel)
        {
            if (id != userOngModel.Cnpj)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    userOngModel.Password = BCrypt.Net.BCrypt.HashPassword(userOngModel.Password);
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
