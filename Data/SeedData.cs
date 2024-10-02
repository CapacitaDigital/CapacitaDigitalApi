using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;

using CapacitaDigitalApi.Models;
using CapacitaDigitalApi.Enums;

namespace CapacitaDigitalApi.Data;
public static class SeedData
{
    public static void Initialize(IServiceProvider serviceProvider)
    {
        using (var context = new AppDbContext(
            serviceProvider.GetRequiredService<DbContextOptions<AppDbContext>>()))
        {
            // Verifica se já existem dados no banco
            if (context.Users.Any() && context.Categories.Any())
            {
                return;   // DB já foi semeado
            }

            // Adiciona dados de exemplo para usuários
            context.Users.AddRange(
                new User
                {
                    Name = "Admin",
                    Email = "admin@example.com",
                    UserType = UserType.Admin,
                    Password = "password"
                },
                new User
                {
                    Name = "Teacher1",
                    Email = "teacher@example.com",
                    UserType = UserType.Teacher,
                    Password = "password"
                },
                new User
                {
                    Name = "Teacher2",
                    Email = "teacher2@example.com",
                    UserType = UserType.Teacher,
                    Password = "password"
                },
                new User
                {
                    Name = "Teacher3",
                    Email = "teacher3@example.com",
                    UserType = UserType.Teacher,
                    Password = "password"
                },
                new User
                {
                    Name = "Student",
                    Email = "student@example.com",
                    UserType = UserType.Student,
                    Password = "password"
                }
            );

            context.SaveChanges();

            // Obtenha um UserId válido
            var userId = context.Users.First().Id;

            // Adiciona dados de exemplo para categorias
            context.Categories.AddRange(
                new Category
                {
                    Name = "Português",
                    Description = "Categoria de português para ensino fundamental 1 e 2",
                    Status = CategoryStatus.Active,
                    UserId = userId,
                    UrlImage = "/images/default.jpeg"
                },
                new Category
                {
                    Name = "Matemática",
                    Description = "Categoria de Matemática para ensino fundamental 1 e 2",
                    Status = CategoryStatus.Active,
                    UserId = userId, // Adiciona UserId válido
                    UrlImage = "/images/default.jpeg"
                },
                new Category
                {
                    Name = "Tecnologia",
                    Description = "Categoria de Tecnologia",
                    Status = CategoryStatus.Active,
                    UserId = userId, // Adiciona UserId válido
                    UrlImage = "/images/default.jpeg"
                }
            );

            context.SaveChanges();
        }
    }
}