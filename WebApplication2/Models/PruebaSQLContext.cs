using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication2.Models;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace WebApplication2.Models
{
    public partial class PruebaSQLContext : DbContext
    {
        public PruebaSQLContext()
        {
        }

        public PruebaSQLContext(DbContextOptions<PruebaSQLContext> options)
            : base(options)
        {
        }

        public virtual DbSet<AccidentesPa> AccidentesPa { get; set; }
        public virtual DbSet<BdAccidentes> BdAccidentes { get; set; }
        public virtual DbSet<BdBajasPt> BdBajasPt { get; set; }
        public virtual DbSet<BdBarredura> BdBarredura { get; set; }
        public virtual DbSet<BdCapUtilizada> BdCapUtilizada { get; set; }
        public virtual DbSet<BdCapacidadPorLinea> BdCapacidadPorLinea { get; set; }
        public virtual DbSet<BdCuadroBásico> BdCuadroBásico { get; set; }
        public virtual DbSet<BdDesperdiciosEmpaque> BdDesperdiciosEmpaque { get; set; }
        public virtual DbSet<BdDesperdiciosTotales> BdDesperdiciosTotales { get; set; }
        public virtual DbSet<BdEficacia> BdEficacia { get; set; }
        public virtual DbSet<BdEficaciaPorLinea> BdEficaciaPorLinea { get; set; }
        public virtual DbSet<BdEficiencia> BdEficiencia { get; set; }
        public virtual DbSet<BdIpfm> BdIpfm { get; set; }
        public virtual DbSet<BdMantenimientoCompletado> BdMantenimientoCompletado { get; set; }
        public virtual DbSet<BdPesoProducidoPesoPagado> BdPesoProducidoPesoPagado { get; set; }
        public virtual DbSet<BdProductividadLaboral> BdProductividadLaboral { get; set; }
        public virtual DbSet<BdQuejasA> BdQuejasA { get; set; }
        public virtual DbSet<BdQuejasB> BdQuejasB { get; set; }
        public virtual DbSet<BdQuejasC> BdQuejasC { get; set; }
        public virtual DbSet<BdQuejasTotales> BdQuejasTotales { get; set; }
        public virtual DbSet<BdTiempoExtra> BdTiempoExtra { get; set; }
        public virtual DbSet<BdToneladasProducidas> BdToneladasProducidas { get; set; }
        public virtual DbSet<BdValorDeLaProducción> BdValorDeLaProducción { get; set; }
        public virtual DbSet<BdVariaciónDeLaOrden> BdVariaciónDeLaOrden { get; set; }
        public virtual DbSet<EficaciaPa> EficaciaPa { get; set; }
        public virtual DbSet<EficasCritica> EficasCritica { get; set; }
        public virtual DbSet<EficasCriticasImag> EficasCriticasImag { get; set; }
        public virtual DbSet<Indicadores> Indicadores { get; set; }
        public virtual DbSet<TrDates> TrDates { get; set; }
        public virtual DbSet<TrMonths> TrMonths { get; set; }
        public virtual DbSet<TrQuarters> TrQuarters { get; set; }
        public virtual DbSet<TrWeek> TrWeek { get; set; }
        public virtual DbSet<TrWeeks> TrWeeks { get; set; }
        public virtual DbSet<TrYears> TrYears { get; set; }
        public virtual DbSet<Ubicacion> Ubicacion { get; set; }
        public virtual DbSet<ValorDeLaProducciónMmPa> ValorDeLaProducciónMmPa { get; set; }
        public virtual DbSet<VariaciónDeLaOrdenPa> VariaciónDeLaOrdenPa { get; set; }
        public virtual DbSet<Targets> Target { get; set; }
        public virtual DbSet<Mixmodel> Mixmodels { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("server=(localdb)\\Servidor; database = PruebaSQL; integrated security=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AccidentesPa>(entity =>
            {
                entity.HasKey("Id");

                entity.ToTable("AccidentesPA$");

                entity.Property(e => e.Avance).HasColumnName("%Avance");

                entity.Property(e => e.Causa).HasMaxLength(255);

                entity.Property(e => e.Descripción).HasMaxLength(255);

                entity.Property(e => e.FactorAMejorar)
                    .HasColumnName("Factor a Mejorar")
                    .HasMaxLength(255);

                entity.Property(e => e.FechaCompromiso)
                    .HasColumnName("Fecha compromiso")
                    .HasMaxLength(255);

                entity.Property(e => e.Quien).HasMaxLength(255);

                entity.Property(e => e.Region).HasMaxLength(255);

                entity.Property(e => e.Indicador).HasMaxLength(255);

                entity.Property(e => e.WeekPA).HasMaxLength(255);

            });
            modelBuilder.Entity<BdAccidentes>(entity =>
            {
                entity.HasKey("Id");

                entity.ToTable("'BD-Accidentes$'");

                entity.Property(e => e.Id).ValueGeneratedOnAdd();

                entity.Property(e => e.IdSem).HasColumnName("Id_sem");

                entity.Property(e => e.Indicador)
                    .HasColumnName("Indicador")
                    .HasMaxLength(255);

                entity.Property(e => e.NúmeroDeEventos).HasColumnName("Accidentes");

                entity.Property(e => e.Region).HasMaxLength(255);

                entity.Property(e => e.Week).HasMaxLength(255);
            });

            modelBuilder.Entity<BdBajasPt>(entity =>
            {
                entity.HasKey("Id");

                entity.ToTable("'BD-%Bajas PT$'");

                entity.Property(e => e.BajasPt).HasColumnName("%Bajas PT");

                entity.Property(e => e.Id).ValueGeneratedOnAdd();

                entity.Property(e => e.IdSem).HasColumnName("Id_sem");

                entity.Property(e => e.Indicador)
                    .HasMaxLength(255)
                    .IsFixedLength();

                entity.Property(e => e.Region).HasMaxLength(255);

                entity.Property(e => e.Week).HasMaxLength(255);
            });

            modelBuilder.Entity<BdBarredura>(entity =>
            {
                entity.HasKey("Id");

                entity.ToTable("'BD-%Barredura$'");

                entity.Property(e => e.Barredura).HasColumnName("%Barredura");

                entity.Property(e => e.Id).ValueGeneratedOnAdd();

                entity.Property(e => e.IdSem).HasColumnName("Id_sem");

                entity.Property(e => e.Indicador)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Region).HasMaxLength(255);

                entity.Property(e => e.Week).HasMaxLength(255);
            });

            modelBuilder.Entity<BdCapUtilizada>(entity =>
            {
                entity.HasKey("Id");

                entity.ToTable("'BD-Capacidad Utilizada$'");

                entity.Property(e => e.CapacidadUtilizada).HasColumnName("Capacidad Utilizada");

                entity.Property(e => e.Id).ValueGeneratedOnAdd();

                entity.Property(e => e.IdSem).HasColumnName("Id_sem");

                entity.Property(e => e.Indicador).HasMaxLength(255);

                entity.Property(e => e.Region).HasMaxLength(255);

                entity.Property(e => e.Week).HasMaxLength(255);
            });

            modelBuilder.Entity<BdCapacidadPorLinea>(entity =>
            {
                entity.HasKey("Id");

                entity.ToTable("'BD-Capacidad por linea$'");

                entity.Property(e => e.CapacidadPl).HasColumnName("Capacidad_pl");

                entity.Property(e => e.IdSem).HasColumnName("Id_sem");

                entity.Property(e => e.Línea).HasMaxLength(255);

                entity.Property(e => e.Region).HasMaxLength(255);

                entity.Property(e => e.Week).HasMaxLength(255);
            });

            modelBuilder.Entity<BdCuadroBásico>(entity =>
            {
                entity.HasKey("Id");

                entity.ToTable("'BD-Cuadro básico$'");

                entity.Property(e => e.CuadroBásico).HasColumnName("Cuadro básico");

                entity.Property(e => e.Id).ValueGeneratedOnAdd();

                entity.Property(e => e.IdSem).HasColumnName("Id_sem");

                entity.Property(e => e.Indicador).HasMaxLength(225);

                entity.Property(e => e.Region).HasMaxLength(255);

                entity.Property(e => e.Week).HasMaxLength(255);
            });

            modelBuilder.Entity<BdDesperdiciosEmpaque>(entity =>
            {
                entity.HasKey("Id");

                entity.ToTable("'BD-Desperdicios Empaque$'");

                entity.Property(e => e.DesperdiciosEmpaque).HasColumnName("Desperdicios Empaque");

                entity.Property(e => e.Id).ValueGeneratedOnAdd();

                entity.Property(e => e.IdSem).HasColumnName("Id_sem");

                entity.Property(e => e.Indicador).HasMaxLength(255);

                entity.Property(e => e.Region).HasMaxLength(255);

                entity.Property(e => e.Week).HasMaxLength(255);
            });

            modelBuilder.Entity<BdDesperdiciosTotales>(entity =>
            {
                entity.HasKey("Id");

                entity.ToTable("'BD-Desperdicios Totales$'");

                entity.Property(e => e.DesperdiciosTotales).HasColumnName("Desperdicios Totales");

                entity.Property(e => e.Id).ValueGeneratedOnAdd();

                entity.Property(e => e.IdSem).HasColumnName("Id_sem");

                entity.Property(e => e.Indicador).HasMaxLength(255);

                entity.Property(e => e.Region).HasMaxLength(255);

                entity.Property(e => e.Week).HasMaxLength(255);
            });

            modelBuilder.Entity<BdEficacia>(entity =>
            {
                entity.HasKey("Id");

                entity.ToTable("'BD-Eficacia$'");

                entity.Property(e => e.Id).ValueGeneratedOnAdd();

                entity.Property(e => e.IdSem).HasColumnName("Id_sem");

                entity.Property(e => e.Indicador).HasMaxLength(255);

                entity.Property(e => e.Region).HasMaxLength(255);

                entity.Property(e => e.Week).HasMaxLength(255);
            });

            modelBuilder.Entity<BdEficaciaPorLinea>(entity =>
            {
                entity.HasKey("Id");

                entity.ToTable("'BD-Eficacia por linea$'");

                entity.Property(e => e.EficaciaPl).HasColumnName("Eficacia_pl");

                entity.Property(e => e.IdSem).HasColumnName("Id_sem");

                entity.Property(e => e.Línea).HasMaxLength(255);

                entity.Property(e => e.Region).HasMaxLength(255);

                entity.Property(e => e.Week).HasMaxLength(255);
            });

            modelBuilder.Entity<BdIpfm>(entity =>
            {
                entity.HasKey("Id");

                entity.ToTable("'BD-%IPFM$'");

                entity.Property(e => e.Id).ValueGeneratedOnAdd();

                entity.Property(e => e.IdSem).HasColumnName("Id_sem");

                entity.Property(e => e.Indicador).HasMaxLength(255);

                entity.Property(e => e.Ipfm).HasColumnName("%IPFM");

                entity.Property(e => e.Region).HasMaxLength(255);

                entity.Property(e => e.Week).HasMaxLength(255);
            });

            modelBuilder.Entity<BdMantenimientoCompletado>(entity =>
            {
                entity.HasKey("Id");

                entity.ToTable("'BD-Mantenimiento Completado$'");

                entity.Property(e => e.Id).ValueGeneratedOnAdd();

                entity.Property(e => e.IdSem).HasColumnName("Id_sem");

                entity.Property(e => e.Indicador).HasMaxLength(255);

                entity.Property(e => e.MantenimientoCompletado).HasColumnName("Mantenimiento Completado");

                entity.Property(e => e.Region).HasMaxLength(255);

                entity.Property(e => e.Week).HasMaxLength(255);
            });

            modelBuilder.Entity<BdPesoProducidoPesoPagado>(entity =>
            {
                entity.HasKey("Id");

                entity.ToTable("'BD-Peso producido Peso pagado$'");

                entity.Property(e => e.Id).ValueGeneratedOnAdd();

                entity.Property(e => e.IdSem).HasColumnName("Id_sem");

                entity.Property(e => e.Indicador).HasMaxLength(255);

                entity.Property(e => e.PesoProducidoPesoPagado).HasColumnName("Peso producido Peso pagado");

                entity.Property(e => e.Region).HasMaxLength(255);

                entity.Property(e => e.Week).HasMaxLength(255);
            });

            modelBuilder.Entity<BdProductividadLaboral>(entity =>
            {
                entity.HasKey("Id");

                entity.ToTable("'BD-Productividad laboral$'");

                entity.Property(e => e.Id).ValueGeneratedOnAdd();

                entity.Property(e => e.IdSem).HasColumnName("Id_sem");

                entity.Property(e => e.Indicador).HasMaxLength(255);

                entity.Property(e => e.ProductividadLaboral).HasColumnName("Productividad Laboral");

                entity.Property(e => e.Region).HasMaxLength(255);

                entity.Property(e => e.Week).HasMaxLength(255);
            });

            modelBuilder.Entity<BdQuejasA>(entity =>
            {
                entity.HasKey("Id");

                entity.ToTable("'BD-Quejas A$'");

                entity.Property(e => e.Id).ValueGeneratedOnAdd();

                entity.Property(e => e.IdSem).HasColumnName("Id_sem");

                entity.Property(e => e.Indicador).HasMaxLength(255);

                entity.Property(e => e.QuejasA).HasColumnName("Quejas A");

                entity.Property(e => e.Region).HasMaxLength(255);

                entity.Property(e => e.Week).HasMaxLength(255);
            });

            modelBuilder.Entity<BdQuejasB>(entity =>
            {
                entity.HasKey("Id");

                entity.ToTable("'BD-Quejas B$'");

                entity.Property(e => e.Id).ValueGeneratedOnAdd();

                entity.Property(e => e.IdSem).HasColumnName("Id_sem");

                entity.Property(e => e.Indicador).HasMaxLength(255);

                entity.Property(e => e.QuejasB).HasColumnName("Quejas B");

                entity.Property(e => e.Region).HasMaxLength(255);

                entity.Property(e => e.Week).HasMaxLength(255);
            });

            modelBuilder.Entity<BdQuejasC>(entity =>
            {
                entity.HasKey("Id");

                entity.ToTable("'BD-Quejas C$'");

                entity.Property(e => e.Id).ValueGeneratedOnAdd();

                entity.Property(e => e.IdSem).HasColumnName("Id_sem");

                entity.Property(e => e.Indicador).HasMaxLength(255);

                entity.Property(e => e.QuejasC).HasColumnName("Quejas C");

                entity.Property(e => e.Region).HasMaxLength(255);

                entity.Property(e => e.Week).HasMaxLength(255);
            });

            modelBuilder.Entity<BdQuejasTotales>(entity =>
            {
                entity.HasKey("Id");

                entity.ToTable("'BD-Quejas Totales$'");

                entity.Property(e => e.Id).ValueGeneratedOnAdd();

                entity.Property(e => e.IdSem).HasColumnName("Id_sem");

                entity.Property(e => e.Indicador).HasMaxLength(255);

                entity.Property(e => e.QuejasTotales).HasColumnName("Quejas Totales");

                entity.Property(e => e.Region).HasMaxLength(255);

                entity.Property(e => e.Week).HasMaxLength(255);
            });


            modelBuilder.Entity<BdTiempoExtra>(entity =>
            {
                entity.HasKey("Id");

                entity.ToTable("'BD-Tiempo Extra$'");

                entity.Property(e => e.IdSem).HasColumnName("Id_sem");

                entity.Property(e => e.Region).HasMaxLength(255);

                entity.Property(e => e.TiempoExtra).HasColumnName("Tiempo extra");

                entity.Property(e => e.Week).HasMaxLength(255);
            });

            modelBuilder.Entity<BdToneladasProducidas>(entity =>
            {
                entity.HasKey("Id");

                entity.ToTable("'BD-Toneladas Producidas$'");

                entity.Property(e => e.Id).ValueGeneratedOnAdd();

                entity.Property(e => e.IdSem).HasColumnName("Id_sem");

                entity.Property(e => e.Indicador).HasMaxLength(255);

                entity.Property(e => e.Region).HasMaxLength(255);

                entity.Property(e => e.ToneladasProducidas).HasColumnName("Toneladas Producidas");

                entity.Property(e => e.Week).HasMaxLength(255);
            });

            modelBuilder.Entity<BdValorDeLaProducción>(entity =>
            {
                entity.HasKey("Id");

                entity.ToTable("'BD-Valor de la producción$'");

                entity.Property(e => e.Id).ValueGeneratedOnAdd();

                entity.Property(e => e.IdSem).HasColumnName("Id_sem");

                entity.Property(e => e.Indicador).HasMaxLength(255);

                entity.Property(e => e.Region).HasMaxLength(255);

                entity.Property(e => e.ValorDeLaProducción).HasColumnName("Valor de la producción");

                entity.Property(e => e.Week).HasMaxLength(255);
            });

            modelBuilder.Entity<BdVariaciónDeLaOrden>(entity =>
            {
                entity.HasKey("Id");

                entity.ToTable("'BD-Variación de la orden de la producción$'");

                entity.Property(e => e.Id).ValueGeneratedOnAdd();

                entity.Property(e => e.IdSem).HasColumnName("Id_sem");

                entity.Property(e => e.Indicador).HasMaxLength(255);

                entity.Property(e => e.Region).HasMaxLength(255);

                entity.Property(e => e.VariaciónDeLaOrdenDeLaProducción).HasColumnName("Variación de la orden de la producción");

                entity.Property(e => e.Week).HasMaxLength(255);
            });


            modelBuilder.Entity<EficasCritica>(entity =>
            {
                entity.HasKey("Id");
                entity.ToTable("Eficas_Critica");
            });

            modelBuilder.Entity<EficasCriticasImag>(entity =>
            {
                entity.HasKey("Id");
                entity.ToTable("Eficas_CriticasImag");

                entity.HasIndex(e => e.EficaciasCriticasId);

                entity.Property(e => e.EficaciasCriticasId).HasColumnName("Eficacias_CriticasId");

                entity.Property(e => e.ImgaeUrl).HasColumnName("ImgaeURL");

                entity.HasOne(d => d.EficaciasCriticas)
                    .WithMany(p => p.EficasCriticasImag)
                    .HasForeignKey(d => d.EficaciasCriticasId);
            });

            modelBuilder.Entity<Indicadores>(entity =>
            {
                entity.HasKey("Id");

                entity.ToTable("Indicadores$");

                entity.Property(e => e.Area).HasMaxLength(255);

                entity.Property(e => e.Indicador).HasMaxLength(255);

                entity.Property(e => e.Referencia).HasMaxLength(255);
            });
    
            modelBuilder.Entity<TrDates>(entity =>
            {
                entity.HasKey("Id");

                entity.ToTable("'TR-Dates$'");

                entity.HasOne(e => e.trweeks)
                      .WithOne(e => e.trdates);
                      

                entity.Property(e => e.Id).HasColumnName("Id");

                entity.Property(e => e.DayNum).HasColumnName("Day Num");

                entity.Property(e => e.DíaJuliano).HasColumnName("Día Juliano");

                entity.Property(e => e.Fecha).HasMaxLength(255);

                entity.Property(e => e.LoteSimplificado)
                    .HasColumnName("Lote Simplificado")
                    .HasMaxLength(255);

                entity.Property(e => e.Week).HasMaxLength(255);

                entity.Property(e => e.Weekday).HasMaxLength(255);
            });

            modelBuilder.Entity<TrMonths>(entity =>
            {
                entity.HasKey("Month");

                entity.ToTable("'TR-Months$'");

                entity.HasMany(m => m.Targets)
                .WithOne(t => t.trmonths) ;

                entity.HasOne(e => e.trweek)
                .WithOne(e => e.trmonths);

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Month).HasMaxLength(255);

                entity.Property(e => e.Quarter).HasMaxLength(255);
            });

            modelBuilder.Entity<TrQuarters>(entity =>
            {
                entity.HasKey("Quarter");

                entity.ToTable("'TR-Quarters$'");

                entity.Property(e => e.Quarter).HasMaxLength(255);

                entity.Property(e => e.Year).HasMaxLength(255);
            });

            modelBuilder.Entity<TrWeek>(entity =>
            {              
                entity.HasKey("Week");

                entity.ToTable("'TR-Week$'");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Week).HasMaxLength(255);

                entity.Property(e => e.Year).HasMaxLength(255);
            });

            modelBuilder.Entity<TrWeeks>(entity =>
            {
                entity.HasKey("Week");

                entity.ToTable("'TR-Weeks$'");

                entity.HasOne(e => e.trmonths)
                .WithOne(e => e.trweek)
                .HasForeignKey<TrWeeks>(e => e.Month);

                entity.HasOne(e => e.trdates)
                .WithOne(e => e.trweeks)
                .HasForeignKey<TrDates>(e => e.Week);
                

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.IdWeek).HasColumnName("ID_WEEK");

                entity.Property(e => e.Month).HasMaxLength(255);

                entity.Property(e => e.Week).HasMaxLength(255);
            });

            modelBuilder.Entity<TrYears>(entity =>
            {
                entity.HasKey("Year");

                entity.ToTable("'TR-Years$'");

                entity.Property(e => e.Year).HasMaxLength(255);
            });

            modelBuilder.Entity<Ubicacion>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("Ubicacion$");

                entity.Property(e => e.Id).HasMaxLength(255);

                entity.Property(e => e.Region).HasMaxLength(255);
            });

            modelBuilder.Entity<Targets>(entity =>
            {
                entity.HasKey("Id");
                entity.ToTable("Targets$");

                entity.HasOne(e => e.trmonths)
                .WithMany(e => e.Targets)
                .HasForeignKey(e => e.Month);

                entity.Property(e => e.Id).ValueGeneratedOnAdd();

                entity.Property(e => e.Month).HasMaxLength(255);

                entity.Property(e => e.Region).HasMaxLength(255);

                entity.Property(e => e.Indicador).HasMaxLength(255);

                entity.Property(e => e.Value).HasColumnName("Value");

            });


            modelBuilder.Entity<Mixmodel>(entity =>
            {
                entity.HasNoKey();

            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);

        public DbSet<WebApplication2.Models.BdAccidente> BdAccidente { get; set; }
    }
}
