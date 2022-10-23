using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CentralDasOngs.Dados;
using CentralDasOngs.Models;
using CentralDasOngs.Migrations;
using Microsoft.AspNetCore.Authorization;
using System.Data;
using Microsoft.AspNetCore.Authentication;
using System.Security.Claims;

namespace CentralDasOngs.Controllers
{
    [Authorize(Roles = "Ong")]
    public class UsuarioOngController : Controller
    {
        private readonly CentralDasOngsContext _context;

        public UsuarioOngController(CentralDasOngsContext context)
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
        public async Task<IActionResult> Login([Bind("Email,Senha")] UsuarioOng usuario)
        {
            var user = await _context.UsuariosOng
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
                    new Claim(ClaimTypes.Spn, user.Cnpj_Id),
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


        // GET: UsuarioOng
        public async Task<IActionResult> Index()
        {
            return View(await _context.UsuariosOng.ToListAsync());
        }

        // GET: UsuarioOng/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var usuarioOng = await _context.UsuariosOng
                .FirstOrDefaultAsync(m => m.Cnpj_Id == id);
            if (usuarioOng == null)
            {
                return NotFound();
            }

            return View(usuarioOng);
        }

        // GET: UsuarioOng/Create
        [AllowAnonymous]
        public IActionResult Create()
        {
            return View();
        }

        // POST: UsuarioOng/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Cnpj_Id,Cnpj,Nome,Email,Senha,Contato,Tipo")] UsuarioOng usuarioOng)
        {
            if (ModelState.IsValid)
            {
                string cnpj1 = usuarioOng.Cnpj_Id[..2];
                string cnpj2 = usuarioOng.Cnpj_Id.Substring(2, 3);
                string cnpj3 = usuarioOng.Cnpj_Id.Substring(5, 3);
                string cnpj4 = usuarioOng.Cnpj_Id.Substring(8, 4);
                string cnpj5 = usuarioOng.Cnpj_Id[12..];
                usuarioOng.Cnpj = $"{cnpj1}.{cnpj2}.{cnpj3}/{cnpj4}-{cnpj5}";
                usuarioOng.Tipo = Tipo.Ong;
                TempData["user_id"] = usuarioOng.Cnpj_Id;
                _context.Add(usuarioOng);
                usuarioOng.Senha = BCrypt.Net.BCrypt.HashPassword(usuarioOng.Senha);
                await _context.SaveChangesAsync();
                return RedirectToAction("Create", "DadoBancario");
            }
            return View(usuarioOng);
        }

        // GET: UsuarioOng/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var usuarioOng = await _context.UsuariosOng.FindAsync(id);
            if (usuarioOng == null)
            {
                return NotFound();
            }
            return View(usuarioOng);
        }

        // POST: UsuarioOng/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("Cnpj_Id,Cnpj,Nome,Email,Senha,Contato,Tipo")] UsuarioOng usuarioOng)
        {
            if (id != usuarioOng.Cnpj_Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(usuarioOng);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!UsuarioOngExists(usuarioOng.Cnpj_Id))
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
            return View(usuarioOng);
        }

        // GET: UsuarioOng/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var usuarioOng = await _context.UsuariosOng
                .FirstOrDefaultAsync(m => m.Cnpj_Id == id);
            if (usuarioOng == null)
            {
                return NotFound();
            }

            return View(usuarioOng);
        }

        // POST: UsuarioOng/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var usuarioOng = await _context.UsuariosOng.FindAsync(id);
            _context.UsuariosOng.Remove(usuarioOng);
            await _context.SaveChangesAsync();
            return RedirectToAction("Logout");
        }

        private bool UsuarioOngExists(string id)
        {
            return _context.UsuariosOng.Any(e => e.Cnpj_Id == id);
        }
    }
}
