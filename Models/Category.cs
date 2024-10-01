// Models/Category.cs
using CapacitaDigitalApi.Enums;
namespace CapacitaDigitalApi.Models;
public class Category
{
    public int Id { get; set; } // Id da categoria  
    public required string Name { get; set; } // Nome da categoria
    public required string Description { get; set; } // Descrição da categoria  
    public required CategoryStatus Status { get; set; } // Status da categoria
    public required int UserId { get; set; }  // Propriedade para a chave estrangeira do usuário que gere a categoria

    // Propriedade de navegação para o usuário  
    public User User { get; set; }
}
