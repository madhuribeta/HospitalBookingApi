using Microsoft.AspNetCore.Mvc;
using HospitalBookingApi.Models;
using HospitalBookingApi.Data;
using Microsoft.EntityFrameworkCore;

namespace HospitalBookingApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class DoctorsController : ControllerBase
{
    private readonly AppDbContext _context;

    public DoctorsController(AppDbContext context)
    {
        _context = context;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Doctor>>> GetAll()
    {
        return await _context.Doctors.ToListAsync();
    }

    [HttpGet("clinic/{clinicId}")]
    public async Task<ActionResult<IEnumerable<Doctor>>> GetByClinic(int clinicId)
    {
        return await _context.Doctors
            .Where(d => d.ClinicId == clinicId)
            .ToListAsync();
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Doctor>> GetById(int id)
    {
        var doctor = await _context.Doctors.FindAsync(id);
        if (doctor == null) return NotFound();
        return doctor;
    }
}