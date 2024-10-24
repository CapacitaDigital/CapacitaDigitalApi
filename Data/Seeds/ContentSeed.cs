using CapacitaDigitalApi.Models;
using CapacitaDigitalApi.Enums;
public static class ContentSeed
{
    public static void Seed(AppDbContext context)
    {
        if (context.Contents.Any())
        {
            context.Contents.RemoveRange(context.Contents);
            context.SaveChanges();
        }
        var existingModule = context.Modules.OrderBy(i => i.Id).FirstOrDefault();

        context.Contents.AddRange(
            new Content
            {
                Title = "Recursos",
                Description = "Aqui estão todos os recursos deste módulo disponibilizados pelo professor da disciplina",
                Type = ContentType.Assets,
                UrlImage = "/images/assets.jpeg",
                UrlVideo = "https://youtu.be/SEXGH4mG4is?si=E30RYMfxpUODFDYa",
                UrlsDocuments = new List<string>
                {
                    "/documents/vogais.pdf",
                    "/documents/consoantes.pdf",
                    "/documents/alfabeto.pdf",
                    "/documents/alfabeto.json",
                },
                ActivityData = "{\"alfabeto\": [\"A\", \"B\", \"C\", \"D\", \"E\"],\"urlSounds\": [\"/sounds/\"]}",
                ModuleId = existingModule.Id
            },
            new Content
            {
                Title = "Vogais",
                Description = "Aprenda as vogais do alfabeto",
                Type = ContentType.ClassRoom,
                UrlImage = "/images/vogais.jpeg",
                UrlVideo = "https://youtu.be/SEXGH4mG4is?si=E30RYMfxpUODFDYa",
                UrlsDocuments = new List<string>
                {
                    "/documents/vogais.pdf",
                    "/documents/vogais.json"
                },
                ActivityData = "{\"vogais\": [\"A\", \"E\", \"I\", \"O\", \"U\"],\"urlSounds\": [\"/sounds/\"]}",
                ModuleId = existingModule.Id
            },
            new Content
            {
                Title = "Consoantes",
                Description = "Aprenda as consoantes do alfabeto",
                Type = ContentType.ClassRoom,
                UrlImage = "/images/consoantes.jpeg",
                UrlVideo = "https://youtu.be/SEXGH4mG4is?si=E30RYMfxpUODFDYa",
                UrlsDocuments = new List<string>
                {
                    "/documents/consoantes.pdf",
                    "/documents/consoantes.json"
                },
                ActivityData = "{\"consoantes\": [\"B\", \"C\", \"D\", \"F\", \"G\"],\"urlSounds\": [\"/sounds/\"]}",
                ModuleId = existingModule.Id
            }
        );

        context.SaveChanges();
    }
}
