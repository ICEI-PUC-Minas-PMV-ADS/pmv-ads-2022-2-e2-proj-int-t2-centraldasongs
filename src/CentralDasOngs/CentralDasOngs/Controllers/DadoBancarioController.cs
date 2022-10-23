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
    public class DadoBancarioController : Controller
    {
        private readonly CentralDasOngsContext _context;

        public DadoBancarioController(CentralDasOngsContext context)
        {
            _context = context;
        }

        // GET: DadoBancario
        public async Task<IActionResult> Index()
        {
            var centralDasOngsContext = _context.DadosBancarios.Include(d => d.Banco).Include(d => d.UsuarioOng);
            return View(await centralDasOngsContext.ToListAsync());
        }

        // GET: DadoBancario/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var dadoBancario = await _context.DadosBancarios
                .Include(d => d.Banco)
                .Include(d => d.UsuarioOng)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (dadoBancario == null)
            {
                return NotFound();
            }

            return View(dadoBancario);
        }

        // GET: DadoBancario/Create
        public IActionResult Create()
        {
            ViewData["Codigo"] = new SelectList(_context.Bancos, "Codigo", "Codigo");
            ViewData["UsuarioOngCnpj"] = new SelectList(_context.UsuariosOng, "Cnpj_Id", "Cnpj_Id");
            return View();
        }

        // POST: DadoBancario/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,NumeroConta,Agencia,Operacao,Codigo,UsuarioOngCnpj")] DadoBancario dadoBancario)
        {
            if (ModelState.IsValid)
            {
                dadoBancario.UsuarioOngCnpj = TempData["user_id"].ToString();
                _context.Add(dadoBancario);
                await _context.SaveChangesAsync();
                TempData["tipo"] = true;
                TempData["user_id"] = dadoBancario.UsuarioOngCnpj;
                return RedirectToAction("Create", "Endereco");
            }
            ViewData["Codigo"] = new SelectList(_context.Bancos, "Codigo", "Codigo", dadoBancario.Codigo);
            ViewData["UsuarioOngCnpj"] = new SelectList(_context.UsuariosOng, "Cnpj_Id", "Cnpj_Id", dadoBancario.UsuarioOngCnpj);
            return View(dadoBancario);
        }

        // GET: DadoBancario/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var dadoBancario = await _context.DadosBancarios.FindAsync(id);
            if (dadoBancario == null)
            {
                return NotFound();
            }
            ViewData["Codigo"] = new SelectList(_context.Bancos, "Codigo", "Codigo", dadoBancario.Codigo);
            ViewData["UsuarioOngCnpj"] = new SelectList(_context.UsuariosOng, "Cnpj_Id", "Cnpj_Id", dadoBancario.UsuarioOngCnpj);
            return View(dadoBancario);
        }

        // POST: DadoBancario/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,NumeroConta,Agencia,Operacao,Codigo,UsuarioOngCnpj")] DadoBancario dadoBancario)
        {
            if (id != dadoBancario.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(dadoBancario);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DadoBancarioExists(dadoBancario.Id))
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
            ViewData["Codigo"] = new SelectList(_context.Bancos, "Codigo", "Codigo", dadoBancario.Codigo);
            ViewData["UsuarioOngCnpj"] = new SelectList(_context.UsuariosOng, "Cnpj_Id", "Cnpj_Id", dadoBancario.UsuarioOngCnpj);
            return View(dadoBancario);
        }

        // GET: DadoBancario/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var dadoBancario = await _context.DadosBancarios
                .Include(d => d.Banco)
                .Include(d => d.UsuarioOng)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (dadoBancario == null)
            {
                return NotFound();
            }

            return View(dadoBancario);
        }

        // POST: DadoBancario/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var dadoBancario = await _context.DadosBancarios.FindAsync(id);
            _context.DadosBancarios.Remove(dadoBancario);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DadoBancarioExists(int id)
        {
            return _context.DadosBancarios.Any(e => e.Id == id);
        }
    }
}
