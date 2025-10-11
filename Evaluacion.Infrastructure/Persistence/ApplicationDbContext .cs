using Evaluacion.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace Evaluacion.Infrastructure.Persistence
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options) { }

        // Example DbSets
        public DbSet<Cliente> Users => Set<Cliente>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Cliente>(
                e =>
                {
                    e.ToTable("cliente");
                    e.HasKey(x => x.Id);
                    e.Property(x => x.Id)
                     .ValueGeneratedOnAdd()
                     .HasDefaultValueSql("SEQ_CLIENTE.NEXTVAL");

                    e.Property(x => x.Ruc).HasMaxLength(11).IsRequired();
                    e.Property(x => x.RazonSocial).HasMaxLength(200).IsRequired();
                    e.Property(x => x.Telefono).HasMaxLength(20);
                    e.Property(x => x.Correo).HasMaxLength(100);
                    //e.Property(x => x.FechaRegistro).HasColumnType("DATE");
                });

            // Fluent API mappings here
        }
    }
}
