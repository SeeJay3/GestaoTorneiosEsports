using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using GestaoTorneiosEsports.Data;
using GestaoTorneiosEsports.Models;

namespace GestaoTorneiosEsports.Controllers
{
    public class TorneiosController : Controller
    {
        private readonly AppDbContext _context;

        public TorneiosController(AppDbContext context)
        {
            _context = context;
        }

        // GET: Torneios
        public async Task<IActionResult> Index()
        {
            var torneios = await _context.Torneios.ToListAsync(); 
            return View(torneios); 
        }


        // GET: Torneios/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var torneio = await _context.Torneios
                .FirstOrDefaultAsync(m => m.TorneioId == id);
            if (torneio == null)
            {
                return NotFound();
            }

            return View(torneio);
        }

        // GET: Torneios/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Torneios/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("TorneioId,Nome,Jogo,DataInicio,DataFim,PremioTotal,Descricao")] Torneio torneio)
        {
            if (ModelState.IsValid)
            {
                _context.Add(torneio);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(torneio);
        }

        // GET: Torneios/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var torneio = await _context.Torneios.FindAsync(id);
            if (torneio == null)
            {
                return NotFound();
            }
            return View(torneio);
        }

        // POST: Torneios/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("TorneioId,Nome,Jogo,DataInicio,DataFim,PremioTotal,Descricao")] Torneio torneio)
        {
            if (id != torneio.TorneioId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(torneio);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TorneioExists(torneio.TorneioId))
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
            return View(torneio);
        }

        // GET: Torneios/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var torneio = await _context.Torneios
                .FirstOrDefaultAsync(m => m.TorneioId == id);
            if (torneio == null)
            {
                return NotFound();
            }

            return View(torneio);
        }

        // POST: Torneios/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var torneio = await _context.Torneios.FindAsync(id);
            if (torneio != null)
            {
                _context.Torneios.Remove(torneio);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TorneioExists(int id)
        {
            return _context.Torneios.Any(e => e.TorneioId == id);
        }
    }
}
