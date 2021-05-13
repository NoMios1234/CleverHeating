﻿using System;
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
    public class StatisticsController : ControllerBase
    {
        private readonly ApplicationContext _context;

        public StatisticsController(ApplicationContext context)
        {
            _context = context;
        }

        // GET: api/Statistics
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Statistic>>> GetStatistic()
        {
            return await _context.Statistic.ToListAsync();
        }

        // GET: api/Statistics/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Statistic>> GetStatistic(int id)
        {
            var statistic = await _context.Statistic.FindAsync(id);

            if (statistic == null)
            {
                return NotFound();
            }

            return statistic;
        }

        // PUT: api/Statistics/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutStatistic(int id, Statistic statistic)
        {
            if (id != statistic.Id)
            {
                return BadRequest();
            }

            _context.Entry(statistic).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!StatisticExists(id))
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

        // POST: api/Statistics
        [HttpPost]
        public async Task<ActionResult<Statistic>> PostStatistic(Statistic statistic)
        {
            _context.Statistic.Add(statistic);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetStatistic", new { id = statistic.Id }, statistic);
        }

        // DELETE: api/Statistics/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteStatistic(int id)
        {
            var statistic = await _context.Statistic.FindAsync(id);
            if (statistic == null)
            {
                return NotFound();
            }

            _context.Statistic.Remove(statistic);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool StatisticExists(int id)
        {
            return _context.Statistic.Any(e => e.Id == id);
        }
    }
}
