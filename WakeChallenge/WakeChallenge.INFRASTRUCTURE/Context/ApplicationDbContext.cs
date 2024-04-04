using Microsoft.EntityFrameworkCore;
using WakeChallenge.CORE.Entities;

namespace WakeChallenge.INFRASTRUCTURE.Context
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(ApplicationDbContext).Assembly);

            // Criar dados iniciais
            modelBuilder.Entity<Product>().HasData(
                new Product(1, "Refrigerante X", 100, 10.90M),
                new Product(2, "Bolo de cenoura", 5, 25.99M),
                new Product(3, "Leite condensado", 23, 7.60M),
                new Product(4, "Creme de leite", 45, 3.25M),
                new Product(5, "Barra de chocolate", 111, 10.33M)
            );
        }

        public DbSet<Product> Products { get; set; }
    }
}

