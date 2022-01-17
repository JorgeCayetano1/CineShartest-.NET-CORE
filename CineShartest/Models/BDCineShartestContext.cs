using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace CineShartest.Models
{
    public partial class BDCineShartestContext : DbContext
    {
        public BDCineShartestContext()
        {
        }

        public BDCineShartestContext(DbContextOptions<BDCineShartestContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Asiento> Asientos { get; set; }
        public virtual DbSet<AsientoCliente> AsientoClientes { get; set; }
        public virtual DbSet<Cartelera> Carteleras { get; set; }
        public virtual DbSet<Cine> Cines { get; set; }
        public virtual DbSet<Ciudad> Ciudads { get; set; }
        public virtual DbSet<Cliente> Clientes { get; set; }
        public virtual DbSet<DetalleVentum> DetalleVenta { get; set; }
        public virtual DbSet<Dulcerium> Dulceria { get; set; }
        public virtual DbSet<Empleado> Empleados { get; set; }
        public virtual DbSet<Estado> Estados { get; set; }
        public virtual DbSet<Formato> Formatos { get; set; }
        public virtual DbSet<Genero> Generos { get; set; }
        public virtual DbSet<Pelicula> Peliculas { get; set; }
        public virtual DbSet<Producto> Productos { get; set; }
        public virtual DbSet<RegistroAsiento> RegistroAsientos { get; set; }
        public virtual DbSet<Sala> Salas { get; set; }
        public virtual DbSet<Ticket> Tickets { get; set; }
        public virtual DbSet<Ventum> Venta { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Data source=LAPTOP-RGEESPUT; Initial Catalog=BDCineShartest; user id=sa; password=123456;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "Modern_Spanish_CI_AS");

            modelBuilder.Entity<Asiento>(entity =>
            {
                entity.ToTable("ASIENTO");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.CodEst).HasColumnName("COD_EST");

                entity.Property(e => e.IdAsie)
                    .HasMaxLength(7)
                    .IsUnicode(false)
                    .HasColumnName("ID_ASIE")
                    .HasComputedColumnSql("('SEA-'+right('000'+CONVERT([varchar],[ID]),(3)))", false);

                entity.Property(e => e.IdSala).HasColumnName("ID_SALA");

                entity.Property(e => e.NrAsie).HasColumnName("NR_ASIE");

                entity.HasOne(d => d.CodEstNavigation)
                    .WithMany(p => p.Asientos)
                    .HasForeignKey(d => d.CodEst)
                    .HasConstraintName("FK__ASIENTO__COD_EST__4222D4EF");

                entity.HasOne(d => d.IdSalaNavigation)
                    .WithMany(p => p.AsientosNavigation)
                    .HasForeignKey(d => d.IdSala)
                    .HasConstraintName("FK_SALA");
            });

            modelBuilder.Entity<AsientoCliente>(entity =>
            {
                entity.HasKey(e => e.CodAcli)
                    .HasName("PK__ASIENTO___6A34E085EEFB66CD");

                entity.ToTable("ASIENTO_CLIENTE");

                entity.Property(e => e.CodAcli).HasColumnName("COD_ACLI");

                entity.Property(e => e.IdAsie).HasColumnName("ID_ASIE");

                entity.Property(e => e.IdCli).HasColumnName("ID_CLI");

                entity.HasOne(d => d.IdAsieNavigation)
                    .WithMany(p => p.AsientoClientes)
                    .HasForeignKey(d => d.IdAsie)
                    .HasConstraintName("FK__ASIENTO_C__ID_AS__44FF419A");

                entity.HasOne(d => d.IdCliNavigation)
                    .WithMany(p => p.AsientoClientes)
                    .HasForeignKey(d => d.IdCli)
                    .HasConstraintName("FK__ASIENTO_C__ID_CL__45F365D3");
            });

            modelBuilder.Entity<Cartelera>(entity =>
            {
                entity.ToTable("CARTELERA");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.CodEst).HasColumnName("COD_EST");

                entity.Property(e => e.Fecha)
                    .HasColumnType("date")
                    .HasColumnName("FECHA");

                entity.Property(e => e.HoraFin)
                    .HasColumnType("time(0)")
                    .HasColumnName("HORA_FIN");

                entity.Property(e => e.HoraIni)
                    .HasColumnType("time(0)")
                    .HasColumnName("HORA_INI");

                entity.Property(e => e.IdCartelera)
                    .HasMaxLength(5)
                    .IsUnicode(false)
                    .HasColumnName("ID_CARTELERA")
                    .HasComputedColumnSql("('CA'+right('000'+CONVERT([varchar],[ID]),(3)))", false);

                entity.Property(e => e.IdPeli).HasColumnName("ID_PELI");

                entity.Property(e => e.IdSala).HasColumnName("ID_SALA");

                entity.HasOne(d => d.CodEstNavigation)
                    .WithMany(p => p.Carteleras)
                    .HasForeignKey(d => d.CodEst)
                    .HasConstraintName("FK__CARTELERA__COD_E__4AB81AF0");

                entity.HasOne(d => d.IdPeliNavigation)
                    .WithMany(p => p.Carteleras)
                    .HasForeignKey(d => d.IdPeli)
                    .HasConstraintName("FK__CARTELERA__ID_PE__48CFD27E");

                entity.HasOne(d => d.IdSalaNavigation)
                    .WithMany(p => p.Carteleras)
                    .HasForeignKey(d => d.IdSala)
                    .HasConstraintName("FK__CARTELERA__ID_SA__49C3F6B7");
            });

            modelBuilder.Entity<Cine>(entity =>
            {
                entity.ToTable("CINE");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.CodCiudad).HasColumnName("COD_CIUDAD");

                entity.Property(e => e.DirCine)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("DIR_CINE");

                entity.Property(e => e.IdCine)
                    .HasMaxLength(5)
                    .IsUnicode(false)
                    .HasColumnName("ID_CINE")
                    .HasComputedColumnSql("('CS'+right('000'+CONVERT([varchar],[ID]),(3)))", false);

                entity.Property(e => e.NomEmp)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("NOM_EMP");

                entity.HasOne(d => d.CodCiudadNavigation)
                    .WithMany(p => p.Cines)
                    .HasForeignKey(d => d.CodCiudad)
                    .HasConstraintName("FK__CINE__COD_CIUDAD__35BCFE0A");
            });

            modelBuilder.Entity<Ciudad>(entity =>
            {
                entity.HasKey(e => e.CodCiudad)
                    .HasName("PK__CIUDAD__363420CE2C9F682F");

                entity.ToTable("CIUDAD");

                entity.Property(e => e.CodCiudad).HasColumnName("COD_CIUDAD");

                entity.Property(e => e.NomCiudad)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("NOM_CIUDAD");
            });

            modelBuilder.Entity<Cliente>(entity =>
            {
                entity.ToTable("CLIENTE");

                entity.Property(e => e.ID).HasColumnName("ID");

                entity.Property(e => e.APE_CLI)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("APE_CLI");

                entity.Property(e => e.DNI)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasColumnName("DNI")
                    .IsFixedLength(true);

                entity.Property(e => e.ID_CLI)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasColumnName("ID_CLI")
                    .HasComputedColumnSql("('CL'+right('000000'+CONVERT([varchar],[ID]),(6)))", false);

                entity.Property(e => e.NOM_CLI)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("NOM_CLI");
            });

            modelBuilder.Entity<DetalleVentum>(entity =>
            {
                entity.ToTable("DETALLE_VENTA");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.CantDventa).HasColumnName("CANT_DVENTA");

                entity.Property(e => e.DescripDventa)
                    .HasMaxLength(60)
                    .IsUnicode(false)
                    .HasColumnName("DESCRIP_DVENTA");

                entity.Property(e => e.IdDventa)
                    .HasMaxLength(9)
                    .IsUnicode(false)
                    .HasColumnName("ID_DVENTA")
                    .HasComputedColumnSql("('DVT'+right('000000'+CONVERT([varchar],[ID]),(6)))", false);

                entity.Property(e => e.IdVenta).HasColumnName("ID_VENTA");

                entity.Property(e => e.PrecioDventa)
                    .HasColumnType("decimal(9, 2)")
                    .HasColumnName("PRECIO_DVENTA");

                entity.HasOne(d => d.IdVentaNavigation)
                    .WithMany(p => p.DetalleVenta)
                    .HasForeignKey(d => d.IdVenta)
                    .HasConstraintName("FK__DETALLE_V__ID_VE__571DF1D5");
            });

            modelBuilder.Entity<Dulcerium>(entity =>
            {
                entity.ToTable("DULCERIA");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.IdCine).HasColumnName("ID_CINE");

                entity.Property(e => e.IdDulc)
                    .HasMaxLength(5)
                    .IsUnicode(false)
                    .HasColumnName("ID_DULC")
                    .HasComputedColumnSql("('DC'+right('000'+CONVERT([varchar],[ID]),(3)))", false);

                entity.Property(e => e.IdEmp).HasColumnName("ID_EMP");

                entity.Property(e => e.IdProd).HasColumnName("ID_PROD");

                entity.Property(e => e.NomDulc)
                    .HasMaxLength(60)
                    .IsUnicode(false)
                    .HasColumnName("NOM_DULC");

                entity.HasOne(d => d.IdCineNavigation)
                    .WithMany(p => p.Dulceria)
                    .HasForeignKey(d => d.IdCine)
                    .HasConstraintName("FK__DULCERIA__ID_CIN__5AEE82B9");

                entity.HasOne(d => d.IdEmpNavigation)
                    .WithMany(p => p.Dulceria)
                    .HasForeignKey(d => d.IdEmp)
                    .HasConstraintName("FK__DULCERIA__ID_EMP__59FA5E80");

                entity.HasOne(d => d.IdProdNavigation)
                    .WithMany(p => p.Dulceria)
                    .HasForeignKey(d => d.IdProd)
                    .HasConstraintName("FK__DULCERIA__ID_PRO__5BE2A6F2");
            });

            modelBuilder.Entity<Empleado>(entity =>
            {
                entity.ToTable("EMPLEADO");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.ApeEmp)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("APE_EMP");

                entity.Property(e => e.CargEmp)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("CARG_EMP");

                entity.Property(e => e.CodEst).HasColumnName("COD_EST");

                entity.Property(e => e.IdEmp)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasColumnName("ID_EMP")
                    .HasComputedColumnSql("('EMP'+right('00000'+CONVERT([varchar],[ID]),(5)))", false);

                entity.Property(e => e.NomEmp)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("NOM_EMP");

                entity.Property(e => e.SuelEmp)
                    .HasColumnType("decimal(9, 2)")
                    .HasColumnName("SUEL_EMP");

                entity.HasOne(d => d.CodEstNavigation)
                    .WithMany(p => p.Empleados)
                    .HasForeignKey(d => d.CodEst)
                    .HasConstraintName("FK__EMPLEADO__COD_ES__32E0915F");
            });

            modelBuilder.Entity<Estado>(entity =>
            {
                entity.HasKey(e => e.CodEst)
                    .HasName("PK__ESTADO__2B63F2A299062B86");

                entity.ToTable("ESTADO");

                entity.Property(e => e.CodEst).HasColumnName("COD_EST");

                entity.Property(e => e.DescripEst)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasColumnName("DESCRIP_EST")
                    .IsFixedLength(true);
            });

            modelBuilder.Entity<Formato>(entity =>
            {
                entity.ToTable("FORMATO");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.DescripForma)
                    .HasMaxLength(90)
                    .IsUnicode(false)
                    .HasColumnName("DESCRIP_FORMA");

                entity.Property(e => e.IdForma)
                    .HasMaxLength(3)
                    .IsUnicode(false)
                    .HasColumnName("ID_FORMA")
                    .HasComputedColumnSql("('F'+right('00'+CONVERT([varchar],[ID]),(2)))", false);

                entity.Property(e => e.NomForma)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("NOM_FORMA");
            });

            modelBuilder.Entity<Genero>(entity =>
            {
                entity.HasKey(e => e.CodGene)
                    .HasName("PK__GENERO__5E47F664EBF76AC2");

                entity.ToTable("GENERO");

                entity.Property(e => e.CodGene).HasColumnName("COD_GENE");

                entity.Property(e => e.NomGene)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("NOM_GENE");
            });

            modelBuilder.Entity<Pelicula>(entity =>
            {
                entity.ToTable("PELICULA");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.ClasifPeli)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("CLASIF_PELI");

                entity.Property(e => e.CodEst).HasColumnName("COD_EST");

                entity.Property(e => e.CodGene).HasColumnName("COD_GENE");

                entity.Property(e => e.DescripPeli)
                    .HasMaxLength(250)
                    .IsUnicode(false)
                    .HasColumnName("DESCRIP_PELI");

                entity.Property(e => e.DurPeli)
                    .HasColumnType("time(0)")
                    .HasColumnName("DUR_PELI");

                entity.Property(e => e.IdPeli)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasColumnName("ID_PELI")
                    .HasComputedColumnSql("('PL'+right('000000'+CONVERT([varchar],[ID]),(6)))", false);

                entity.Property(e => e.Portada)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("PORTADA");

                entity.Property(e => e.Titulo)
                    .HasMaxLength(60)
                    .IsUnicode(false)
                    .HasColumnName("TITULO");

                entity.HasOne(d => d.CodEstNavigation)
                    .WithMany(p => p.Peliculas)
                    .HasForeignKey(d => d.CodEst)
                    .HasConstraintName("FK__PELICULA__COD_ES__398D8EEE");

                entity.HasOne(d => d.CodGeneNavigation)
                    .WithMany(p => p.Peliculas)
                    .HasForeignKey(d => d.CodGene)
                    .HasConstraintName("FK__PELICULA__COD_GE__38996AB5");
            });

            modelBuilder.Entity<Producto>(entity =>
            {
                entity.ToTable("PRODUCTO");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.CantProd).HasColumnName("CANT_PROD");

                entity.Property(e => e.IdProd)
                    .HasMaxLength(6)
                    .IsUnicode(false)
                    .HasColumnName("ID_PROD")
                    .HasComputedColumnSql("('PD'+right('0000'+CONVERT([varchar],[ID]),(4)))", false);

                entity.Property(e => e.NomProd)
                    .HasMaxLength(25)
                    .IsUnicode(false)
                    .HasColumnName("NOM_PROD");

                entity.Property(e => e.PrecioProd)
                    .HasColumnType("decimal(9, 2)")
                    .HasColumnName("PRECIO_PROD");
            });

            modelBuilder.Entity<RegistroAsiento>(entity =>
            {
                entity.ToTable("REGISTRO_ASIENTO");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.IdCartelera).HasColumnName("ID_CARTELERA");

                entity.Property(e => e.IdRst)
                    .HasMaxLength(6)
                    .IsUnicode(false)
                    .HasColumnName("ID_RST")
                    .HasComputedColumnSql("('RST'+right('000'+CONVERT([varchar],[ID]),(3)))", false);

                entity.Property(e => e.IdVenta).HasColumnName("ID_VENTA");

                entity.Property(e => e.NrRasiento).HasColumnName("NR_RASIENTO");

                entity.HasOne(d => d.IdCarteleraNavigation)
                    .WithMany(p => p.RegistroAsientos)
                    .HasForeignKey(d => d.IdCartelera)
                    .HasConstraintName("FK__REGISTRO___ID_CA__5441852A");

                entity.HasOne(d => d.IdVentaNavigation)
                    .WithMany(p => p.RegistroAsientos)
                    .HasForeignKey(d => d.IdVenta)
                    .HasConstraintName("FK__REGISTRO___ID_VE__534D60F1");
            });

            modelBuilder.Entity<Sala>(entity =>
            {
                entity.ToTable("SALA");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Asientos).HasColumnName("ASIENTOS");

                entity.Property(e => e.CodEst).HasColumnName("COD_EST");

                entity.Property(e => e.IdCine).HasColumnName("ID_CINE");

                entity.Property(e => e.IdForma).HasColumnName("ID_FORMA");

                entity.Property(e => e.IdSala)
                    .HasMaxLength(5)
                    .IsUnicode(false)
                    .HasColumnName("ID_SALA")
                    .HasComputedColumnSql("('CS-'+right('00'+CONVERT([varchar],[ID]),(2)))", false);

                entity.Property(e => e.NrSala).HasColumnName("NR_SALA");

                entity.HasOne(d => d.CodEstNavigation)
                    .WithMany(p => p.Salas)
                    .HasForeignKey(d => d.CodEst)
                    .HasConstraintName("FK__SALA__COD_EST__3E52440B");

                entity.HasOne(d => d.IdCineNavigation)
                    .WithMany(p => p.Salas)
                    .HasForeignKey(d => d.IdCine)
                    .HasConstraintName("FK__SALA__ID_CINE__3C69FB99");

                entity.HasOne(d => d.IdFormaNavigation)
                    .WithMany(p => p.Salas)
                    .HasForeignKey(d => d.IdForma)
                    .HasConstraintName("FK__SALA__ID_FORMA__3D5E1FD2");
            });

            modelBuilder.Entity<Ticket>(entity =>
            {
                entity.ToTable("TICKET");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.CodEst).HasColumnName("COD_EST");

                entity.Property(e => e.DescripTicket)
                    .HasMaxLength(90)
                    .IsUnicode(false)
                    .HasColumnName("DESCRIP_TICKET");

                entity.Property(e => e.IdTicket)
                    .HasMaxLength(4)
                    .IsUnicode(false)
                    .HasColumnName("ID_TICKET")
                    .HasComputedColumnSql("('TK'+right('00'+CONVERT([varchar],[ID]),(2)))", false);

                entity.Property(e => e.PrecioTicket)
                    .HasColumnType("decimal(9, 2)")
                    .HasColumnName("PRECIO_TICKET");

                entity.Property(e => e.Tipo)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("TIPO");

                entity.HasOne(d => d.CodEstNavigation)
                    .WithMany(p => p.Tickets)
                    .HasForeignKey(d => d.CodEst)
                    .HasConstraintName("FK__TICKET__COD_EST__300424B4");
            });

            modelBuilder.Entity<Ventum>(entity =>
            {
                entity.ToTable("VENTA");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.AsieVent).HasColumnName("ASIE_VENT");

                entity.Property(e => e.CodEst).HasColumnName("COD_EST");

                entity.Property(e => e.FechaVent)
                    .HasColumnType("date")
                    .HasColumnName("FECHA_VENT");

                entity.Property(e => e.IdCartelera).HasColumnName("ID_CARTELERA");

                entity.Property(e => e.IdCli).HasColumnName("ID_CLI");

                entity.Property(e => e.IdEmp).HasColumnName("ID_EMP");

                entity.Property(e => e.IdVenta)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasColumnName("ID_VENTA")
                    .HasComputedColumnSql("('VT'+right('000000'+CONVERT([varchar],[ID]),(6)))", false);

                entity.Property(e => e.TpagoVent)
                    .HasMaxLength(25)
                    .IsUnicode(false)
                    .HasColumnName("TPAGO_VENT");

                entity.HasOne(d => d.CodEstNavigation)
                    .WithMany(p => p.Venta)
                    .HasForeignKey(d => d.CodEst)
                    .HasConstraintName("FK__VENTA__COD_EST__5070F446");

                entity.HasOne(d => d.IdCarteleraNavigation)
                    .WithMany(p => p.Venta)
                    .HasForeignKey(d => d.IdCartelera)
                    .HasConstraintName("FK__VENTA__ID_CARTEL__4F7CD00D");

                entity.HasOne(d => d.IdCliNavigation)
                    .WithMany(p => p.Venta)
                    .HasForeignKey(d => d.IdCli)
                    .HasConstraintName("FK__VENTA__ID_CLI__4E88ABD4");

                entity.HasOne(d => d.IdEmpNavigation)
                    .WithMany(p => p.Venta)
                    .HasForeignKey(d => d.IdEmp)
                    .HasConstraintName("FK__VENTA__ID_EMP__4D94879B");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
