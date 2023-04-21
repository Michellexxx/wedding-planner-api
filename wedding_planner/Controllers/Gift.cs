using Microsoft.AspNetCore.Mvc;

namespace wedding_planner.Controllers;
using wedding_planner.Models;

[ApiController]
[Route("[controller]")]
public class GiftController : ControllerBase
{
    private readonly ApiDbContext _dbContext;

    private readonly ILogger<GiftController> _logger;

    public GiftController(ApiDbContext dbContext, ILogger<GiftController> logger)
    {
        _logger = logger;
        _dbContext = dbContext;
    }

    [HttpGet(Name = "GetGift")]
    public IEnumerable<Gift> Get()
    {
        return _dbContext.Gift.ToArray();
    }

    [HttpGet]
    [Route("get-gift-by-id")]
    public async Task<IActionResult> GetStudentByIdAsync(int id)
    {
        var student = await _dbContext.Gift.FindAsync(id);
        return Ok(student);
    }

    [HttpPost(Name = "PostGift")]
    public async Task<IActionResult> Post(Gift Gift)
    {
        _dbContext.Gift.Add(Gift);
        await _dbContext.SaveChangesAsync();
        return Created($"/get-gift-by-id?id={Gift.Id}", Gift);

    }

    [HttpPut]
    public async Task<IActionResult> PutAsync(Gift gift)
    {
        _dbContext.Gift.Update(gift);
        await _dbContext.SaveChangesAsync();
        return NoContent();
    }


    [HttpDelete(Name = "DeleteGift")]
    public async Task<IActionResult> Delete(int id)
    {

        var GiftToDelete = await _dbContext.Gift.FindAsync(id);
        if (GiftToDelete == null)
        {

            return NotFound();
        }
        else
        {

            _dbContext.Gift.Remove(GiftToDelete);
            await _dbContext.SaveChangesAsync();
            return NoContent();
        }

    }


}

