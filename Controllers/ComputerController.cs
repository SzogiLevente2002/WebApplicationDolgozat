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
public class ComputerController : ControllerBase
{
    private readonly ApplicationDbContext _context;

    public ComputerController(ApplicationDbContext context)
    {
        _context = context;
    }


    [Authorize]
    [HttpPost("Add-computer")]
    public async Task<IActionResult> AddComputer([FromBody] Computer computer)
    {
        var roomId = await _context.Computers.FirstOrDefaultAsync();
        //computer.RoomId = RoomId;

        _context.Computers.Add(computer);
        await _context.SaveChangesAsync();
        return CreatedAtAction(nameof(GetComputerById), new { id = computer.Id }, computer);
    }

    [HttpGet("get-all")]
    public async Task<IActionResult> GetComputers()
    {
        var computers = await _context.Computers.ToListAsync();
        return Ok(computers);
    }

    [HttpGet("get/{id}")]
    public async Task<IActionResult> GetComputerById(int id)
    {
        var computer = await _context.Computers.FindAsync(id);

        if (computer == null)
        {
            return NotFound("A számítógép nem található"); 
        }

        return Ok(computer);
    }

    [HttpPut("put/{id}")]
    public async Task<IActionResult> UpdateComputer(int id, [FromBody] Computer updatedComputer)
    {
        var computer = await _context.Computers.FindAsync(id);

        if (computer == null)
        {
            return NotFound("A számítógép nem található"); 
        }

        computer.Model = updatedComputer.Model;
        computer.ManufacturedDate = updatedComputer.ManufacturedDate; 

        await _context.SaveChangesAsync();
        return Ok("Sikeres a frissítés"); 
    }

    
    [HttpDelete("delete/{id}")]
    public async Task<IActionResult> DeleteComputer(int id)
    {
        var computer = await _context.Computers.FindAsync(id);

        if (computer == null)
        {
            return NotFound(); 
        }

        _context.Computers.Remove(computer);
        await _context.SaveChangesAsync();
        return Ok("Sikeres a törlés"); 
    }
}
