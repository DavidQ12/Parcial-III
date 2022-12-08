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
    public class ServiciesController : Controller
    {
        private readonly D_CarsContext _context;

        public ServiciesController(D_CarsContext context)
        {
            _context = context;
        }

        // GET: Servicies
        public async Task<IActionResult> Index()
        {
            return View(await _context.Servicies.ToListAsync());
        }

        // GET: Servicies/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var servicies = await _context.Servicies
                .FirstOrDefaultAsync(m => m.Id == id);
            if (servicies == null)
            {
                return NotFound();
            }

            return View(servicies);
        }

        // GET: Servicies/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Servicies/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Servicio1,Servicio2,Servicio3,Servicio4")] Servicies servicies)
        {
            if (ModelState.IsValid)
            {
                _context.Add(servicies);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(servicies);
        }

        // GET: Servicies/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var servicies = await _context.Servicies.FindAsync(id);
            if (servicies == null)
            {
                return NotFound();
            }
            return View(servicies);
        }

        // POST: Servicies/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Servicio1,Servicio2,Servicio3,Servicio4")] Servicies servicies)
        {
            if (id != servicies.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(servicies);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ServiciesExists(servicies.Id))
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
            return View(servicies);
        }

        // GET: Servicies/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var servicies = await _context.Servicies
                .FirstOrDefaultAsync(m => m.Id == id);
            if (servicies == null)
            {
                return NotFound();
            }

            return View(servicies);
        }

        // POST: Servicies/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var servicies = await _context.Servicies.FindAsync(id);
            _context.Servicies.Remove(servicies);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ServiciesExists(int id)
        {
            return _context.Servicies.Any(e => e.Id == id);
        }
    }
}
