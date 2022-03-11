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
    public class MuayeneController : Controller
    {
        private readonly HastaneOtomasyonDBContext _context;

        public MuayeneController(HastaneOtomasyonDBContext context)
        {
            _context = context;
        }

        // GET: Muayene
        public async Task<IActionResult> Index()
        {
            var hastaneOtomasyonDBContext = _context.Muayene.Include(m => m.Birim).Include(m => m.Doktor).Include(m => m.Hasta).Include(m => m.ÖdemeTipi);
            return View(await hastaneOtomasyonDBContext.ToListAsync());
        }

        // GET: Muayene/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var muayene = await _context.Muayene
                .Include(m => m.Birim)
                .Include(m => m.Doktor)
                .Include(m => m.Hasta)
                .Include(m => m.ÖdemeTipi)
                .FirstOrDefaultAsync(m => m.MuayeneID == id);
            if (muayene == null)
            {
                return NotFound();
            }

            return View(muayene);
        }

        // GET: Muayene/Create
        public IActionResult Create()
        {
            ViewData["BirimID"] = new SelectList(_context.Birim, "BirimID", "BirimAdı");
            ViewData["DoktorID"] = new SelectList(_context.Doktor, "DoktorID", "DoktorTamAdı");
            ViewData["HastaID"] = new SelectList(_context.Hasta, "HastaID", "HastaTamAdı");
            ViewData["ÖdemeTipiID"] = new SelectList(_context.ÖdemeTipi, "ÖdemeTipiID", "ÖdemeTipiAdı");
            return View();
        }

        // POST: Muayene/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("MuayeneID,BirimID,HastaID,DoktorID,HastaGeçmişi,HastaTeşhis,HastaTedavi,Yazılanİlaçlar,ÖdemeTipiID")] Muayene muayene)
        {
            if (ModelState.IsValid)
            {
                _context.Add(muayene);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["BirimID"] = new SelectList(_context.Birim, "BirimID", "BirimAdı", muayene.BirimID);
            ViewData["DoktorID"] = new SelectList(_context.Doktor, "DoktorID", "DoktorTamAdı", muayene.DoktorID);
            ViewData["HastaID"] = new SelectList(_context.Hasta, "HastaID", "HastaTamAdı", muayene.HastaID);
            ViewData["ÖdemeTipiID"] = new SelectList(_context.ÖdemeTipi, "ÖdemeTipiID", "ÖdemeTipiAdı", muayene.ÖdemeTipiID);
            return View(muayene);
        }

        // GET: Muayene/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var muayene = await _context.Muayene.FindAsync(id);
            if (muayene == null)
            {
                return NotFound();
            }
            ViewData["BirimID"] = new SelectList(_context.Birim, "BirimID", "BirimAdı", muayene.BirimID);
            ViewData["DoktorID"] = new SelectList(_context.Doktor, "DoktorID", "DoktorTamAdı", muayene.DoktorID);
            ViewData["HastaID"] = new SelectList(_context.Hasta, "HastaID", "HastaTamAdı", muayene.HastaID);
            ViewData["ÖdemeTipiID"] = new SelectList(_context.ÖdemeTipi, "ÖdemeTipiID", "ÖdemeTipiAdı", muayene.ÖdemeTipiID);
            return View(muayene);
        }

        // POST: Muayene/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("MuayeneID,BirimID,HastaID,DoktorID,HastaGeçmişi,HastaTeşhis,HastaTedavi,Yazılanİlaçlar,ÖdemeTipiID")] Muayene muayene)
        {
            if (id != muayene.MuayeneID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(muayene);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MuayeneExists(muayene.MuayeneID))
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
            ViewData["BirimID"] = new SelectList(_context.Birim, "BirimID", "BirimAdı", muayene.BirimID);
            ViewData["DoktorID"] = new SelectList(_context.Doktor, "DoktorID", "DoktorTamAdı", muayene.DoktorID);
            ViewData["HastaID"] = new SelectList(_context.Hasta, "HastaID", "HastaTamAdı", muayene.HastaID);
            ViewData["ÖdemeTipiID"] = new SelectList(_context.ÖdemeTipi, "ÖdemeTipiID", "ÖdemeTipiAdı", muayene.ÖdemeTipiID);
            return View(muayene);
        }

        // GET: Muayene/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var muayene = await _context.Muayene
                .Include(m => m.Birim)
                .Include(m => m.Doktor)
                .Include(m => m.Hasta)
                .Include(m => m.ÖdemeTipi)
                .FirstOrDefaultAsync(m => m.MuayeneID == id);
            if (muayene == null)
            {
                return NotFound();
            }

            return View(muayene);
        }

        // POST: Muayene/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var muayene = await _context.Muayene.FindAsync(id);
            _context.Muayene.Remove(muayene);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MuayeneExists(int id)
        {
            return _context.Muayene.Any(e => e.MuayeneID == id);
        }
    }
}
