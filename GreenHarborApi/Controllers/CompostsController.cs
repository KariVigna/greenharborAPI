using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using GreenHarborApi.Models;

namespace GreenHarborApi.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class CompostsController : ControllerBase
  {
    private readonly GreenHarborApiContext _db;

    public CompostsController(GreenHarborApiContext db)
    {
      _db = db;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Compost>>> GetComposts(string city, string zip)
    {
      IQueryable<Compost> query = _db.Composts.AsQueryable();

      if (city != null)
      {
        query = query.Where(entry => entry.City == city);
      }

      if (zip != null)
      {
        query = query.Where(entry => entry.Zip == zip);
      }
      return await query.ToListAsync();
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Compost>> GetCompost(int id)
    {
      Compost compost = await _db.Composts.FindAsync(id);

      if (compost == null)
      {
        return NotFound();
      }
      return compost;
    }
    
    [HttpPost]
    public async Task<ActionResult<Compost>> Post(Compost compost)
    {
      _db.Composts.Add(compost);
      await _db.SaveChangesAsync();
      return CreatedAtAction(nameof(GetComposts), new { id = compost.CompostId }, compost);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Put(int id, Compost compost)
    {
      if (id != compost.CompostId)
      {
        return BadRequest();
      }
      
      _db.Composts.Update(compost);

      try
      {
        await _db.SaveChangesAsync();
      }
      catch (DbUpdateConcurrencyException)
      {
        if (!CompostExists(id))
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
  
    private bool CompostExists(int id)
    {
      return _db.Composts.Any(e => e.CompostId == id);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteCompost(int id)
    {
      Compost compost = await _db.Composts.FindAsync(id);
      if (compost == null)
      {
        return NotFound();
      }
      
      _db.Composts.Remove(compost);
      await _db.SaveChangesAsync();

      return NoContent();
    }

  }
}