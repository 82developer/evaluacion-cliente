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
        public DbSet<Cliente> Clientes => Set<Cliente>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Cliente>(
                e =>
                {
                    e.ToTable("CLIENTE");
                    e.HasKey(x => x.Id);
                    e.Property(x => x.Id)
                     .HasColumnName("ID")
                     .ValueGeneratedOnAdd();
                     //.HasDefaultValueSql("SEQ_CLIENTE.NEXTVAL");

                    e.Property(x => x.Ruc).HasColumnName("RUC").HasMaxLength(11).IsRequired();
                    e.Property(x => x.RazonSocial).HasColumnName("RAZON_SOCIAL").HasMaxLength(200).IsRequired();
                    e.Property(x => x.TelefonoContacto).HasColumnName("TELEFONO_CONTACTO").HasMaxLength(20);
                    e.Property(x => x.CorreoContacto).HasColumnName("CORREO_CONTACTO").HasMaxLength(100);
                    e.Property(x => x.Direccion).HasColumnName("DIRECCION").HasMaxLength(200);
                    //e.Property(x => x.FechaRegistro).HasColumnType("DATE");
                });
        }
    }
}
