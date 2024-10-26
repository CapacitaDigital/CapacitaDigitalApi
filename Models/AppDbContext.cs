using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking; // Adicione esta linha

namespace CapacitaDigitalApi.Models
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<User> Users { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Module> Modules { get; set; }
        public DbSet<Content> Contents { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var stringListComparer = new ValueComparer<List<string>>(
            (c1, c2) => c1.SequenceEqual(c2),
            c => c.Aggregate(0, (a, v) => HashCode.Combine(a, v.GetHashCode())),
            c => c.ToList()
        );

            modelBuilder.Entity<Category>() // Configuração da entidade Category
               .HasOne<User>() // Relacionamento de um para muitos com a entidade User
               .WithMany() // Um usuário pode ter várias categorias
               .HasForeignKey(c => c.UserId) // Chave estrangeira para a entidade User
               .OnDelete(DeleteBehavior.Cascade); // Ação de exclusão em cascata

            base.OnModelCreating(modelBuilder); // Chamada ao método da classe base

            modelBuilder.Entity<Content>(entity =>
             {
                 entity.HasKey(e => e.Id);
                 entity.Property(e => e.Title).IsRequired().HasMaxLength(200);
                 entity.Property(e => e.Description).HasMaxLength(1000);
                 entity.Property(e => e.Type).IsRequired().HasMaxLength(50);
                 entity.Property(e => e.UrlImage).HasMaxLength(500);
                 entity.Property(e => e.UrlVideo).HasMaxLength(500);
                 entity.Property(e => e.ModuleId).IsRequired();
                 entity.Property(e => e.ActivityData).HasColumnType("nvarchar(max)");

                 entity.HasOne<Module>()
                       .WithMany()
                       .HasForeignKey(e => e.ModuleId);

                 entity.Property(e => e.UrlsDocuments)
                       .HasConversion(
                           v => string.Join(',', v),
                           v => v.Split(',', StringSplitOptions.RemoveEmptyEntries).ToList()
                       )
                       .Metadata.SetValueComparer(stringListComparer);
             });
            // CONFIGURAÇÃO DA ENTIDADE MODULE
            modelBuilder.Entity<Module>(entity =>
            {
                entity.HasKey(e => e.Id); // Chave primária
                entity.Property(e => e.Title).IsRequired().HasMaxLength(200); // Propriedade Title
                entity.Property(e => e.Description).HasMaxLength(1000); // Propriedade Description
            });
        }

    }
}