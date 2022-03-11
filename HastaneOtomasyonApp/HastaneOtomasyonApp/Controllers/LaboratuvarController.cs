using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using HastaneOtomasyonApp.Data;
using HastaneOtomasyonApp.Models;

namespace HastaneOtomasyonApp.Controllers
{
    public class LaboratuvarController : Controller
    {
        private readonly HastaneOtomasyonDBContext _context;

        public LaboratuvarController(HastaneOtomasyonDBContext context)
        {
            _context = context;
        }

        // GET: Laboratuvar
        public async Task<IActionResult> Index()
        {
            var hastaneOtomasyonDBContext = _context.Laboratuvar.Include(l => l.Hasta).Include(l => l.Sonuc);
            return View(await hastaneOtomasyonDBContext.ToListAsync());
        }

        // GET: Laboratuvar/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var laboratuvar = await _context.Laboratuvar
                .Include(l => l.Hasta)
                .Include(l => l.Sonuc)
                .FirstOrDefaultAsync(m => m.LaboratuvarID == id);
            if (laboratuvar == null)
            {
                return NotFound();
            }

            return View(laboratuvar);
        }

        // GET: Laboratuvar/Create
        public IActionResult Create()
        {
            ViewData["HastaID"] = new SelectList(_context.Hasta, "HastaID", "HastaTamAdı");
            ViewData["SonucID"] = new SelectList(_context.Sonuc, "SonucID", "SonucAd");
            return View();
        }

        // POST: Laboratuvar/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("LaboratuvarID,SonucID,HastaID")] Laboratuvar laboratuvar)
        {
            if (ModelState.IsValid)
            {
                _context.Add(laboratuvar);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["HastaID"] = new SelectList(_context.Hasta, "HastaID", "HastaTamAdı", laboratuvar.HastaID);
            ViewData["SonucID"] = new SelectList(_context.Sonuc, "SonucID", "SonucAd", laboratuvar.SonucID);
            return View(laboratuvar);
        }

        // GET: Laboratuvar/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var laboratuvar = await _context.Laboratuvar.FindAsync(id);
            if (laboratuvar == null)
            {
                return NotFound();
            }
            ViewData["HastaID"] = new SelectList(_context.Hasta, "HastaID", "HastaTamAdı", laboratuvar.HastaID);
            ViewData["SonucID"] = new SelectList(_context.Sonuc, "SonucID", "SonucAd", laboratuvar.SonucID);
            return View(laboratuvar);
        }

        // POST: Laboratuvar/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("LaboratuvarID,SonucID,HastaID")] Laboratuvar laboratuvar)
        {
            if (id != laboratuvar.LaboratuvarID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(laboratuvar);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!LaboratuvarExists(laboratuvar.LaboratuvarID))
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
            ViewData["HastaID"] = new SelectList(_context.Hasta, "HastaID", "HastaTamAdı", laboratuvar.HastaID);
            ViewData["SonucID"] = new SelectList(_context.Sonuc, "SonucID", "SonucAd", laboratuvar.SonucID);
            return View(laboratuvar);
        }

        // GET: Laboratuvar/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var laboratuvar = await _context.Laboratuvar
                .Include(l => l.Hasta)
                .Include(l => l.Sonuc)
                .FirstOrDefaultAsync(m => m.LaboratuvarID == id);
            if (laboratuvar == null)
            {
                return NotFound();
            }

            return View(laboratuvar);
        }

        // POST: Laboratuvar/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var laboratuvar = await _context.Laboratuvar.FindAsync(id);
            _context.Laboratuvar.Remove(laboratuvar);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool LaboratuvarExists(int id)
        {
            return _context.Laboratuvar.Any(e => e.LaboratuvarID == id);
        }
    }
}
