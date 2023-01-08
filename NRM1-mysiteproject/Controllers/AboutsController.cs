﻿using System;
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
    public class AboutsController : Controller
    {
        private readonly MySiteContext _context;

        public AboutsController(MySiteContext context)
        {
            _context = context;
        }

        // GET: Abouts
        public async Task<IActionResult> Index()
        {
              return _context.Abouts != null ? 
                          View(await _context.Abouts.ToListAsync()) :
                          Problem("Entity set 'MySiteContext.Abouts'  is null.");
        }

        // GET: Abouts/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Abouts == null)
            {
                return NotFound();
            }

            var about = await _context.Abouts
                .FirstOrDefaultAsync(m => m.ID == id);
            if (about == null)
            {
                return NotFound();
            }

            return View(about);
        }

        // GET: Abouts/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Abouts/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,Header,Text,TextDate,TextPic")] About about, IFormFile TextPic)
        {
            if (ModelState.IsValid)
            {
                if (TextPic!=null)
                {
                    string imageName=TextPic.FileName;
                    string path = Path.Combine(Directory.GetCurrentDirectory(), $"wwwroot/images/{imageName}");
                    var stream=new FileStream(path,FileMode.Create);
                    about.TextPic = imageName;
                    TextPic.CopyTo(stream);
                }
                _context.Add(about);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(about);
        }

        // GET: Abouts/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Abouts == null)
            {
                return NotFound();
            }

            var about = await _context.Abouts.FindAsync(id);
            if (about == null)
            {
                return NotFound();
            }
            return View(about);
        }

        // POST: Abouts/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,Header,Text,TextDate,TextPic")] About about)
        {
            if (id != about.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(about);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AboutExists(about.ID))
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
            return View(about);
        }

        // GET: Abouts/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Abouts == null)
            {
                return NotFound();
            }

            var about = await _context.Abouts
                .FirstOrDefaultAsync(m => m.ID == id);
            if (about == null)
            {
                return NotFound();
            }

            return View(about);
        }

        // POST: Abouts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Abouts == null)
            {
                return Problem("Entity set 'MySiteContext.Abouts'  is null.");
            }
            var about = await _context.Abouts.FindAsync(id);
            if (about != null)
            {
                _context.Abouts.Remove(about);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AboutExists(int id)
        {
          return (_context.Abouts?.Any(e => e.ID == id)).GetValueOrDefault();
        }
    }
}
