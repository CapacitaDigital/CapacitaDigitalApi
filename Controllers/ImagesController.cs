using System;
using System.Collections.Generic;
using System.IO;
using Microsoft.AspNetCore.Mvc;

namespace CapacitaDigitalApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ImagesController : ControllerBase
    {
        private readonly string _imagesPath;

        public ImagesController()
        {
            _imagesPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "images");
        }

        [HttpGet]
        public IActionResult GetImages()
        {
            if (!Directory.Exists(_imagesPath))
            {
                return NotFound("O diretório de imagens não foi encontrado.");
            }

            var imageFiles = Directory.GetFiles(_imagesPath);
            var imageUrls = new List<string>();

            foreach (var imageFile in imageFiles)
            {
                var fileName = Path.GetFileName(imageFile);
                var imageUrl = $"/images/{fileName}";
                imageUrls.Add(imageUrl);
            }

            return Ok(imageUrls);
        }
    }
}