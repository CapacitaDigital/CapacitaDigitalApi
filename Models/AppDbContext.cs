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
        modelBuilder.Entity<Category>()
            .HasOne<User>() // Define que a entidade Category tem um relacionamento com uma entidade User
            .WithMany() // Indica que a entidade User pode ter muitas Categories
            .HasForeignKey(c => c.UserId); // Define a propriedade UserId como a chave estrangeira
    }

}
