using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CleverHeating.Models;
using Microsoft.AspNetCore.Hosting;
using System.IO;

namespace CleverHeating.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OfficesController : ControllerBase
    {
        private readonly ApplicationContext _context;
        private readonly IWebHostEnvironment _env;

        public OfficesController(ApplicationContext context, IWebHostEnvironment env)
        {
            _context = context;
            _env = env;
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

        [HttpGet("GetOfficeRooms/{id}")]
        public async Task<ActionResult<Office>> GetOfficeRooms(int id)
        {
            var office = await _context.Office.FindAsync(id);

            if (office == null)
            {
                return NotFound();
            }
            List<Room> rooms = await _context.Room.Where(r => r.OfficeId == id).ToListAsync();
            return new ObjectResult(rooms);
        }

        // PUT: api/Offices/5
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

        [HttpPost("/Offices/SaveFile/{id}")]
        public async Task<IActionResult> SaveFile(int id)
        {
            try
            {
                Office office = await _context.Office.FirstOrDefaultAsync(cp => cp.Id == id);
                var httpRequest = Request.Form;
                var postedFile = httpRequest.Files[0];
                string filename = postedFile.FileName;
                string newFileName = $"{office.Id}_{office.Name}.png";
                var physicalPath = _env.ContentRootPath + "/Photos/Company/" + newFileName;

                using (var stream = new FileStream(physicalPath, FileMode.Create))
                {
                    await postedFile.CopyToAsync(stream);
                }
                office.PhotoFileName = newFileName;
                _context.Entry(office).State = EntityState.Modified;
                _context.Office.Update(office);
                await _context.SaveChangesAsync();

                return new JsonResult(newFileName);
            }
            catch
            {
                return new JsonResult("default_company_image.png");
            }
        }
    }
}
