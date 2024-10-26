// Models/Category.cs
using CapacitaDigitalApi.Enums;
using System.ComponentModel.DataAnnotations.Schema;

namespace CapacitaDigitalApi.Models;
public class Module
{
    public int Id { get; set; } // Id do modulo  
    public string Title { get; set; } // Nome do modulo
    public string? Description { get; set; } // Descrição do modulo  
    public ModuleNivel Nivel { get; set; } // Nivel do modulo
    public ModuleStatus Status { get; set; } // Status do modulo
    public int CategoryId { get; set; }  // Pro    /// dade para a chave estrangeira da categoria que contém o modulo

}

