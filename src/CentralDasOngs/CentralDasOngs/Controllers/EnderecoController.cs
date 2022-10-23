using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CentralDasOngs.Dados;
using CentralDasOngs.Models;

namespace CentralDasOngs.Controllers
{
    public class EnderecoController : Controller
    {
        private readonly CentralDasOngsContext _context;

        public EnderecoController(CentralDasOngsContext context)
        {
            _context = context;
        }

        // GET: Endereco
        public async Task<IActionResult> Index()
        {
            var centralDasOngsContext = _context.Enderecos.Include(e => e.UnidadeFederativa).Include(e => e.UsuarioOng).Include(e => e.UsuarioVoluntario);
            return View(await centralDasOngsContext.ToListAsync());
        }

        // GET: Endereco/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var endereco = await _context.Enderecos
                .Include(e => e.UnidadeFederativa)
                .Include(e => e.UsuarioOng)
                .Include(e => e.UsuarioVoluntario)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (endereco == null)
            {
                return NotFound();
            }

            return View(endereco);
        }

        // GET: Endereco/Create
        public IActionResult Create()
        {
            ViewData["Uf"] = new SelectList(_context.Ufs, "Uf", "Uf");
            ViewData["UsuarioVoluntarioCpf"] = new SelectList(_context.UsuariosVoluntarios, "Cpf_Id", "Cpf_Id");
            ViewData["UsuarioOngCnpj"] = new SelectList(_context.UsuariosOng, "Cnpj_Id", "Cnpj_Id");
            return View();
        }

        // POST: Endereco/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Logradouro,Bairro,NumeroEndereco,Complemento,Cidade,UsuarioOngCnpj,UsuarioVoluntarioCpf,Uf")] Endereco endereco)
            {
            endereco.UsuarioVoluntarioCpf = TempData["user_cpf"].ToString();
            if (ModelState.IsValid)
            {
                _context.Add(endereco);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index","Home");
            }
            ViewData["Uf"] = new SelectList(_context.Ufs, "Uf", "Uf", endereco.Uf);
            ViewData["UsuarioOngCnpj"] = new SelectList(_context.UsuariosOng, "Cnpj_Id", "Cnpj_Id", endereco.UsuarioOngCnpj);
            ViewData["UsuarioVoluntarioCpf"] = new SelectList(_context.UsuariosVoluntarios, "Cpf_Id", "Cpf_Id", endereco.UsuarioVoluntarioCpf);
            return View(endereco);
        }



        // GET: Endereco/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var endereco = await _context.Enderecos.FindAsync(id);
            if (endereco == null)
            {
                return NotFound();
            }
            ViewData["Uf"] = new SelectList(_context.Ufs, "Uf", "Uf", endereco.Uf);
            ViewData["UsuarioOngCnpj"] = new SelectList(_context.UsuariosOng, "Cnpj_Id", "Cnpj_Id", endereco.UsuarioOngCnpj);
            ViewData["UsuarioVoluntarioCpf"] = new SelectList(_context.UsuariosVoluntarios, "Cpf_Id", "Cpf_Id", endereco.UsuarioVoluntarioCpf);
            return View(endereco);
        }

        // POST: Endereco/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Logradouro,Bairro,NumeroEndereco,Complemento,Cidade,UsuarioVoluntarioCpf,UsuarioOngCnpj,Uf")] Endereco endereco)
        {
            if (id != endereco.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(endereco);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EnderecoExists(endereco.Id))
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
            ViewData["Uf"] = new SelectList(_context.Ufs, "Uf", "Uf", endereco.Uf);
            ViewData["UsuarioOngCnpj"] = new SelectList(_context.UsuariosOng, "Cnpj_Id", "Cnpj_Id", endereco.UsuarioOngCnpj);
            ViewData["UsuarioVoluntarioCpf"] = new SelectList(_context.UsuariosVoluntarios, "Cpf_Id", "Cpf_Id", endereco.UsuarioVoluntarioCpf);
            return View(endereco);
        }

        // GET: Endereco/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var endereco = await _context.Enderecos
                .Include(e => e.UnidadeFederativa)
                .Include(e => e.UsuarioOng)
                .Include(e => e.UsuarioVoluntario)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (endereco == null)
            {
                return NotFound();
            }

            return View(endereco);
        }

        // POST: Endereco/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var endereco = await _context.Enderecos.FindAsync(id);
            _context.Enderecos.Remove(endereco);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EnderecoExists(int id)
        {
            return _context.Enderecos.Any(e => e.Id == id);
        }
    }
}
