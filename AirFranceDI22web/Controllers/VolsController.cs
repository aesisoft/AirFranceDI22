using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using AirFranceDI22Model.Context;
using AirFranceDI22Model.Dao;
using Microsoft.AspNetCore.Authorization;

namespace AirFranceDI22web.Controllers;

public class VolsController : Controller
{
    private readonly AirFranceDI22Context _context;

    public VolsController(AirFranceDI22Context context)
    {
        _context = context;
    }

    // GET: Vols
    public async Task<IActionResult> Index()
    {
        var airFranceDI22Context = _context.Vols.Include(v => v.AeroportArrivee).Include(v => v.AeroportDepart).Include(v => v.Compagnie);
        return View(await airFranceDI22Context.ToListAsync());
    }

    // GET: Vols/Details/5
    public async Task<IActionResult> Details(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var vol = await _context.Vols
            .Include(v => v.AeroportArrivee)
            .Include(v => v.AeroportDepart)
            .Include(v => v.Compagnie)
            .FirstOrDefaultAsync(m => m.Id == id);
        if (vol == null)
        {
            return NotFound();
        }

        return View(vol);
    }

    // GET: Vols/Create
    public IActionResult Create()
    {
        ViewData["AeroportArriveeId"] = new SelectList(_context.Aeroports, "Id", "Nom");
        ViewData["AeroportDepartId"] = new SelectList(_context.Aeroports, "Id", "Nom");
        ViewData["CompagnieId"] = new SelectList(_context.Compagnies, "Id", "Nom");
        return View();
    }

    // POST: Vols/Create
    // To protect from overposting attacks, enable the specific properties you want to bind to.
    // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create([Bind("Id,NumeroVol,OuvertResa,DateHeureDepart,DateHeureArrivee,CompagnieId,AeroportDepartId,AeroportArriveeId")] Vol vol)
    {
        if (ModelState.IsValid)
        {
            _context.Add(vol);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        ViewData["AeroportArriveeId"] = new SelectList(_context.Aeroports, "Id", "Nom", vol.AeroportArriveeId);
        ViewData["AeroportDepartId"] = new SelectList(_context.Aeroports, "Id", "Nom", vol.AeroportDepartId);
        ViewData["CompagnieId"] = new SelectList(_context.Compagnies, "Id", "Nom", vol.CompagnieId);
        return View(vol);
    }

    // GET: Vols/Edit/5
    public async Task<IActionResult> Edit(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var vol = await _context.Vols.FindAsync(id);
        if (vol == null)
        {
            return NotFound();
        }
        ViewData["AeroportArriveeId"] = new SelectList(_context.Aeroports, "Id", "Nom", vol.AeroportArriveeId);
        ViewData["AeroportDepartId"] = new SelectList(_context.Aeroports, "Id", "Nom", vol.AeroportDepartId);
        ViewData["CompagnieId"] = new SelectList(_context.Compagnies, "Id", "Nom", vol.CompagnieId);
        return View(vol);
    }

    // POST: Vols/Edit/5
    // To protect from overposting attacks, enable the specific properties you want to bind to.
    // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(int id, [Bind("Id,NumeroVol,OuvertResa,DateHeureDepart,DateHeureArrivee,CompagnieId,AeroportDepartId,AeroportArriveeId")] Vol vol)
    {
        if (id != vol.Id)
        {
            return NotFound();
        }

        if (ModelState.IsValid)
        {
            try
            {
                _context.Update(vol);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!VolExists(vol.Id))
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
        ViewData["AeroportArriveeId"] = new SelectList(_context.Aeroports, "Id", "Nom", vol.AeroportArriveeId);
        ViewData["AeroportDepartId"] = new SelectList(_context.Aeroports, "Id", "Nom", vol.AeroportDepartId);
        ViewData["CompagnieId"] = new SelectList(_context.Compagnies, "Id", "Nom", vol.CompagnieId);
        return View(vol);
    }

    //// GET: Vols/Delete/5
    //public async Task<IActionResult> Delete(int? id)
    //{
    //    if (id == null)
    //    {
    //        return NotFound();
    //    }

    //    var vol = await _context.Vols
    //        .Include(v => v.AeroportArrivee)
    //        .Include(v => v.AeroportDepart)
    //        .Include(v => v.Compagnie)
    //        .FirstOrDefaultAsync(m => m.Id == id);
    //    if (vol == null)
    //    {
    //        return NotFound();
    //    }

    //    return View(vol);
    //}

    //// POST: Vols/Delete/5
    //[HttpPost, ActionName("Delete")]
    //[ValidateAntiForgeryToken]
    //public async Task<IActionResult> DeleteConfirmed(int id)
    //{
    //    var vol = await _context.Vols.FindAsync(id);
    //    if (vol != null)
    //    {
    //        _context.Vols.Remove(vol);
    //    }

    //    await _context.SaveChangesAsync();
    //    return RedirectToAction(nameof(Index));
    //}

    private bool VolExists(int id)
    {
        return _context.Vols.Any(e => e.Id == id);
    }
}
