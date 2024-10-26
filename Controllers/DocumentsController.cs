using System;
using System.Collections.Generic;
using System.IO;
using Microsoft.AspNetCore.Mvc;

namespace CapacitaDigitalApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DocumentsController : ControllerBase
    {
        private readonly string _DocumentsPath;

        public DocumentsController()
        {
            _DocumentsPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "documents");
        }

        [HttpGet]
        public IActionResult GetDocuments()
        {
            if (!Directory.Exists(_DocumentsPath))
            {
                return NotFound("O diretório de documentos não foi encontrado.");
            }

            var documentsFiles = Directory.GetFiles(_DocumentsPath);
            var documentUrls = new List<string>();

            foreach (var documentsFile in documentsFiles)
            {
                var fileName = Path.GetFileName(documentsFile);
                var documentUrl = $"/Documents/{fileName}";
                documentUrls.Add(documentUrl);
            }

            return Ok(documentUrls);
        }
    }
}