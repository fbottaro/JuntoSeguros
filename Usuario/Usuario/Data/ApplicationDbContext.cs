using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Usuario.Domain;

namespace Usuario.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public IConfiguration Configuration { get; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options, IConfiguration configuration)
            : base(options)
        {
            Configuration = configuration;
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var configurationSection = Configuration.GetSection("ConnectionStrings:DefaultConnection");
            optionsBuilder.UseSqlServer(configurationSection.Value);
        }
    }
}