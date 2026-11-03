using Microsoft.AspNetCore.Mvc;
using HospitalBookingApi.Models;
using HospitalBookingApi.Data;
using Microsoft.EntityFrameworkCore;

namespace HospitalBookingApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AppointmentSlotsController : ControllerBase
{
    private readonly AppDbContext _context;

    public AppointmentSlotsController(AppDbContext context)
    {
        _context = context;
    }

    [HttpGet("doctor/{doctorId}")]
    public async Task<ActionResult<IEnumerable<AppointmentSlot>>> GetByDoctor(int doctorId)
    {
        return await _context.AppointmentSlots
            .Where(s => s.DoctorId == doctorId)
            .OrderBy(s => s.StartTime)
            .ToListAsync();
    }

    [HttpPost("book/{slotId}")]
    public async Task<IActionResult> BookSlot(int slotId, [FromBody] int userId)
    {
        var slot = await _context.AppointmentSlots.FindAsync(slotId);
        if (slot == null) return NotFound("Slot not found.");
        if (slot.IsBooked) return BadRequest("Slot is already booked.");

        slot.IsBooked = true;
        slot.BookedByUserId = userId;

        await _context.SaveChangesAsync();
        return NoContent();
    }
}
