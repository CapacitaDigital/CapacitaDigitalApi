// Models/Category.cs

namespace CapacitaDigitalApi.Models;
public class Category
{
    public int Id { get; set; } // Id da categoria  
    public required string Name { get; set; } // Nome da categoria
    public required string Description { get; set; } // Descrição da categoria  
    public required string Status { get; set; } // Pode ser uma string ou um enum, dependendo do seu caso de uso
    public int UserId { get; set; }  // Propriedade para a chave estrangeira do usuário que gere a categoria
    
   }
