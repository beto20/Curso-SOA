using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace WebApi.Model
{
    public partial class SOIContext : DbContext
    {
        public SOIContext()
        {
        }

        public SOIContext(DbContextOptions<SOIContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Actividade> Actividades { get; set; }
        public virtual DbSet<Cliente> Clientes { get; set; }
        public virtual DbSet<Facturacione> Facturaciones { get; set; }
        public virtual DbSet<FacturacionesDetalle> FacturacionesDetalles { get; set; }
        public virtual DbSet<Favorito> Favoritos { get; set; }
        public virtual DbSet<Galeria> Galerias { get; set; }
        public virtual DbSet<InformacionesGenerale> InformacionesGenerales { get; set; }
        public virtual DbSet<Pago> Pagos { get; set; }
        public virtual DbSet<Paise> Paises { get; set; }
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
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=.\\SQLExpress;Database=SOI;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "Modern_Spanish_CI_AS");

            modelBuilder.Entity<Actividade>(entity =>
            {
                entity.ToTable("actividades");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Actividad)
                    .HasMaxLength(80)
                    .IsUnicode(false)
                    .HasColumnName("actividad");

                entity.Property(e => e.IdPadre).HasColumnName("id_padre");

                entity.HasOne(d => d.IdPadreNavigation)
                    .WithMany(p => p.InverseIdPadreNavigation)
                    .HasForeignKey(d => d.IdPadre)
                    .HasConstraintName("FK_actividad_act");
            });

            modelBuilder.Entity<Cliente>(entity =>
            {
                entity.ToTable("clientes");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.PersonaId).HasColumnName("persona_id");

                entity.Property(e => e.PersonasJuridicaId).HasColumnName("personas_juridica_id");

                entity.Property(e => e.TipoPersona)
                    .HasColumnName("tipo_persona")
                    .HasDefaultValueSql("((1))");

                entity.HasOne(d => d.Persona)
                    .WithMany(p => p.Clientes)
                    .HasForeignKey(d => d.PersonaId)
                    .HasConstraintName("FK_clientes_personas_personas");

                entity.HasOne(d => d.PersonasJuridica)
                    .WithMany(p => p.Clientes)
                    .HasForeignKey(d => d.PersonasJuridicaId)
                    .HasConstraintName("FK_clientes_personas_juridicas");
            });

            modelBuilder.Entity<Facturacione>(entity =>
            {
                entity.ToTable("facturaciones");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Ciudad)
                    .HasMaxLength(80)
                    .IsUnicode(false)
                    .HasColumnName("ciudad");

                entity.Property(e => e.ClienteId).HasColumnName("cliente_id");

                entity.Property(e => e.Direccion)
                    .HasMaxLength(220)
                    .IsUnicode(false)
                    .HasColumnName("direccion");

                entity.Property(e => e.Documento)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("documento");

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
                    .HasColumnType("decimal(16, 2)")
                    .HasColumnName("tipo_de_cambio");

                entity.Property(e => e.TipoPersona).HasColumnName("tipo_persona");

                entity.HasOne(d => d.Cliente)
                    .WithMany(p => p.Facturaciones)
                    .HasForeignKey(d => d.ClienteId)
                    .HasConstraintName("FK_facturaciones_clientes");
            });

            modelBuilder.Entity<FacturacionesDetalle>(entity =>
            {
                entity.ToTable("facturaciones_detalles");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.CantidadPersonas).HasColumnName("cantidad_personas");

                entity.Property(e => e.FacturacionId).HasColumnName("facturacion_id");

                entity.Property(e => e.PrecioTotal)
                    .HasColumnType("decimal(16, 2)")
                    .HasColumnName("precio_total");

                entity.Property(e => e.PrecioUnitario)
                    .HasColumnType("decimal(16, 2)")
                    .HasColumnName("precio_unitario");

                entity.Property(e => e.ReservaId).HasColumnName("reserva_id");

                entity.HasOne(d => d.Facturacion)
                    .WithMany(p => p.FacturacionesDetalles)
                    .HasForeignKey(d => d.FacturacionId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_facturaciones_detalles_detalles");

                entity.HasOne(d => d.Reserva)
                    .WithMany(p => p.FacturacionesDetalles)
                    .HasForeignKey(d => d.ReservaId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_facturaciones_detalles_reserva");
            });

            modelBuilder.Entity<Favorito>(entity =>
            {
                entity.ToTable("favoritos");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Estado)
                    .HasColumnName("estado")
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.PaquetesTuristicoId).HasColumnName("paquetes_turistico_id");

                entity.Property(e => e.UsuarioId).HasColumnName("usuario_id");

                entity.HasOne(d => d.PaquetesTuristico)
                    .WithMany(p => p.Favoritos)
                    .HasForeignKey(d => d.PaquetesTuristicoId)
                    .HasConstraintName("FK_paquetes_favoritos_paquetes");

                entity.HasOne(d => d.Usuario)
                    .WithMany(p => p.Favoritos)
                    .HasForeignKey(d => d.UsuarioId)
                    .HasConstraintName("FK_paquetes_favoritos_usuarios");
            });

            modelBuilder.Entity<Galeria>(entity =>
            {
                entity.ToTable("galerias");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.PaquetesTuristicoId).HasColumnName("paquetes_turistico_id");

                entity.Property(e => e.Url)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("url");

                entity.HasOne(d => d.PaquetesTuristico)
                    .WithMany(p => p.Galeria)
                    .HasForeignKey(d => d.PaquetesTuristicoId)
                    .HasConstraintName("FK_paquetes_galerias");
            });

            modelBuilder.Entity<InformacionesGenerale>(entity =>
            {
                entity.ToTable("informaciones_generales");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.DetalleInformacionGeneral)
                    .HasColumnType("text")
                    .HasColumnName("detalle_informacion_general");

                entity.Property(e => e.Icons)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("icons");

                entity.Property(e => e.InformacionGeneral)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("informacion_general");

                entity.Property(e => e.MostrarBusqueda)
                    .HasColumnName("mostrar_busqueda")
                    .HasDefaultValueSql("((0))");
            });

            modelBuilder.Entity<Pago>(entity =>
            {
                entity.ToTable("pagos");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.FacturaId).HasColumnName("factura_id");

                entity.Property(e => e.TipoTarjeta)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("tipo_tarjeta");

                entity.HasOne(d => d.Factura)
                    .WithMany(p => p.Pagos)
                    .HasForeignKey(d => d.FacturaId)
                    .HasConstraintName("FK_facturaciones_pagos");
            });

            modelBuilder.Entity<Paise>(entity =>
            {
                entity.ToTable("paises");

                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("id");

                entity.Property(e => e.Codigo)
                    .HasColumnName("codigo")
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Iso2)
                    .IsRequired()
                    .HasMaxLength(2)
                    .HasColumnName("ISO2")
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Iso3)
                    .IsRequired()
                    .HasMaxLength(3)
                    .HasColumnName("ISO3")
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Pais)
                    .IsRequired()
                    .HasMaxLength(80)
                    .HasColumnName("pais")
                    .HasDefaultValueSql("('')");
            });

            modelBuilder.Entity<PaquetesInformacion>(entity =>
            {
                entity.ToTable("paquetes_informacion");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.InformacionesGeneraleId).HasColumnName("informaciones_generale_id");

                entity.Property(e => e.PaquetesTuristicoId).HasColumnName("paquetes_turistico_id");

                entity.HasOne(d => d.InformacionesGenerale)
                    .WithMany(p => p.PaquetesInformacions)
                    .HasForeignKey(d => d.InformacionesGeneraleId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_paquetes_informaciones_informaciones");

                entity.HasOne(d => d.PaquetesTuristico)
                    .WithMany(p => p.PaquetesInformacions)
                    .HasForeignKey(d => d.PaquetesTuristicoId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_paquetes_informaciones_paquetes");
            });

            modelBuilder.Entity<PaquetesTuristico>(entity =>
            {
                entity.ToTable("paquetes_turisticos");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.ActividadId).HasColumnName("actividad_id");

                entity.Property(e => e.Descripcion)
                    .HasColumnType("text")
                    .HasColumnName("descripcion");

                entity.Property(e => e.EsFlexible)
                    .HasColumnName("es_flexible")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.Estado)
                    .HasColumnName("estado")
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.FechaFin)
                    .HasColumnType("datetime")
                    .HasColumnName("fecha_fin");

                entity.Property(e => e.FechaInicio)
                    .HasColumnType("datetime")
                    .HasColumnName("fecha_inicio");

                entity.Property(e => e.IdCategoria).HasColumnName("id_categoria");

                entity.Property(e => e.IdPais).HasColumnName("id_pais");

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

                entity.Property(e => e.ProveedorId).HasColumnName("proveedor_id");

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
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("unidad_duracion");

                entity.HasOne(d => d.Actividad)
                    .WithMany(p => p.PaquetesTuristicos)
                    .HasForeignKey(d => d.ActividadId)
                    .HasConstraintName("FK_paquetes_actividades");

                entity.HasOne(d => d.IdPaisNavigation)
                    .WithMany(p => p.PaquetesTuristicos)
                    .HasForeignKey(d => d.IdPais)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_paquetes_paises");

                entity.HasOne(d => d.Proveedor)
                    .WithMany(p => p.PaquetesTuristicos)
                    .HasForeignKey(d => d.ProveedorId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_paquetes_proveedores");
            });

            modelBuilder.Entity<Perfile>(entity =>
            {
                entity.ToTable("perfiles");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Perfil)
                    .HasMaxLength(80)
                    .IsUnicode(false)
                    .HasColumnName("perfil");
            });

            modelBuilder.Entity<Persona>(entity =>
            {
                entity.ToTable("personas");

                entity.Property(e => e.Id).HasColumnName("id");

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
                entity.ToTable("pesonas_juridicas");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.CodigoPostal)
                    .HasMaxLength(5)
                    .IsUnicode(false)
                    .HasColumnName("codigo_postal");

                entity.Property(e => e.Direccion)
                    .HasMaxLength(220)
                    .IsUnicode(false)
                    .HasColumnName("direccion");

                entity.Property(e => e.NombreCompania)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("nombre_compania");

                entity.Property(e => e.PersonaId).HasColumnName("persona_id");

                entity.Property(e => e.Telefono)
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .HasColumnName("telefono");

                entity.Property(e => e.Ubicacion)
                    .HasMaxLength(220)
                    .IsUnicode(false)
                    .HasColumnName("ubicacion");

                entity.HasOne(d => d.Persona)
                    .WithMany(p => p.PesonasJuridicas)
                    .HasForeignKey(d => d.PersonaId)
                    .HasConstraintName("FK_juridicas_personas");
            });

            modelBuilder.Entity<ProvedoresRedesSociale>(entity =>
            {
                entity.ToTable("provedores_redes_sociales");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.ProveedorId).HasColumnName("proveedor_id");

                entity.Property(e => e.RedesSocialesId).HasColumnName("redes_sociales_id");

                entity.HasOne(d => d.Proveedor)
                    .WithMany(p => p.ProvedoresRedesSociales)
                    .HasForeignKey(d => d.ProveedorId)
                    .HasConstraintName("FK_proveedores_redes_proveedores");

                entity.HasOne(d => d.RedesSociales)
                    .WithMany(p => p.ProvedoresRedesSociales)
                    .HasForeignKey(d => d.RedesSocialesId)
                    .HasConstraintName("FK_proveedores_redes_redes");
            });

            modelBuilder.Entity<Proveedore>(entity =>
            {
                entity.ToTable("proveedores");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Estado)
                    .HasColumnName("estado")
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.Moneda)
                    .HasMaxLength(3)
                    .IsUnicode(false)
                    .HasColumnName("moneda");

                entity.Property(e => e.PersonaId).HasColumnName("persona_id");

                entity.Property(e => e.PersonasJuridicaId).HasColumnName("personas_juridica_id");

                entity.Property(e => e.TipoPersona).HasColumnName("tipo_persona");

                entity.HasOne(d => d.Persona)
                    .WithMany(p => p.Proveedores)
                    .HasForeignKey(d => d.PersonaId)
                    .HasConstraintName("FK_proveedores_personsas_personas");

                entity.HasOne(d => d.PersonasJuridica)
                    .WithMany(p => p.Proveedores)
                    .HasForeignKey(d => d.PersonasJuridicaId)
                    .HasConstraintName("FK_proveedores_personsas_juridicas");
            });

            modelBuilder.Entity<ProveedoresActividade>(entity =>
            {
                entity.ToTable("proveedores_actividades");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.ActividadId).HasColumnName("actividad_id");

                entity.Property(e => e.ProveedorId).HasColumnName("proveedor_id");

                entity.HasOne(d => d.Actividad)
                    .WithMany(p => p.ProveedoresActividades)
                    .HasForeignKey(d => d.ActividadId)
                    .HasConstraintName("FK_proveedores_actividades_actividades");

                entity.HasOne(d => d.Proveedor)
                    .WithMany(p => p.ProveedoresActividades)
                    .HasForeignKey(d => d.ProveedorId)
                    .HasConstraintName("FK_proveedores_actividades_proveedores");
            });

            modelBuilder.Entity<Rating>(entity =>
            {
                entity.ToTable("ratings");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.PaquetesTuristicoId).HasColumnName("paquetes_turistico_id");

                entity.Property(e => e.Rating1)
                    .HasColumnType("decimal(16, 2)")
                    .HasColumnName("rating");

                entity.Property(e => e.UsuarioId).HasColumnName("usuario_id");

                entity.HasOne(d => d.PaquetesTuristico)
                    .WithMany(p => p.Ratings)
                    .HasForeignKey(d => d.PaquetesTuristicoId)
                    .HasConstraintName("FK_paquetes_ratings");

                entity.HasOne(d => d.Usuario)
                    .WithMany(p => p.Ratings)
                    .HasForeignKey(d => d.UsuarioId)
                    .HasConstraintName("FK_paquetes_ratings_usuarios");
            });

            modelBuilder.Entity<RedesSociale>(entity =>
            {
                entity.ToTable("redes_sociales");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Estado)
                    .HasColumnName("estado")
                    .HasDefaultValueSql("((1))");

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
                entity.ToTable("reservas");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.CantidadPersonas)
                    .HasColumnName("cantidad_personas")
                    .HasDefaultValueSql("((1))");

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
                    .HasColumnType("datetime")
                    .HasColumnName("fecha_inicio");

                entity.Property(e => e.PaquetesTuristicoId).HasColumnName("paquetes_turistico_id");

                entity.Property(e => e.UsuarioId).HasColumnName("usuario_id");

                entity.HasOne(d => d.PaquetesTuristico)
                    .WithMany(p => p.Reservas)
                    .HasForeignKey(d => d.PaquetesTuristicoId)
                    .HasConstraintName("FK_paquetes_reservas_paquetes");

                entity.HasOne(d => d.Usuario)
                    .WithMany(p => p.Reservas)
                    .HasForeignKey(d => d.UsuarioId)
                    .HasConstraintName("FK_paquetes_reservas_usuarios");
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

                entity.Property(e => e.Password)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("password");

                entity.Property(e => e.PerfilId).HasColumnName("perfil_id");

                entity.Property(e => e.PersonaId).HasColumnName("persona_id");

                entity.Property(e => e.Token)
                    .HasColumnType("text")
                    .HasColumnName("token");

                entity.HasOne(d => d.Perfil)
                    .WithMany(p => p.Usuarios)
                    .HasForeignKey(d => d.PerfilId)
                    .HasConstraintName("FK_usuarios_perfiles");

                entity.HasOne(d => d.Persona)
                    .WithMany(p => p.Usuarios)
                    .HasForeignKey(d => d.PersonaId)
                    .HasConstraintName("FK_usuarios_personas");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
