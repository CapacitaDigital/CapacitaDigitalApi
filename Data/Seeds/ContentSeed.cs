using CapacitaDigitalApi.Models;
using CapacitaDigitalApi.Enums;
public static class ContentSeed
{
    public static void Seed(AppDbContext context)
    {
        // if (context.Contents.Any())
        // {
        //     context.Contents.RemoveRange(context.Contents);
        //     context.SaveChanges();
        // }
        var existingModule = context.Modules.OrderBy(i => i.Id).FirstOrDefault();

        context.Contents.AddRange(
            new Content
            {
                Title = "Recursos",
                Description = "Aqui estão todos os recursos deste módulo disponibilizados pelo professor da disciplina",
                Type = ContentType.Assets,
                UrlImage = "/images/alfabeto.jpeg",
                UrlVideo = "https://www.youtube.com/embed/MY9KP4m35Tc?si=Gk0qqeXdtvZkjTQD",
                UrlsDocuments = new List<string>
                {
                    "/documents/vogais.pdf",
                    "/documents/consoantes.pdf",
                    "/documents/alfabeto.pdf",
                    "/documents/alfabeto.json",
                },
                ActivityData = "{\"alfabeto\": [\"A\", \"B\", \"C\", \"D\", \"E\", \"F\", \"G\", \"H\", \"I\", \"J\", \"K\", \"L\", \"M\", \"N\", \"O\", \"P\", \"Q\", \"R\", \"S\", \"T\", \"U\", \"V\", \"W\", \"X\", \"Y\", \"Z\"],\"urlSounds\": [\"/sounds/\"]}",
                ModuleId = existingModule.Id
            },
            new Content
            {
                Title = "Vogais",
                Description = "Aprenda as vogais do alfabeto",
                Type = ContentType.ClassRoom,
                UrlImage = "/images/vogais.jpeg",
                UrlVideo = "https://www.youtube.com/embed/MY9KP4m35Tc?si=Gk0qqeXdtvZkjTQD",
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
                UrlImage = "/images/alfabeto.jpeg",
                UrlVideo = "https://www.youtube.com/embed/MY9KP4m35Tc?si=Gk0qqeXdtvZkjTQD",
                UrlsDocuments = new List<string>
                {
                    "/documents/consoantes.pdf",
                    "/documents/consoantes.json"
                },
                ActivityData = "{\"consoantes\": [\"B\", \"C\", \"D\", \"F\", \"G\", \"H\",  \"J\", \"K\", \"L\", \"M\", \"N\", \"P\", \"Q\", \"R\", \"S\", \"T\", \"V\", \"W\", \"X\", \"Y\", \"Z\"],\"urlSounds\": [\"/sounds/\"]}",
                ModuleId = existingModule.Id
            },
            new Content
            {
                Title = "Atividade Consoantes",
                Description = "pratique com os conhecimentos em que você adiquirio a cerca das consoantes do alfabeto",
                Type = ContentType.Exercise,
                UrlImage = "/images/alfabeto.jpeg",
                UrlVideo = "https://www.youtube.com/embed/MY9KP4m35Tc?si=Gk0qqeXdtvZkjTQD",
                UrlsDocuments = new List<string>
                {
                    "/documents/consoantes.pdf",
                    "/documents/consoantes.json"
                },
                ActivityData = "{\"consoantes\": [\"B\", \"C\", \"D\", \"F\", \"G\", \"H\",  \"J\", \"K\", \"L\", \"M\", \"N\", \"P\", \"Q\", \"R\", \"S\", \"T\", \"V\", \"W\", \"X\", \"Y\", \"Z\"],\"urlSounds\": [\"/sounds/\"]}",
                ModuleId = existingModule.Id
            },
            new Content
            {
                Title = "Atividade Vogais",
                Description = "pratique com os conhecimentos em que você adiquirio a cerca das Vogais do alfabeto",
                Type = ContentType.Exercise,
                UrlImage = "/images/vogais.jpeg",
                UrlVideo = "https://www.youtube.com/embed/MY9KP4m35Tc?si=Gk0qqeXdtvZkjTQD",
                UrlsDocuments = new List<string>
                {
                    "/documents/vogais.pdf",
                    "/documents/vogais.json"
                },
                ActivityData = "{\"vogais\": [\"A\", \"E\", \"I\", \"O\", \"U\"],\"urlSounds\": [\"/sounds/\"]}",
                ModuleId = existingModule.Id
            }
        );

        context.SaveChanges();
    }
}
