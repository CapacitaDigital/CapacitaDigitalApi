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
    

}
