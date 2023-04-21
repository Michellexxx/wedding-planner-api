using Microsoft.AspNetCore.Mvc;

namespace wedding_planner.Controllers;
using wedding_planner.Models;

[ApiController]
[Route("[controller]")]
public class GuestController : ControllerBase
{
    private readonly ApiDbContext _dbContext;

    private readonly ILogger<GuestController> _logger;

    public GuestController(ApiDbContext dbContext, ILogger<GuestController> logger)
    {
        _logger = logger;
        _dbContext = dbContext;
    }

    [HttpGet(Name = "GetGuest")]
    public IEnumerable<Guest> Get()
    {
        return _dbContext.Guest.ToArray();
    }

    [HttpGet]
    [Route("get-guest-by-id")]
    public async Task<IActionResult> GetStudentByIdAsync(int id)
    {
        var student = await _dbContext.Guest.FindAsync(id);
        return Ok(student);
    }

    [HttpPost(Name = "PostGuest")]
    public async Task<IActionResult> Post(Guest guest)
    {
        _dbContext.Guest.Add(guest);
        await _dbContext.SaveChangesAsync();
        return Created($"/get-guest-by-id?id={guest.Id}", guest);

    }

    [HttpPut]
    public async Task<IActionResult> PutAsync(Guest guest)
    {
        _dbContext.Guest.Update(guest);
        await _dbContext.SaveChangesAsync();
        return NoContent();
    }


    [HttpDelete(Name = "DeleteGuest")]
    public async Task<IActionResult> Delete(int id)
    {
        
        var guestToDelete = await _dbContext.Guest.FindAsync(id);
        if (guestToDelete == null)
        {
            
            return NotFound();
        }
        else
        {
            
            _dbContext.Guest.Remove(guestToDelete);
            await _dbContext.SaveChangesAsync();
            return NoContent();
        }
        

    }


}

