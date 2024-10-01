// Models/AppDbContext.cs
using Microsoft.EntityFrameworkCore;

namespace CapacitaDigitalApi.Models;
public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options)
    {
    }

    public DbSet<Category> Categories { get; set; } // Incluindo o DbSet para Category
    public DbSet<User> Users { get; set; } // Incluindo o DbSet para User

    /* Aqui você pode adicionar outras entidades que deseja mapear para o banco de dados */
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        // Configuração do relacionamento entre User e Category
        modelBuilder.Entity<Category>()
            .HasOne(c => c.User)
            .WithMany(u => u.Categories)
            .HasForeignKey(c => c.UserId)
            .OnDelete(DeleteBehavior.Cascade); // Opcional: define o comportamento de exclusão
    }

}
