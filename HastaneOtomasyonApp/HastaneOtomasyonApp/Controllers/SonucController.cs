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
    public class SonucController : Controller
    {
        private readonly HastaneOtomasyonDBContext _context;

        public SonucController(HastaneOtomasyonDBContext context)
        {
            _context = context;
        }

        // GET: Sonuc
        public async Task<IActionResult> Index()
        {
            return View(await _context.Sonuc.ToListAsync());
        }

        // GET: Sonuc/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sonuc = await _context.Sonuc
                .FirstOrDefaultAsync(m => m.SonucID == id);
            if (sonuc == null)
            {
                return NotFound();
            }

            return View(sonuc);
        }

        // GET: Sonuc/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Sonuc/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("SonucID,SonucAd")] Sonuc sonuc)
        {
            if (ModelState.IsValid)
            {
                _context.Add(sonuc);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(sonuc);
        }

        // GET: Sonuc/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sonuc = await _context.Sonuc.FindAsync(id);
            if (sonuc == null)
            {
                return NotFound();
            }
            return View(sonuc);
        }

        // POST: Sonuc/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("SonucID,SonucAd")] Sonuc sonuc)
        {
            if (id != sonuc.SonucID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(sonuc);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SonucExists(sonuc.SonucID))
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
            return View(sonuc);
        }

        // GET: Sonuc/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sonuc = await _context.Sonuc
                .FirstOrDefaultAsync(m => m.SonucID == id);
            if (sonuc == null)
            {
                return NotFound();
            }

            return View(sonuc);
        }

        // POST: Sonuc/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var sonuc = await _context.Sonuc.FindAsync(id);
            _context.Sonuc.Remove(sonuc);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SonucExists(int id)
        {
            return _context.Sonuc.Any(e => e.SonucID == id);
        }
    }
}
