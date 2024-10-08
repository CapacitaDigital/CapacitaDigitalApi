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

        context.Contents.AddRange(
            new Content
            {
                Title = "Vogais",
                Description = "Aprenda as vogais do alfabeto",
                Type = ContentType.ClassRoom,
                UrlImage = "/images/content/default.jpeg",
                UrlVideo = "https://youtu.be/SEXGH4mG4is?si=E30RYMfxpUODFDYa",
                UrlsDocuments = new List<string>
                {
                    "/documents/vogais1.pdf",
                    "/documents/vogais2.pdf"
                },
                ActivityData = "{\"vogais\": [\"A\", \"E\", \"I\", \"O\", \"U\"],\"audios\": [\"/sounds/a.mp3\", \"/sounds/e.mp3\", \"/sounds/i.mp3\", \"/sounds/o.mp3\", \"/sounds/u.mp3\"]}",
                ModuleId = 1
            }
        );

        context.SaveChanges();
    }
}