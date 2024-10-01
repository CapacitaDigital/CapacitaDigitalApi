// Models/User.cs

using CapacitaDigitalApi.Enums;

namespace CapacitaDigitalApi.Models;
public class User
{
    public int Id { get; set; }
    public required string Name { get; set; }
    public required string Email { get; set; }
    // Propriedade para o tipo de usuário
    public required UserType UserType { get; set; }
    // Propriedade de navegação para as categorias gerenciadas pelo usuário
    public ICollection<Category> Categories { get; set; }

}
