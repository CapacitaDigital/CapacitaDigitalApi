// Models/Category.cs
using CapacitaDigitalApi.Enums;
using System.ComponentModel.DataAnnotations.Schema;

namespace CapacitaDigitalApi.Models;
public class Category
{
    public int Id { get; set; } // Id da categoria  
    public string Name { get; set; } // Nome da categoria
    public string? Description { get; set; } // Descrição da categoria  
    public string? UrlImage { get; set; } // URL da imagem da categoria  
    public CategoryStatus Status { get; set; } // Status da categoria
    public int UserId { get; set; }  // Propriedade para a chave estrangeira do usuário que gere a categoria                  

    [NotMapped]
    private IFormFile? Image { get; set; }// Propriedade para receber o arquivo de imagem

    // Método para definir a imagem
    public void SetImage(IFormFile? image)
    {
        Image = image;
    }

    // Método para acessar a imagem
    public IFormFile? GetImage()
    {
        return Image;
    }
}

