using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using NRM1_mysiteproject.Models.Context;
using NRM1_mysiteproject.Models.Entities;

namespace NRM1_mysiteproject.Controllers
{
    public class HakkimdasController : Controller
    {
        private readonly MySiteContext _context;

        public HakkimdasController(MySiteContext context)
        {
            _context = context;
        }

        // GET: Hakkimdas
        public async Task<IActionResult> Index()
        {
              return _context.Hakkimdas != null ? 
                          View(await _context.Hakkimdas.ToListAsync()) :
                          Problem("Entity set 'MySiteContext.Hakkimdas'  is null.");
        }

        // GET: Hakkimdas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Hakkimdas == null)
            {
                return NotFound();
            }

            var hakkimda = await _context.Hakkimdas
                .FirstOrDefaultAsync(m => m.ID == id);
            if (hakkimda == null)
            {
                return NotFound();
            }

            return View(hakkimda);
        }

        // GET: Hakkimdas/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Hakkimdas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,Baslik,Yazi,YaziTarih,YaziFoto")] Hakkimda hakkimda,IFormFile YaziFoto)
        {
            if (ModelState.IsValid)
            {
                if (YaziFoto!=null)
                {
                    string imageName=YaziFoto.FileName;
                    string path = Path.Combine(Directory.GetCurrentDirectory(), $"wwwroot/images/{imageName}");
                    var stream=new FileStream(path,FileMode.Create);
                    hakkimda.YaziFoto = imageName;
                    YaziFoto.CopyTo(stream);
                }
                _context.Add(hakkimda);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(hakkimda);
        }

        // GET: Hakkimdas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Hakkimdas == null)
            {
                return NotFound();
            }

            var hakkimda = await _context.Hakkimdas.FindAsync(id);
            if (hakkimda == null)
            {
                return NotFound();
            }
            return View(hakkimda);
        }

        // POST: Hakkimdas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,Baslik,Yazi,YaziTarih,YaziFoto")] Hakkimda hakkimda)
        {
            if (id != hakkimda.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(hakkimda);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!HakkimdaExists(hakkimda.ID))
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
            return View(hakkimda);
        }

        // GET: Hakkimdas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Hakkimdas == null)
            {
                return NotFound();
            }

            var hakkimda = await _context.Hakkimdas
                .FirstOrDefaultAsync(m => m.ID == id);
            if (hakkimda == null)
            {
                return NotFound();
            }

            return View(hakkimda);
        }

        // POST: Hakkimdas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Hakkimdas == null)
            {
                return Problem("Entity set 'MySiteContext.Hakkimdas'  is null.");
            }
            var hakkimda = await _context.Hakkimdas.FindAsync(id);
            if (hakkimda != null)
            {
                _context.Hakkimdas.Remove(hakkimda);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool HakkimdaExists(int id)
        {
          return (_context.Hakkimdas?.Any(e => e.ID == id)).GetValueOrDefault();
        }
    }
}
