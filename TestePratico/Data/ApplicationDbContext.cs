using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using TestePratico.Models;
using TestePratico.Models.AccountViewModels;

namespace TestePratico.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        //Representa a coleção de todas as entidades no contexto.
        public DbSet<Training> Trainings { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder) => base.OnModelCreating(modelBuilder);

        public DbSet<TestePratico.Models.AccountViewModels.RegisterViewModel> RegisterViewModel { get; set; }

    }
}
