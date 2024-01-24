using AirFranceDI22Model.Context;
using AirFranceDI22Model.Dao;
using AirFranceDI22Model.Dto;
using AirFranceDI22Model.Extensions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AirFranceAPI.Controllers;

[Authorize]
[Route("api/[controller]")]
[ApiController]
public class VolsController : ControllerBase
{
    private readonly AirFranceDI22Context _context;

    public VolsController(AirFranceDI22Context context)
    {
        _context = context;
    }

    // GET: api/Vols
    [HttpGet]
    public async Task<ActionResult<IEnumerable<VolLightDto>>> GetVols()
    {
        return await _context.Vols
            .Include(v => v.Compagnie)
            .Include(v => v.AeroportArrivee)
            .Include(v => v.AeroportDepart)
            .Where(v => v.OuvertResa)
            .Select(v => v.ToLightDto())
            .ToListAsync();
    }

    // GET: api/Vols/search/yyyy-MM-dd
    [HttpGet]
    [Route("search/{dateJour}")]
    public async Task<ActionResult<IEnumerable<VolLightDto>>> SearchVols(DateTime dateJour)
    {
        return await _context.Vols
            .Include(v => v.Compagnie)
            .Include(v => v.AeroportArrivee)
            .Include(v => v.AeroportDepart)
            .Where(v => v.OuvertResa && 
                        v.DateHeureDepart >= dateJour &&
                        v.DateHeureDepart < dateJour.AddDays(1))
            .Select(v => v.ToLightDto())
            .ToListAsync();
    }

    // GET: api/Vols/5
    [HttpGet("{id}")]
    public async Task<ActionResult<VolDto>> GetVol(int id)
    {

        var vol = await _context.Vols
            .Include(v => v.Compagnie)
            .Include(v => v.AeroportArrivee).ThenInclude(a => a!.Ville)
            .Include(v => v.AeroportDepart).ThenInclude(a => a!.Ville)
            .Where(v => v.Id == id)
            .Select(v => v.ToDto())
            .FirstOrDefaultAsync();
            

        if (vol == null)
        {
            return NotFound();
        }

        return vol;
    }

    // PUT: api/Vols/5
    // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
    [HttpPut("{id}")]
    public async Task<IActionResult> PutVol(int id, Vol vol)
    {
        if (id != vol.Id)
        {
            return BadRequest();
        }

        _context.Entry(vol).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!VolExists(id))
            {
                return NotFound();
            }
            else
            {
                throw;
            }
        }

        return NoContent();
    }

    // POST: api/Vols
    // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
    [HttpPost]
    public async Task<ActionResult<Vol>> PostVol(Vol vol)
    {
        _context.Vols.Add(vol);
        await _context.SaveChangesAsync();

        return CreatedAtAction("GetVol", new { id = vol.Id }, vol);
    }

    // DELETE: api/Vols/5
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteVol(int id)
    {
        var vol = await _context.Vols.FindAsync(id);
        if (vol == null)
        {
            return NotFound();
        }

        _context.Vols.Remove(vol);
        await _context.SaveChangesAsync();

        return NoContent();
    }

    private bool VolExists(int id)
    {
        return _context.Vols.Any(e => e.Id == id);
    }
}
