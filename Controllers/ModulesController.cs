using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore; 
using CapacitaDigitalApi.Models;

namespace CapacitaDigitalApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class Modules(AppDbContext context) : ControllerBase
    {

        private readonly AppDbContext _context = context;

        [HttpGet] 
        public async Task<ActionResult<IEnumerable<Module>>> GetModules()
        {
            return await _context.Modules.ToListAsync();
        }

        [HttpGet("{id}")] 
        public async Task<ActionResult<Module>> GetModule(int id)
        {
            var module = await _context.Modules.FindAsync(id);
            if (module == null)
            {
                return NotFound();
            }
            return module;
        }

        [HttpGet("categories/{id}")]
        public async Task<ActionResult<IEnumerable<Module>>> GetCategories(int id)
        {
            var modules = await _context.Modules.Where(m => m.CategoryId == id).ToListAsync();

            if (!modules.Any())
    {
                 Console.WriteLine("Não pegou");
            }

            return Ok(modules);
        }

        [HttpPost] 
        public async Task<ActionResult<Module>> PostModule([FromBody] Module module)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Modules.Add(module);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetModule), new { id = module.Id }, module);
        }

        [HttpPut("{id}")] 
        public async Task<IActionResult> PutModule(int id, Module module)
        {
            if (id != module.Id)
            {
                return BadRequest();
            }

            _context.Entry(module).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return NoContent();
        }

        [HttpDelete("{id}")] 
        public async Task<IActionResult> DeleteModule(int id)
        {
            var module = await _context.Modules.FindAsync(id);
            if (module == null)
            {
                return NotFound();
            }

            _context.Modules.Remove(module);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }

}