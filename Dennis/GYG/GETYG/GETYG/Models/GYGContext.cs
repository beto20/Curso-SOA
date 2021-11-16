using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace GETYG.Models
{
    public partial class GYGContext : DbContext
    {
        public GYGContext()
        {
        }

        public GYGContext(DbContextOptions<GYGContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Actividade> Actividades { get; set; }
        public virtual DbSet<Categoria> Categorias { get; set; }
        public virtual DbSet<Cliente> Clientes { get; set; }
        public virtual DbSet<Facturacione> Facturaciones { get; set; }
        public virtual DbSet<FacturacionesDetalle> FacturacionesDetalles { get; set; }
        public virtual DbSet<Favorito> Favoritos { get; set; }
        public virtual DbSet<Galeria> Galerias { get; set; }
        public virtual DbSet<InformacionesGenerale> InformacionesGenerales { get; set; }
        public virtual DbSet<Pago> Pagos { get; set; }
        public virtual DbSet<PaquetesInformacion> PaquetesInformacions { get; set; }
        public virtual DbSet<PaquetesTuristico> PaquetesTuristicos { get; set; }
        public virtual DbSet<Perfile> Perfiles { get; set; }
        public virtual DbSet<Persona> Personas { get; set; }
        public virtual DbSet<PesonasJuridica> PesonasJuridicas { get; set; }
        public virtual DbSet<ProvedoresRedesSociale> ProvedoresRedesSociales { get; set; }
        public virtual DbSet<Proveedore> Proveedores { get; set; }
        public virtual DbSet<ProveedoresActividade> ProveedoresActividades { get; set; }
        public virtual DbSet<Rating> Ratings { get; set; }
        public virtual DbSet<RedesSociale> RedesSociales { get; set; }
        public virtual DbSet<Reserva> Reservas { get; set; }
        public virtual DbSet<Usuario> Usuarios { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {

                optionsBuilder.UseSqlServer("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=GYG");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<Actividade>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("actividades");

                entity.Property(e => e.Actividad)
                    .HasMaxLength(80)
                    .IsUnicode(false)
                    .HasColumnName("actividad");

                entity.Property(e => e.Id)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("id");

                entity.Property(e => e.IdPadre).HasColumnName("id_padre");
            });

            modelBuilder.Entity<Categoria>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("categorias");

                entity.Property(e => e.Categorias)
                    .HasMaxLength(80)
                    .IsUnicode(false)
                    .HasColumnName("categorias");

                entity.Property(e => e.FechaCreacion)
                    .HasColumnType("date")
                    .HasColumnName("fecha_creacion");

                entity.Property(e => e.Id)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("id");
            });

            modelBuilder.Entity<Cliente>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("clientes");

                entity.Property(e => e.Id)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("id");

                entity.Property(e => e.IdPersona).HasColumnName("id_persona");

                entity.Property(e => e.IdPersonaJuridica).HasColumnName("id_persona_juridica");

                entity.Property(e => e.TipoPersona)
                    .HasColumnName("tipo_persona")
                    .HasDefaultValueSql("((1))");
            });

            modelBuilder.Entity<Facturacione>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("facturaciones");

                entity.Property(e => e.Ciudad)
                    .HasMaxLength(80)
                    .IsUnicode(false)
                    .HasColumnName("ciudad");

                entity.Property(e => e.Direccion)
                    .HasMaxLength(220)
                    .IsUnicode(false)
                    .HasColumnName("direccion");

                entity.Property(e => e.Documento)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("documento");

                entity.Property(e => e.Id)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("id");

                entity.Property(e => e.IdCliente).HasColumnName("id_cliente");

                entity.Property(e => e.Moneda)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("moneda");

                entity.Property(e => e.MontoTotal)
                    .HasColumnType("decimal(16, 2)")
                    .HasColumnName("monto_total");

                entity.Property(e => e.RazonSocial)
                    .HasMaxLength(220)
                    .IsUnicode(false)
                    .HasColumnName("razon_social");

                entity.Property(e => e.Simbolo)
                    .HasMaxLength(3)
                    .IsUnicode(false)
                    .HasColumnName("simbolo");

                entity.Property(e => e.TipoDeCambio)
                    .HasColumnType("decimal(18, 0)")
                    .HasColumnName("tipo_de_cambio");

                entity.Property(e => e.TipoPersona).HasColumnName("tipo_persona");
            });

            modelBuilder.Entity<FacturacionesDetalle>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("facturaciones_detalles");

                entity.Property(e => e.CantidadPersonas).HasColumnName("cantidad_personas");

                entity.Property(e => e.Id)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("id");

                entity.Property(e => e.IdFacturacion).HasColumnName("id_facturacion");

                entity.Property(e => e.IdReserva).HasColumnName("id_reserva");

                entity.Property(e => e.PrecioTotal)
                    .HasColumnType("decimal(16, 2)")
                    .HasColumnName("precio_total");

                entity.Property(e => e.PrecioUnitario)
                    .HasColumnType("decimal(16, 2)")
                    .HasColumnName("precio_unitario");
            });

            modelBuilder.Entity<Favorito>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("favoritos");

                entity.Property(e => e.Estado)
                    .HasColumnName("estado")
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.Id)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("id");

                entity.Property(e => e.IdPaqueteTuristico).HasColumnName("id_paquete_turistico");

                entity.Property(e => e.IdUsuario).HasColumnName("id_usuario");
            });

            modelBuilder.Entity<Galeria>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("galerias");

                entity.Property(e => e.Id)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("id");

                entity.Property(e => e.IdPaqueteTuristico).HasColumnName("id_paquete_turistico");

                entity.Property(e => e.Url)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("url");
            });

            modelBuilder.Entity<InformacionesGenerale>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("informaciones_generales");

                entity.Property(e => e.DetalleInformacionGeneral)
                    .HasColumnType("text")
                    .HasColumnName("detalle_informacion_general");

                entity.Property(e => e.Id)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("id");

                entity.Property(e => e.InformacionGeneral)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("informacion_general");

                entity.Property(e => e.MostrarBusqueda)
                    .HasColumnName("mostrar_busqueda")
                    .HasDefaultValueSql("((1))");
            });

            modelBuilder.Entity<Pago>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("pagos");

                entity.Property(e => e.Id)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("id");

                entity.Property(e => e.IdFactura).HasColumnName("id_factura");

                entity.Property(e => e.TipoTarjeta)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("tipo_tarjeta");
            });

            modelBuilder.Entity<PaquetesInformacion>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("paquetes_informacion");

                entity.Property(e => e.Id)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("id");

                entity.Property(e => e.IdInformacionGeneral).HasColumnName("id_informacion_general");

                entity.Property(e => e.IdPaqueteTuristico).HasColumnName("id_paquete_turistico");
            });

            modelBuilder.Entity<PaquetesTuristico>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("paquetes_turisticos");

                entity.Property(e => e.Descripcion)
                    .HasColumnType("text")
                    .HasColumnName("descripcion");

                entity.Property(e => e.EsFlexible).HasColumnName("es_flexible");

                entity.Property(e => e.Estado).HasColumnName("estado");

                entity.Property(e => e.FechaFin)
                    .HasColumnType("datetime")
                    .HasColumnName("fecha_fin");

                entity.Property(e => e.FechaInicio)
                    .HasColumnType("datetime")
                    .HasColumnName("fecha_inicio");

                entity.Property(e => e.Id)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("id");

                entity.Property(e => e.IdCategoria).HasColumnName("id_categoria");

                entity.Property(e => e.IdProveedor).HasColumnName("id_proveedor");

                entity.Property(e => e.MaxNumeroPersonas).HasColumnName("max_numero_personas");

                entity.Property(e => e.Moneda)
                    .HasMaxLength(3)
                    .IsUnicode(false)
                    .HasColumnName("moneda");

                entity.Property(e => e.PaqueteTuristico)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("paquete_turistico");

                entity.Property(e => e.PrecioUnitario)
                    .HasColumnType("decimal(16, 2)")
                    .HasColumnName("precio_unitario");

                entity.Property(e => e.Simbolo)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("simbolo")
                    .IsFixedLength(true);

                entity.Property(e => e.TiempoDuracion)
                    .HasColumnType("decimal(2, 1)")
                    .HasColumnName("tiempo_duracion");

                entity.Property(e => e.Ubicacion)
                    .HasMaxLength(220)
                    .IsUnicode(false)
                    .HasColumnName("ubicacion");

                entity.Property(e => e.UnidadDuracion)
                    .HasMaxLength(3)
                    .IsUnicode(false)
                    .HasColumnName("unidad_duracion");
            });

            modelBuilder.Entity<Perfile>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("perfiles");

                entity.Property(e => e.Id)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("id");

                entity.Property(e => e.Perfil)
                    .HasMaxLength(80)
                    .IsUnicode(false)
                    .HasColumnName("perfil");
            });

            modelBuilder.Entity<Persona>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("personas");

                entity.Property(e => e.Apellidos)
                    .HasMaxLength(60)
                    .IsUnicode(false)
                    .HasColumnName("apellidos");

                entity.Property(e => e.CodigoPostal)
                    .HasMaxLength(5)
                    .IsUnicode(false)
                    .HasColumnName("codigo_postal");

                entity.Property(e => e.Direccion)
                    .HasColumnType("text")
                    .HasColumnName("direccion");

                entity.Property(e => e.FechaNacimiento)
                    .HasColumnType("date")
                    .HasColumnName("fecha_nacimiento");

                entity.Property(e => e.Id)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("id");

                entity.Property(e => e.Nombres)
                    .HasMaxLength(60)
                    .IsUnicode(false)
                    .HasColumnName("nombres");

                entity.Property(e => e.Telefono)
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .HasColumnName("telefono");

                entity.Property(e => e.Ubicacion)
                    .HasColumnType("text")
                    .HasColumnName("ubicacion");
            });

            modelBuilder.Entity<PesonasJuridica>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("pesonas_juridicas");

                entity.Property(e => e.CodigoPostal)
                    .HasMaxLength(5)
                    .IsUnicode(false)
                    .HasColumnName("codigo_postal");

                entity.Property(e => e.Direccion)
                    .HasMaxLength(220)
                    .IsUnicode(false)
                    .HasColumnName("direccion");

                entity.Property(e => e.Id)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("id");

                entity.Property(e => e.IdRepresentanteLegal).HasColumnName("id_representante_legal");

                entity.Property(e => e.NombreCompania)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("nombre_compania");

                entity.Property(e => e.Telefono)
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .HasColumnName("telefono");

                entity.Property(e => e.Ubicacion)
                    .HasMaxLength(220)
                    .IsUnicode(false)
                    .HasColumnName("ubicacion");
            });

            modelBuilder.Entity<ProvedoresRedesSociale>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("provedores_redes_sociales");

                entity.Property(e => e.Id)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("id");

                entity.Property(e => e.IdProveedor).HasColumnName("id_proveedor");

                entity.Property(e => e.IdRedesSociales).HasColumnName("id_redes_sociales");
            });

            modelBuilder.Entity<Proveedore>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("proveedores");

                entity.Property(e => e.Estado)
                    .HasColumnName("estado")
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.IdPersona).HasColumnName("id_persona");

                entity.Property(e => e.IdPersonaJuridica).HasColumnName("id_persona_juridica");

                entity.Property(e => e.Moneda)
                    .HasMaxLength(3)
                    .IsUnicode(false)
                    .HasColumnName("moneda");

                entity.Property(e => e.TipoPersona).HasColumnName("tipo_persona");
            });

            modelBuilder.Entity<ProveedoresActividade>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("proveedores_actividades");

                entity.Property(e => e.Id)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("id");

                entity.Property(e => e.IdActividad).HasColumnName("id_actividad");

                entity.Property(e => e.IdProveedor).HasColumnName("id_proveedor");
            });

            modelBuilder.Entity<Rating>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("ratings");

                entity.Property(e => e.Id)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("id");

                entity.Property(e => e.IdPaqueteTuristico).HasColumnName("id_paquete_turistico");

                entity.Property(e => e.Rating1)
                    .HasColumnType("decimal(18, 0)")
                    .HasColumnName("rating");
            });

            modelBuilder.Entity<RedesSociale>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("redes_sociales");

                entity.Property(e => e.Estado)
                    .HasColumnName("estado")
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.Id)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("id");

                entity.Property(e => e.Placeholder)
                    .HasMaxLength(80)
                    .IsUnicode(false)
                    .HasColumnName("placeholder");

                entity.Property(e => e.RedSocial)
                    .HasMaxLength(80)
                    .IsUnicode(false)
                    .HasColumnName("red_social");
            });

            modelBuilder.Entity<Reserva>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("reservas");

                entity.Property(e => e.Estado)
                    .HasColumnName("estado")
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.FechaCreacion)
                    .HasColumnType("datetime")
                    .HasColumnName("fecha_creacion");

                entity.Property(e => e.FechaFin)
                    .HasColumnType("date")
                    .HasColumnName("fecha_fin");

                entity.Property(e => e.FechaInicio)
                    .HasColumnType("date")
                    .HasColumnName("fecha_inicio");

                entity.Property(e => e.Id)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("id");

                entity.Property(e => e.IdPaqueteTuristico).HasColumnName("id_paquete_turistico");

                entity.Property(e => e.IdUsuario).HasColumnName("id_usuario");
            });

            modelBuilder.Entity<Usuario>(entity =>
            {
                entity.ToTable("usuarios");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Correo)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("correo");

                entity.Property(e => e.FechaExpiracion)
                    .HasColumnType("datetime")
                    .HasColumnName("fecha_expiracion");

                entity.Property(e => e.FechaUltimaIngreso)
                    .HasColumnType("datetime")
                    .HasColumnName("fecha_ultima_ingreso");

                entity.Property(e => e.IbCorreoValido).HasColumnName("IB_CorreoValido");

                entity.Property(e => e.IdPerfil).HasColumnName("id_perfil");

                entity.Property(e => e.IdPersona).HasColumnName("id_persona");

                entity.Property(e => e.Password)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("password");

                entity.Property(e => e.Token)
                    .HasColumnType("text")
                    .HasColumnName("token");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
