// Models/Category.cs
using CapacitaDigitalApi.Enums;
using System.ComponentModel.DataAnnotations.Schema;

namespace CapacitaDigitalApi.Models;
public class Category
{
    public int Id { get; set; } 
    public string Name { get; set; } 
    public string? Description { get; set; } 
    public string? UrlImage { get; set; } 
    public CategoryStatus Status { get; set; } 
    public int UserId { get; set; }                    

    [NotMapped]
    private IFormFile? Image { get; set; }

    public void SetImage(IFormFile? image)
    {
        Image = image;
    }

    public IFormFile? GetImage()
    {
        return Image;
    }
}

