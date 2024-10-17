using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using WebApplicationDolgozat.ApplicationDBContext;

[Authorize]
[Route("api/[controller]")]
[ApiController]
public class RoomController : ControllerBase
{
    private readonly ApplicationDbContext _context;

    public RoomController(ApplicationDbContext context)
    {
        _context = context;
    }

    [Authorize]
    [HttpPost("Add-Room")]
    public async Task<IActionResult> AddRoom([FromBody] Room room)
    {
        var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
        room.UserId = userId; 

        _context.Rooms.Add(room);
        await _context.SaveChangesAsync();
        return CreatedAtAction(nameof(GetRoomById), new { id = room.Id }, room);
    }

    [Authorize]
    [HttpGet("get-all")]
    public async Task<IActionResult> GetRooms()
    {
        var rooms = await _context.Rooms.ToListAsync();
        return Ok(rooms);
    }

    [HttpGet("get/{id}")]
    public async Task<IActionResult> GetRoomById(int id)
    {
        var room = await _context.Rooms.FindAsync(id);

        if (room == null)
        {
            return NotFound("Nincs ilyen terem"); 
        }

        return Ok(room);
    }

    [HttpPut("put/{id}")]
    public async Task<IActionResult> UpdateRoom(int id, [FromBody] Room updatedRoom)
    {
        var room = await _context.Rooms.FindAsync(id);

        if (room == null)
        {
            return NotFound("A terem nem található"); 
        }

        room.Name = updatedRoom.Name;
        room.Capacity = updatedRoom.Capacity;

        await _context.SaveChangesAsync();
        return Ok("Sikeres a frissítés"); 
    }

    [HttpDelete("delete/{id}")]
    public async Task<IActionResult> DeleteRoom(int id)
    {
        var room = await _context.Rooms.FindAsync(id);

        if (room == null)
        {
            return NotFound(); 
        }

        _context.Rooms.Remove(room);
        await _context.SaveChangesAsync();
        return Ok("Sikeres a törlés");
    }
}
