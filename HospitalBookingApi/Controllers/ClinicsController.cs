using Microsoft.AspNetCore.Mvc;
using HospitalBookingApi.Models;
using HospitalBookingApi.Data;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HospitalBookingApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ClinicsController : ControllerBase
    {
        private readonly AppDbContext _context;

        public ClinicsController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Clinic>>> GetAll()
        {
            return await _context.Clinics.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Clinic>> GetById(int id)
        {
            var clinic = await _context.Clinics.FindAsync(id);
            if (clinic == null) return NotFound();
            return clinic;
        }
    }
}
