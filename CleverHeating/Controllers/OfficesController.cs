using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CleverHeating.Models;

namespace CleverHeating.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OfficesController : ControllerBase
    {
        private readonly ApplicationContext _context;

        public OfficesController(ApplicationContext context)
        {
            _context = context;
        }

        // GET: api/Offices
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Office>>> GetOffice()
        {
            return await _context.Office.ToListAsync();
        }

        // GET: api/Offices/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Office>> GetOffice(int id)
        {
            var office = await _context.Office.FindAsync(id);

            if (office == null)
            {
                return NotFound();
            }

            return office;
        }

        // PUT: api/Offices/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutOffice(int id, Office office)
        {
            if (id != office.Id)
            {
                return BadRequest();
            }

            _context.Entry(office).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!OfficeExists(id))
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

        // POST: api/Offices
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Office>> PostOffice(Office office)
        {
            _context.Office.Add(office);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetOffice", new { id = office.Id }, office);
        }

        // DELETE: api/Offices/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteOffice(int id)
        {
            var office = await _context.Office.FindAsync(id);
            if (office == null)
            {
                return NotFound();
            }

            _context.Office.Remove(office);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool OfficeExists(int id)
        {
            return _context.Office.Any(e => e.Id == id);
        }
    }
}
