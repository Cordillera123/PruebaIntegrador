﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using IntegradorP.Models;

namespace IntegradorP.Controllers
{
    public class PerfilsController : Controller
    {
        private readonly BaseDatosProyectoContext _context;

        public PerfilsController(BaseDatosProyectoContext context)
        {
            _context = context;
        }

        // GET: Perfils
        public async Task<IActionResult> Index()
        {
              return _context.Perfils != null ? 
                          View(await _context.Perfils.ToListAsync()) :
                          Problem("Entity set 'BaseDatosProyectoContext.Perfils'  is null.");
        }

        // GET: Perfils/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Perfils == null)
            {
                return NotFound();
            }

            var perfil = await _context.Perfils
                .FirstOrDefaultAsync(m => m.PerfilId == id);
            if (perfil == null)
            {
                return NotFound();
            }

            return View(perfil);
        }

        // GET: Perfils/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Perfils/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("PerfilId,DescripcionPer,Estado")] Perfil perfil)
        {
            if (ModelState.IsValid)
            {
                _context.Add(perfil);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(perfil);
        }

        // GET: Perfils/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Perfils == null)
            {
                return NotFound();
            }

            var perfil = await _context.Perfils.FindAsync(id);
            if (perfil == null)
            {
                return NotFound();
            }
            return View(perfil);
        }

        // POST: Perfils/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("PerfilId,DescripcionPer,Estado")] Perfil perfil)
        {
            if (id != perfil.PerfilId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(perfil);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PerfilExists(perfil.PerfilId))
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
            return View(perfil);
        }

        // GET: Perfils/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Perfils == null)
            {
                return NotFound();
            }

            var perfil = await _context.Perfils
                .FirstOrDefaultAsync(m => m.PerfilId == id);
            if (perfil == null)
            {
                return NotFound();
            }

            return View(perfil);
        }

        // POST: Perfils/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Perfils == null)
            {
                return Problem("Entity set 'BaseDatosProyectoContext.Perfils'  is null.");
            }
            var perfil = await _context.Perfils.FindAsync(id);
            if (perfil != null)
            {
                _context.Perfils.Remove(perfil);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PerfilExists(int id)
        {
          return (_context.Perfils?.Any(e => e.PerfilId == id)).GetValueOrDefault();
        }
    }
}
