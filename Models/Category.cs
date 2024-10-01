// Models/Category.cs
using CapacitaDigitalApi.Enums;
using System.ComponentModel.DataAnnotations.Schema; // Adicione esta linha
namespace CapacitaDigitalApi.Models;
public class Category
{
    public int Id { get; set; } // Id da categoria  
    public required string Name { get; set; } // Nome da categoria
    public required string Description { get; set; } // Descrição da categoria  
    public string UrlImage { get; set; } // URL da imagem da categoria  
    public required CategoryStatus Status { get; set; } // Status da categoria
    public int UserId { get; set; }  // Propriedade para a chave estrangeira do usuário que gere a categoria                  
    [NotMapped]
    public IFormFile? Image { get; set; }// Propriedade para receber o arquivo de imagem

}
