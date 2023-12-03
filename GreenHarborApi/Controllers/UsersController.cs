using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using GreenHarborApi.Models;

namespace GreenHarborApi.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class UsersController : ControllerBase
  {
    private readonly GreenHarborApiContext _db;

    public UsersController(GreenHarborApiContext db)
    {
      _db = db;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<User>>> GetUsers()
    {
      return await _db.Users.ToListAsync();
    }

    [HttpPost]
    public async Task<ActionResult<User>> Post(User user)
    {
      _db.Users.Add(user);
      await _db.SaveChangesAsync();
      return CreatedAtAction(nameof(GetUsers), new { id = user.UserId }, user);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Put(int id, User user)
    {
      if (id != user.UserId)
      {
        return BadRequest();
      }
      
      _db.Users.Update(user);

      try
      {
        await _db.SaveChangesAsync();
      }
      catch (DbUpdateConcurrencyException)
      {
        if (!UserExists(id))
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
  
    private bool UserExists(int id)
    {
      return _db.Users.Any(e => e.UserId == id);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteUser(int id)
    {
      User user = await _db.Users.FindAsync(id);
      if (user == null)
      {
        return NotFound();
      }
      
      _db.Users.Remove(user);
      await _db.SaveChangesAsync();

      return NoContent();
    }
  }
}