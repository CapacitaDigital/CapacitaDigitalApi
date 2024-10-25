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
            _targetFilePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot"); // Define o caminho onde os arquivos serão salvos no servidor (wwwroot/images)
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

        [HttpGet("modules/{id}")]
        public async Task<ActionResult<IEnumerable<Module>>> GetCategories(int id)
        {
            var contents = await _context.Contents.Where(m => m.ModuleId == id).ToListAsync();

            if (!contents.Any())
            {
                 Console.WriteLine("Não encontrado");
            }

            return Ok(contents);
        }

        // POST: api/contents/upload
        [HttpPost("upload")]
        public async Task<IActionResult> UploadFile(IFormFile file)
        {
            if (file == null || file.Length == 0)
            {
                return BadRequest("Nenhum arquivo foi enviado.");
            }


            // Garante que apenas o nome do arquivo seja usado
            var fileName = Path.GetFileName(file.FileName); // Obtem o nome do arquivo == file.FileName
            var fileExtension = Path.GetExtension(file.FileName); // Obtem a extensão do arquivo == .pdf ou .jpg
            var filePath = string.Empty; // Inicializa a variável filePath

            // VERIFICA SE O ARQUIVO É PERMITIDO PARA UPLOAD (APENAS .pdf .json .txt .jpg .png .jpeg)
            if (fileExtension != ".pdf" && fileExtension != ".txt" && fileExtension != ".json" && fileExtension != ".jpg" && fileExtension != ".png" && fileExtension != ".jpeg" && fileExtension != ".mp3" && fileExtension != ".wav")
            {
                return BadRequest("Apenas arquivos .pdf .json .txt .jpg .png .jpeg e .mp3 são permitidos.");
            }
            // Cria o caminho do arquivo com base na extensão do arquivo
            else if (fileExtension == ".pdf" || fileExtension == ".json" || fileExtension == ".txt")
            {
                filePath = Path.Combine(_targetFilePath, "documents", fileName);
            }
            else if (fileExtension == ".jpg" || fileExtension == ".png" || fileExtension == ".jpeg")
            {
                filePath = Path.Combine(_targetFilePath, "images", fileName);
            }
            else if (fileExtension == ".mp3" || fileExtension == ".wav")
            {
                filePath = Path.Combine(_targetFilePath, "sounds", fileName);
            }

            using (var stream = new FileStream(filePath, FileMode.Create)) // Cria um arquivo no caminho especificado e abre o arquivo para escrita 
            {
                await file.CopyToAsync(stream); // Copia o conteúdo do arquivo para o stream
            }


            return Ok(new { filePath }); // Retorna o caminho do arquivo salvo
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
                return BadRequest("O ID do conteúdo não corresponde ao ID fornecido.");
            }

            _context.Entry(content).State = EntityState.Modified; // Define o estado da entidade como modificado
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ContentExists(id))
                {
                    return NotFound("O conteúdo não foi encontrado.");
                }
                else
                {
                    throw;
                }
            }

            return Ok("O conteúdo foi atualizado com sucesso.");
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

            return Ok("O conteúdo foi deletado com sucesso!");
        }

        private bool ContentExists(int id)
        {
            return _context.Contents.Any(e => e.Id == id);
        }
    }
}