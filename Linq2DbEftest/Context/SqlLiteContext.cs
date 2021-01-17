using Linq2DbEftest.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace Linq2DbEftest.Context
{
    public class SqlLiteContext : DbContext
    {
        protected readonly IConfiguration Configuration;
        public SqlLiteContext(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlite(Configuration.GetConnectionString("localdb"), b => b.MigrationsAssembly("Linq2DbEftest"));
            }
        }
        public virtual DbSet<Client> Clients { get; set; }
        public virtual DbSet<Contact> Contacts { get; set; }
        public virtual DbSet<Order> Orders { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Client>(entity =>
            {
                entity.ToTable("Clients")
                    .HasKey(e => new { e.ClientId })
                    .HasName("PK_Clients");

                entity.Property(e => e.ClientId)
                    .ValueGeneratedOnAdd();
                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnType("nvarchar(50)");
            });

            modelBuilder.Entity<Contact>(entity =>
            {
                entity.ToTable("Contacts")
                    .HasKey(e => new { e.ContactId })
                    .HasName("PK_Contacts");

                entity.Property(e => e.ContactId)
                    .ValueGeneratedOnAdd();
                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnType("nvarchar(50)");
            });

            modelBuilder.Entity<Order>(entity =>
            {
                entity.ToTable("Orders")
                    .HasKey(e => new { e.OrderId })
                    .HasName("PK_Contacts");

                entity.Property(e => e.OrderId)
                    .ValueGeneratedOnAdd();
                entity.Property(e => e.Description)
                    .IsRequired()
                    .HasColumnType("nvarchar(50)");
            });


        }
    }
}
