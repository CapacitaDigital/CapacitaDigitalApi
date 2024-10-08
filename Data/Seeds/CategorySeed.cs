using CapacitaDigitalApi.Models;
using CapacitaDigitalApi.Enums;
public static class CategorySeed
{
    public static void Seed(AppDbContext context)
    {
        // Verifica se já existem dados no banco
        if (context.Categories.Any())
        {
            context.Categories.RemoveRange(context.Categories);
            context.SaveChanges();
        }

        // Adiciona dados de exemplo para categorias
        context.Categories.AddRange(
            new Category
            {
                Name = "Português",
                Description = "Categoria de português para ensino fundamental 1 e 2",
                Status = CategoryStatus.Active,
                UserId = 1,
                UrlImage = "/images/default.jpeg"
            }
        );

        context.SaveChanges();
    }
}