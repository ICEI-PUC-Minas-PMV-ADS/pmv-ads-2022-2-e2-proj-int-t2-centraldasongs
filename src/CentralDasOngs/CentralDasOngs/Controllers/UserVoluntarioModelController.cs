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
using Microsoft.AspNetCore.Authorization;
using System.Data;

namespace CentralDasOngs.Controllers
{
    [Authorize(Roles = "Voluntario")]
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
            var userAdress = await _context.AdressModel
                .FirstOrDefaultAsync(m => m.UserVoluntarioId == id);
            return View(userVoluntarioModel);
        }

        // GET: UserVoluntarioModel/Create
        [AllowAnonymous]
        public IActionResult Create()
        {
            ViewData["State"] = new SelectList(_context.StateModel, "Uf", "Uf");
            return View();
        }

        // POST: UserVoluntarioModel/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Cpf,DateBirthDay,Name,Email,Password,Contact,UserType, AdressModel")] UserVoluntarioModel userVoluntarioModel)
        {
            if (ModelState.IsValid)
            {
                var userOng = await _context.UserVoluntarioModel
                    .FirstOrDefaultAsync(u => u.Cpf == userVoluntarioModel.Cpf);
                if (userOng != null)
                {
                    ViewBag.MensageCreate = "CPF já cadastrado";
                    return View();
                }
                userOng = await _context.UserVoluntarioModel
                    .FirstOrDefaultAsync(u => u.Email == userVoluntarioModel.Email);
                if (userOng != null)
                {
                    ViewBag.MensageCreate = "Email já cadastrado";
                    return View();
                }

                userVoluntarioModel.UserType = UserType.Voluntario;
                userVoluntarioModel.Password = BCrypt.Net.BCrypt.HashPassword(userVoluntarioModel.Password);
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
            var userAdress = await _context.AdressModel
                .FirstOrDefaultAsync(m => m.UserVoluntarioId == id);

            var userVoluntarioModel = await _context.UserVoluntarioModel.FindAsync(id);
            if (userVoluntarioModel == null)
            {
                return NotFound();
            }
            ViewData["State"] = new SelectList(_context.StateModel, "Uf", "Uf");
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
                    userVoluntarioModel.Password = BCrypt.Net.BCrypt.HashPassword(userVoluntarioModel.Password);
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
            //caso o id informado seja encontrado ele inica o processo de verificação de senha com o BCrypt (Pois a senha ja esta criptografada)
            if (BCrypt.Net.BCrypt.Verify(userVoluntarioModel.Password, user.Password)) //Caso a senha encontrada (senha do user) seja igual a informada pelo usuario entra nessa condição
            {
                // usando o Identity, para carregar as credenciais no cache e ficar fazendo validações e trafegos com os dados do usuario. Claim são credenciais 
                string teste = user.Cpf.ToString();
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
        public async Task<IActionResult> ForgotPassword([Bind("Email, Cpf")] UserVoluntarioModel userVoluntarioModel)
        {
            var user = await _context.UserVoluntarioModel
                .FirstOrDefaultAsync(u => u.Email == userVoluntarioModel.Email);
            if (user == null)
            {
                ViewBag.MensageLogin = "Email e/ou CPF invalidos";
                return View();
            }
            user = await _context.UserVoluntarioModel
                .FirstOrDefaultAsync(u => u.Cpf == userVoluntarioModel.Cpf);
            if (user == null)
            {
                ViewBag.MensageLogin = "Email e/ou CPF invalidos";
                return View();
            }
            return RedirectToAction("UpdatePassword", userVoluntarioModel); 
        }

        //GET: UpdatePassword
        [AllowAnonymous]
        public async Task<IActionResult> UpdatePassword(long? id)
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

        //POST:UpdatePassword
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> UpdatePassword(long id, [Bind("Password")] UserVoluntarioModel userVoluntarioModel)
        {
            if (id != userVoluntarioModel.Cpf)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    userVoluntarioModel.Password = BCrypt.Net.BCrypt.HashPassword(userVoluntarioModel.Password);
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
