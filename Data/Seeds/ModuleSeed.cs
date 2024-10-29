using CapacitaDigitalApi.Models;
using CapacitaDigitalApi.Enums;
public static class ModuleSeed
{
    public static void Seed(AppDbContext context)
    {
        // // Verifica se já existem dados no banco
        // if (context.Modules.Any())
        // {
        //     context.Modules.RemoveRange(context.Modules);
        //     context.SaveChanges();
        // }
        // Adiciona dados de exemplo para categorias
        var existingCategory = context.Categories.OrderBy(i => i.Id).FirstOrDefault();
        if (existingCategory != null)
        {
            // Adiciona dados de exemplo para módulos
            context.Modules.AddRange(
                new Module
                {
                    Title = "Conhecendo as letras",
                    Description = "Conheca as letras do alfabeto, vogais e consoantes.",
                    Nivel = ModuleNivel.Easy,
                    Status = ModuleStatus.Active,
                    CategoryId = existingCategory.Id,
                }
            );

            context.SaveChanges();
        }


    }
}