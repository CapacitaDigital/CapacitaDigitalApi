using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;
using CapacitaDigitalApi.Models;
using CapacitaDigitalApi.Enums;
using CapacitaDigitalApi.Data;

namespace CapacitaDigitalApi.Data;
public static class SeedData
{
    public static void Initialize(IServiceProvider serviceProvider)
    {
        using (var context = new AppDbContext(
            serviceProvider.GetRequiredService<DbContextOptions<AppDbContext>>()))
        {
            UserSeed.Seed(context);
            CategorySeed.Seed(context);
            ModuleSeed.Seed(context);
            ContentSeed.Seed(context);
        }
    }
}