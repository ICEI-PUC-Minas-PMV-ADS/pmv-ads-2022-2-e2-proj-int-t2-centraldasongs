using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CentralDasOngs.Dados;
using CentralDasOngs.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;

namespace CentralDasOngs.Controllers
{
    [Authorize(Roles = "Voluntario")]
    public class UsuarioVoluntarioController : Controller
    {
        private readonly CentralDasOngsContext _context;

        public UsuarioVoluntarioController(CentralDasOngsContext context)
        {
            _context = context;
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
        public async Task<IActionResult> Login([Bind("Email,Senha")] UsuarioVoluntario usuario) //Definindo que no login ele recebe apenas o Id e Senha (Feito com o Bind)
        {
            var user = await _context.UsuariosVoluntarios
            .FirstOrDefaultAsync(m => m.Email == usuario.Email);
            if (user == null)
            {
                ViewBag.MensagemLogin = "Usuario e/ou Senha invalidos";
                return View();
            }
            bool vericaSenha = BCrypt.Net.BCrypt.Verify(usuario.Senha, user.Senha);
            if (vericaSenha)
            {
                var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name, user.Nome),
                    new Claim(ClaimTypes.NameIdentifier, user.Nome),
                    new Claim(ClaimTypes.Spn, user.Cpf_Id),
                    new Claim(ClaimTypes.Role, user.Tipo.ToString())
                };

                var userIdentity = new ClaimsIdentity(claims, "login");
                ClaimsPrincipal principal = new ClaimsPrincipal(userIdentity);
                var propriedades = new AuthenticationProperties
                {
                    AllowRefresh = true,
                    ExpiresUtc = DateTime.Now.ToLocalTime().AddDays(7), // Definindo tempo de login do usuario no sistema
                    IsPersistent = true
                };
                //Inserindo o usuario na sessão da aplicação com segurança e autenticado
                await HttpContext.SignInAsync(principal, propriedades);
                return Redirect("/"); //Redirecionaria para a home principal
            }
            ViewBag.MensagemLogin = "Usuario e/ou Senha invalidos";
            return View();
        }

        //Logout
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


        // GET: UsuarioVoluntario
        public async Task<IActionResult> Index()
        {
            return View(await _context.UsuariosVoluntarios.ToListAsync());
        }

        // GET: UsuarioVoluntario/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var usuarioVoluntario = await _context.UsuariosVoluntarios
                .FirstOrDefaultAsync(m => m.Cpf_Id == id);
            if (usuarioVoluntario == null)
            {
                return NotFound();
            }

            return View(usuarioVoluntario);
        }

        // GET: UsuarioVoluntario/Create
        [AllowAnonymous]
        public IActionResult Create()
        {
            return View();
        }

        // POST: UsuarioVoluntario/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Cpf_Id,Cpf,DataNascimento,Nome,Email,Senha,Contato,Tipo")] UsuarioVoluntario usuarioVoluntario)
        {
            if (ModelState.IsValid)
            {
                string cpf1 = usuarioVoluntario.Cpf_Id[..3];
                string cpf2 = usuarioVoluntario.Cpf_Id.Substring(3, 3);
                string cpf3 = usuarioVoluntario.Cpf_Id.Substring(6, 3);
                string cpf4 = usuarioVoluntario.Cpf_Id[9..];
                usuarioVoluntario.Cpf = $"{cpf1}.{cpf2}.{cpf3}-{cpf4}";
                usuarioVoluntario.Tipo = Tipo.Voluntario;
                TempData["user_id"] = usuarioVoluntario.Cpf_Id;
                TempData["tipo"] = false;
                usuarioVoluntario.Senha = BCrypt.Net.BCrypt.HashPassword(usuarioVoluntario.Senha);
                _context.Add(usuarioVoluntario);
                await _context.SaveChangesAsync();
                return RedirectToAction("Create","Endereco");
            }
            return View(usuarioVoluntario);
        }

        // GET: UsuarioVoluntario/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var usuarioVoluntario = await _context.UsuariosVoluntarios.FindAsync(id);
            if (usuarioVoluntario == null)
            {
                return NotFound();
            }
            return View(usuarioVoluntario);
        }

        // POST: UsuarioVoluntario/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("Cpf_Id,Cpf,DataNascimento,Nome,Email,Senha,Contato,Tipo")] UsuarioVoluntario usuarioVoluntario)
        {
            if (id != usuarioVoluntario.Cpf_Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    usuarioVoluntario.Senha = BCrypt.Net.BCrypt.HashPassword(usuarioVoluntario.Senha);
                    _context.Update(usuarioVoluntario);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!UsuarioVoluntarioExists(usuarioVoluntario.Cpf_Id))
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
            return View(usuarioVoluntario);
        }

        // GET: UsuarioVoluntario/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var usuarioVoluntario = await _context.UsuariosVoluntarios
                .FirstOrDefaultAsync(m => m.Cpf_Id == id);
            if (usuarioVoluntario == null)
            {
                return NotFound();
            }

            return View(usuarioVoluntario);
        }

        // POST: UsuarioVoluntario/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var usuarioVoluntario = await _context.UsuariosVoluntarios.FindAsync(id);
            _context.UsuariosVoluntarios.Remove(usuarioVoluntario);
            await _context.SaveChangesAsync();
            return RedirectToAction("Logout");
        }

        private bool UsuarioVoluntarioExists(string id)
        {
            return _context.UsuariosVoluntarios.Any(e => e.Cpf_Id == id);
        }
    }
}
