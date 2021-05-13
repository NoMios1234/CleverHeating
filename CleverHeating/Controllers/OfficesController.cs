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

        [Route("SaveFile")]
        [HttpPost]
        public JsonResult SaveFile()
        {
            try
            {
                var httpRequest = Request.Form;
                var postedFile = httpRequest.Files[0];
                string filename = postedFile.FileName;
                var physicalPath = _env.ContentRootPath + "/Photos/Office/" + filename;

                using (var stream = new FileStream(physicalPath, FileMode.Create))
                {
                    postedFile.CopyTo(stream);
                }

                return new JsonResult(filename);
            }
            catch (Exception)
            {
                return new JsonResult("default_office_image.png");
            }
        }
    }
}