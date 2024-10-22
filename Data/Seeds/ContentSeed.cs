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
                Title = "Vogais",
                Description = "Aprenda as vogais do alfabeto",
                Type = ContentType.ClassRoom,
                UrlImage = "/images/default.jpeg",
                UrlVideo = "https://youtu.be/SEXGH4mG4is?si=E30RYMfxpUODFDYa",
                UrlsDocuments = new List<string>
                {
                    "/documents/vogais1.pdf",
                    "/documents/vogais2.pdf"
                },
                ActivityData = "{\"vogais\": [\"A\", \"E\", \"I\", \"O\", \"U\"],\"audios\": [\"/sounds/a.mp3\", \"/sounds/e.mp3\", \"/sounds/i.mp3\", \"/sounds/o.mp3\", \"/sounds/u.mp3\"]}",
                ModuleId = existingModule.Id
            },
            new Content
            {
                Title = "Consoantes",
                Description = "Aprenda as consoantes do alfabeto",
                Type = ContentType.ClassRoom,
                UrlImage = "/images/default.jpeg",
                UrlVideo = "https://youtu.be/SEXGH4mG4is?si=E30RYMfxpUODFDYa",
                UrlsDocuments = new List<string>
                {
                    "/documents/consoantes1.pdf",
                    "/documents/consoantes2.pdf"
                },
                ActivityData = "{\"consoantes\": [\"B\", \"C\", \"D\", \"F\", \"G\"],\"audios\": [\"/sounds/b.mp3\", \"/sounds/c.mp3\", \"/sounds/d.mp3\", \"/sounds/f.mp3\", \"/sounds/g.mp3\"]}",
                ModuleId = existingModule.Id
            }
        );

        context.SaveChanges();
    }
}
