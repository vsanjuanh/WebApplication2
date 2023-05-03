using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication2.Models;


namespace WebApplication2.Models
{
    public partial class autenticacionContext : DbContext
    {
        public autenticacionContext()
        {
        }

        public autenticacionContext(DbContextOptions<autenticacionContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Users> users { get; set; }
        public virtual DbSet<ROL> roles { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("server=(localdb)\\Servidor; database = autenticacion; integrated security=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<Users>(entity =>
            {
                entity.HasKey("Id");

                entity.ToTable("Users");

                entity.Property(e => e.Id).HasMaxLength(255);

                entity.Property(e => e.Nombre).HasColumnName("Nombre");

                entity.Property(e => e.Usuario).HasColumnName("Usuario");

                entity.Property(e => e.Clave).HasColumnName("Clave");

                entity.Property(e => e.IdRol).HasMaxLength(255);

                entity.Property(e => e.Region).HasMaxLength(255);
            });

            modelBuilder.Entity<ROL>(entity =>
            {
                entity.HasKey("IdRol");
                entity.ToTable("ROL");


                entity.Property(e => e.IdRol).HasMaxLength(255);

                entity.Property(e => e.Descripcion).HasColumnName("Descripcion");

            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
