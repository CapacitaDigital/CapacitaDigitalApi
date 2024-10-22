using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CapacitaDigitalApi.Models;

namespace CapacitaDigitalApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ContentsController : ControllerBase
    {
        private readonly AppDbContext _context;
        private readonly string _targetFilePath;

        public ContentsController(AppDbContext context)
        {
            _context = context;
            _targetFilePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "images"); // Define o caminho onde os arquivos serão salvos no servidor (wwwroot/images)
            if (!Directory.Exists(_targetFilePath))
            {
                Directory.CreateDirectory(_targetFilePath);
            }
        }

        // GET: api/Contents
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Content>>> GetContents()
        {
            return await _context.Contents.ToListAsync();
        }

        // GET: api/Contents/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Content>> GetContent(int id)
        {
            var content = await _context.Contents.FindAsync(id);

            if (content == null)
            {
                return NotFound();
            }

            return content;
        }

        // POST: api/Contents/upload
        [HttpPost("upload")]
        public async Task<IActionResult> UploadFile(IFormFile file)
        {
            if (file == null || file.Length == 0)
            {
                return BadRequest("Nenhum arquivo foi enviado.");
            }

            // Garante que apenas o nome do arquivo seja usado
            var fileName = Path.GetFileName(file.FileName);
            var filePath = Path.Combine(_targetFilePath, fileName);

            using (var stream = new FileStream(filePath, FileMode.Create))
            {
                await file.CopyToAsync(stream);
            }


            return Ok(new { filePath });
        }

        // POST: api/Contents
        [HttpPost]
        public async Task<ActionResult<Content>> PostContent(Content content)
        {
            try
            {
                _context.Contents.Add(content);
                await _context.SaveChangesAsync();

                return CreatedAtAction("GetContent", new { id = content.Id }, content);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // PUT: api/Contents/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutContent(int id, Content content)
        {
            if (id != content.Id)
            {
                return BadRequest();
            }

            _context.Entry(content).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ContentExists(id))
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

        // DELETE: api/Contents/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteContent(int id)
        {
            var content = await _context.Contents.FindAsync(id);
            if (content == null)
            {
                return NotFound();
            }

            _context.Contents.Remove(content);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ContentExists(int id)
        {
            return _context.Contents.Any(e => e.Id == id);
        }
    }
}