using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using TesteDeClasses.Models;

namespace TesteDeClasses.Controllers
{
    [Authorize (Roles = "Ong")]
    public class UsuariosOngController : Controller
    {
        private readonly ApplicationDbContext _context;

        public UsuariosOngController(ApplicationDbContext context)
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
            var user = await _context.Usuarios_ong 
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
                    new Claim(ClaimTypes.Spn, user.CnpjId),
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

        // GET: UsuariosOng
        public async Task<IActionResult> Index()
        {
            return View(await _context.Usuarios_ong.ToListAsync());
        }

        // GET: UsuariosOng/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var usuarioOng = await _context.Usuarios_ong
                .FirstOrDefaultAsync(m => m.CnpjId == id);
            if (usuarioOng == null)
            {
                return NotFound();
            }

            return View(usuarioOng);
        }

        // GET: UsuariosOng/Create
        [AllowAnonymous]
        public IActionResult Create()
        {
            return View();
        }

        // POST: UsuariosOng/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [AllowAnonymous]
        public async Task<IActionResult> Create([Bind("CnpjId,Nome,Email,Senha,Contato,Estado,Cidade,Logadouro,Bairro,NumeroEndereco,Complemento,Tipo,Cnpj")] UsuarioOng usuarioOng)
        {
            if (ModelState.IsValid)
            {
                string cnpj1 = usuarioOng.CnpjId[..2];
                string cnpj2 = usuarioOng.CnpjId.Substring(2, 3);
                string cnpj3 = usuarioOng.CnpjId.Substring(5, 3);
                string cnpj4 = usuarioOng.CnpjId.Substring(8, 4);
                string cnpj5 = usuarioOng.CnpjId[12..];
                usuarioOng.Cnpj = $"{cnpj1}.{cnpj2}.{cnpj3}/{cnpj4}-{cnpj5}";
                usuarioOng.Tipo = Tipo.Ong;
                usuarioOng.Senha = BCrypt.Net.BCrypt.HashPassword(usuarioOng.Senha);
                _context.Add(usuarioOng);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(usuarioOng);
        }

        // GET: UsuariosOng/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var usuarioOng = await _context.Usuarios_ong.FindAsync(id);
            if (usuarioOng == null)
            {
                return NotFound();
            }
            return View(usuarioOng);
        }

        // POST: UsuariosOng/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("Cnpj,Nome,Email,Senha,Contato,Estado,Cidade,Logadouro,Bairro,NumeroEndereco,Complemento,Tipo,Cnpj")] UsuarioOng usuarioOng)
        {
            if (id != usuarioOng.CnpjId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    usuarioOng.Senha = BCrypt.Net.BCrypt.HashPassword(usuarioOng.Senha);
                    _context.Update(usuarioOng);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!UsuarioOngExists(usuarioOng.CnpjId))
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

        // GET: UsuariosOng/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var usuarioOng = await _context.Usuarios_ong
                .FirstOrDefaultAsync(m => m.CnpjId == id);
            if (usuarioOng == null)
            {
                return NotFound();
            }

            return View(usuarioOng);
        }

        // POST: UsuariosOng/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var usuarioOng = await _context.Usuarios_ong.FindAsync(id);
            _context.Usuarios_ong.Remove(usuarioOng);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool UsuarioOngExists(string id)
        {
            return _context.Usuarios_ong.Any(e => e.CnpjId == id);
        }
    }
}
