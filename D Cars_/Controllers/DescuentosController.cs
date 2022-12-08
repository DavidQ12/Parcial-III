using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using D_Cars_.CONTEXT;
using D_Cars_.Models;

namespace D_Cars_.Controllers
{
    public class DescuentosController : Controller
    {
        private readonly D_CarsContext _context;

        public DescuentosController(D_CarsContext context)
        {
            _context = context;
        }

        // GET: Descuentos
        public async Task<IActionResult> Index()
        {
            return View(await _context.Descuentos.ToListAsync());
        }

        // GET: Descuentos/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var descuentos = await _context.Descuentos
                .FirstOrDefaultAsync(m => m.Id == id);
            if (descuentos == null)
            {
                return NotFound();
            }

            return View(descuentos);
        }

        // GET: Descuentos/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Descuentos/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Tipo_producto,Precie,Marca")] Descuentos descuentos)
        {
            if (ModelState.IsValid)
            {
                _context.Add(descuentos);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(descuentos);
        }

        // GET: Descuentos/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var descuentos = await _context.Descuentos.FindAsync(id);
            if (descuentos == null)
            {
                return NotFound();
            }
            return View(descuentos);
        }

        // POST: Descuentos/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Tipo_producto,Precie,Marca")] Descuentos descuentos)
        {
            if (id != descuentos.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(descuentos);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DescuentosExists(descuentos.Id))
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
            return View(descuentos);
        }

        // GET: Descuentos/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var descuentos = await _context.Descuentos
                .FirstOrDefaultAsync(m => m.Id == id);
            if (descuentos == null)
            {
                return NotFound();
            }

            return View(descuentos);
        }

        // POST: Descuentos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var descuentos = await _context.Descuentos.FindAsync(id);
            _context.Descuentos.Remove(descuentos);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DescuentosExists(int id)
        {
            return _context.Descuentos.Any(e => e.Id == id);
        }
    }
}
