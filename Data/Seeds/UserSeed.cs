
using CapacitaDigitalApi.Models;
using CapacitaDigitalApi.Enums;
public static class UserSeed
{
    public static void Seed(AppDbContext context)
    {
        // if (context.Users.Any())
        // {
        //     context.Users.RemoveRange(context.Users);
        //     context.SaveChanges();
        // }

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
                Name = "User",
                Email = "user@example.com",
                UserType = UserType.Student,
                Password = "password"
            },
            new User
            {
                Name = "Teacher",
                Email = "teacher@example.com",
                UserType = UserType.Teacher,
                Password = "password"
            }
        );

        context.SaveChanges();
    }
}