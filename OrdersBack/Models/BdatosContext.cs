using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace OrdersBack.Models;

public partial class BdatosContext : DbContext
{
    public BdatosContext()
    {
    }

    public BdatosContext(DbContextOptions<BdatosContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Arti> Artis { get; set; }

    public virtual DbSet<Articulo> Articulos { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=localhost;Database=BDATOS;Trusted_Connection=true;TrustServerCertificate=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Arti>(entity =>
        {
            entity.HasKey(e => new { e.ArtKey, e.ArtCodcia }).HasName("PK___3__12");

            entity.ToTable("ARTI");

            entity.HasIndex(e => new { e.ArtKey, e.ArtCodcia, e.ArtSituacion, e.ArtNombre, e.ArtAlterno }, "ARTI27");

            entity.HasIndex(e => new { e.ArtKey, e.ArtCodcia, e.ArtAlterno }, "ARTI35");

            entity.HasIndex(e => new { e.ArtKey, e.ArtCodcia, e.ArtNombre, e.ArtCalidad, e.ArtAlterno }, "ARTI4");

            entity.HasIndex(e => new { e.ArtKey, e.ArtCodcia, e.ArtNombre, e.ArtCalidad, e.ArtSituacion, e.ArtAlterno }, "ARTI6");

            entity.HasIndex(e => new { e.ArtNombre, e.ArtKey, e.ArtCodcia, e.ArtNumero, e.ArtMarca, e.ArtCalidad, e.ArtSituacion, e.ArtAlterno }, "ARTI9");

            entity.HasIndex(e => new { e.ArtKey, e.ArtAlterno, e.ArtCodcia, e.ArtNombre, e.ArtSituacion }, "ARTI99");

            entity.HasIndex(e => e.ArtNombre, "Nombre_Arti");

            entity.HasIndex(e => new { e.ArtKey, e.ArtCodcia, e.ArtFamilia }, "_dta_index_ARTI_5_149575571__K1_K2_K23_28_59");

            entity.HasIndex(e => e.ArtLinea, "linea");

            entity.Property(e => e.ArtKey)
                .HasColumnType("numeric(8, 0)")
                .HasColumnName("ART_KEY");
            entity.Property(e => e.ArtCodcia)
                .HasMaxLength(2)
                .IsUnicode(false)
                .IsFixedLength()
                .UseCollation("SQL_Latin1_General_CP1_CI_AS")
                .HasColumnName("ART_CODCIA");
            entity.Property(e => e.ArtAlterno)
                .HasMaxLength(15)
                .IsUnicode(false)
                .IsFixedLength()
                .UseCollation("SQL_Latin1_General_CP1_CI_AS")
                .HasColumnName("ART_ALTERNO");
            entity.Property(e => e.ArtCalidad)
                .HasDefaultValue(0)
                .HasColumnName("ART_CALIDAD");
            entity.Property(e => e.ArtCash)
                .HasDefaultValue(0m)
                .HasColumnType("numeric(11, 2)")
                .HasColumnName("ART_CASH");
            entity.Property(e => e.ArtCodSunat)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("ART_COD_SUNAT");
            entity.Property(e => e.ArtCodart2)
                .HasDefaultValue(0m)
                .HasColumnType("numeric(8, 0)")
                .HasColumnName("ART_CODART2");
            entity.Property(e => e.ArtCodclie)
                .HasDefaultValue(0m)
                .HasColumnType("numeric(8, 0)")
                .HasColumnName("ART_CODCLIE");
            entity.Property(e => e.ArtCodigoProv)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("ART_CODIGO_PROV");
            entity.Property(e => e.ArtCodprov)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasDefaultValue("")
                .IsFixedLength()
                .UseCollation("SQL_Latin1_General_CP1_CI_AS")
                .HasColumnName("ART_CODPROV");
            entity.Property(e => e.ArtCodusuOrig)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasDefaultValue(" ")
                .IsFixedLength()
                .HasColumnName("ART_CODUSU_ORIG");
            entity.Property(e => e.ArtConcentracion)
                .HasMaxLength(60)
                .IsUnicode(false)
                .HasColumnName("ART_CONCENTRACION");
            entity.Property(e => e.ArtCospro)
                .HasDefaultValue(0m)
                .HasColumnType("numeric(13, 4)")
                .HasColumnName("ART_COSPRO");
            entity.Property(e => e.ArtCosproAnt)
                .HasDefaultValue(0m)
                .HasColumnType("numeric(11, 4)")
                .HasColumnName("ART_COSPRO_ANT");
            entity.Property(e => e.ArtCosto)
                .HasDefaultValue(0m)
                .HasColumnType("numeric(11, 2)")
                .HasColumnName("ART_COSTO");
            entity.Property(e => e.ArtCp)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength()
                .UseCollation("SQL_Latin1_General_CP1_CI_AS")
                .HasColumnName("ART_CP");
            entity.Property(e => e.ArtCuentaContab)
                .HasMaxLength(12)
                .IsUnicode(false)
                .HasDefaultValue(" ")
                .IsFixedLength()
                .UseCollation("SQL_Latin1_General_CP1_CI_AS")
                .HasColumnName("ART_CUENTA_CONTAB");
            entity.Property(e => e.ArtCuentaContab69)
                .HasMaxLength(12)
                .IsUnicode(false)
                .HasDefaultValue(" ")
                .IsFixedLength()
                .UseCollation("SQL_Latin1_General_CP1_CI_AS")
                .HasColumnName("ART_CUENTA_CONTAB_69");
            entity.Property(e => e.ArtCuentaContab70)
                .HasMaxLength(12)
                .IsUnicode(false)
                .HasDefaultValue(" ")
                .IsFixedLength()
                .UseCollation("SQL_Latin1_General_CP1_CI_AS")
                .HasColumnName("ART_CUENTA_CONTAB_70");
            entity.Property(e => e.ArtCuentaContabC)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasDefaultValue(" ")
                .IsFixedLength()
                .UseCollation("SQL_Latin1_General_CP1_CI_AS")
                .HasColumnName("ART_CUENTA_CONTAB_C");
            entity.Property(e => e.ArtDecimales)
                .HasDefaultValue(0)
                .HasColumnName("ART_DECIMALES");
            entity.Property(e => e.ArtDesc1)
                .HasDefaultValue(0m)
                .HasColumnType("numeric(13, 2)")
                .HasColumnName("ART_DESC1");
            entity.Property(e => e.ArtDesc2)
                .HasDefaultValue(0m)
                .HasColumnType("numeric(13, 2)")
                .HasColumnName("ART_DESC2");
            entity.Property(e => e.ArtDescripProv)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("ART_DESCRIP_PROV");
            entity.Property(e => e.ArtDetraccion).HasColumnName("ART_DETRACCION");
            entity.Property(e => e.ArtDivision)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("ART_DIVISION");
            entity.Property(e => e.ArtDsctoPiso)
                .HasDefaultValue(0m)
                .HasColumnType("numeric(18, 2)")
                .HasColumnName("ART_DSCTO_PISO");
            entity.Property(e => e.ArtEquivProv).HasColumnName("ART_EQUIV_PROV");
            entity.Property(e => e.ArtEstado)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength()
                .UseCollation("SQL_Latin1_General_CP1_CI_AS")
                .HasColumnName("ART_ESTADO");
            entity.Property(e => e.ArtExIgv)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength()
                .UseCollation("SQL_Latin1_General_CP1_CI_AS")
                .HasColumnName("ART_EX_IGV");
            entity.Property(e => e.ArtFamilia)
                .HasDefaultValue(0)
                .HasColumnName("ART_FAMILIA");
            entity.Property(e => e.ArtFechahora)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasDefaultValue(" ")
                .IsFixedLength()
                .HasColumnName("ART_FECHAHORA");
            entity.Property(e => e.ArtFlagCambio)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength()
                .UseCollation("SQL_Latin1_General_CP1_CI_AS")
                .HasColumnName("ART_FLAG_CAMBIO");
            entity.Property(e => e.ArtFlagPsico)
                .HasMaxLength(1)
                .IsUnicode(false)
                .HasDefaultValue(" ")
                .IsFixedLength()
                .HasColumnName("ART_FLAG_PSICO");
            entity.Property(e => e.ArtFlagStock)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength()
                .UseCollation("SQL_Latin1_General_CP1_CI_AS")
                .HasColumnName("ART_FLAG_STOCK");
            entity.Property(e => e.ArtFormafarm)
                .HasMaxLength(60)
                .IsUnicode(false)
                .HasColumnName("ART_FORMAFARM");
            entity.Property(e => e.ArtIdDigemid)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasDefaultValue("")
                .HasColumnName("ART_ID_DIGEMID");
            entity.Property(e => e.ArtLinea)
                .HasDefaultValue(0)
                .HasColumnName("ART_LINEA");
            entity.Property(e => e.ArtMarca)
                .HasDefaultValue(0)
                .HasColumnName("ART_MARCA");
            entity.Property(e => e.ArtMargen)
                .HasDefaultValue(0m)
                .HasColumnType("numeric(11, 2)")
                .HasColumnName("ART_MARGEN");
            entity.Property(e => e.ArtMasterpack).HasColumnName("ART_MASTERPACK");
            entity.Property(e => e.ArtMoneda)
                .HasMaxLength(1)
                .IsUnicode(false)
                .HasDefaultValue("S")
                .IsFixedLength()
                .UseCollation("SQL_Latin1_General_CP1_CI_AS")
                .HasColumnName("ART_MONEDA");
            entity.Property(e => e.ArtNombre)
                .HasMaxLength(200)
                .IsUnicode(false)
                .IsFixedLength()
                .UseCollation("SQL_Latin1_General_CP1_CI_AS")
                .HasColumnName("ART_NOMBRE");
            entity.Property(e => e.ArtNumero)
                .HasDefaultValue(0)
                .HasColumnName("ART_NUMERO");
            entity.Property(e => e.ArtOrden)
                .HasDefaultValue(0)
                .HasColumnName("ART_ORDEN");
            entity.Property(e => e.ArtPercep)
                .HasMaxLength(1)
                .IsUnicode(false)
                .HasDefaultValue("")
                .IsFixedLength()
                .HasColumnName("ART_PERCEP");
            entity.Property(e => e.ArtPercep2)
                .HasMaxLength(1)
                .IsUnicode(false)
                .HasDefaultValue("")
                .IsFixedLength()
                .HasColumnName("ART_PERCEP2");
            entity.Property(e => e.ArtPlancha)
                .HasDefaultValue(0)
                .HasColumnName("ART_PLANCHA");
            entity.Property(e => e.ArtPor1)
                .HasDefaultValue(0m)
                .HasColumnType("numeric(5, 2)")
                .HasColumnName("ART_POR1");
            entity.Property(e => e.ArtPor11)
                .HasDefaultValue(0m)
                .HasColumnType("numeric(10, 2)")
                .HasColumnName("ART_POR11");
            entity.Property(e => e.ArtPor2)
                .HasDefaultValue(0m)
                .HasColumnType("numeric(5, 2)")
                .HasColumnName("ART_POR2");
            entity.Property(e => e.ArtPor22)
                .HasDefaultValue(0m)
                .HasColumnType("numeric(10, 2)")
                .HasColumnName("ART_POR22");
            entity.Property(e => e.ArtPor3)
                .HasDefaultValue(0m)
                .HasColumnType("numeric(5, 2)")
                .HasColumnName("ART_POR3");
            entity.Property(e => e.ArtPor33)
                .HasDefaultValue(0m)
                .HasColumnType("numeric(10, 2)")
                .HasColumnName("ART_POR33");
            entity.Property(e => e.ArtPor4)
                .HasDefaultValue(0m)
                .HasColumnType("numeric(5, 2)")
                .HasColumnName("ART_POR4");
            entity.Property(e => e.ArtPor44)
                .HasDefaultValue(0m)
                .HasColumnType("numeric(10, 2)")
                .HasColumnName("ART_POR44");
            entity.Property(e => e.ArtPor5)
                .HasDefaultValue(0m)
                .HasColumnType("numeric(5, 2)")
                .HasColumnName("ART_POR5");
            entity.Property(e => e.ArtPor55)
                .HasDefaultValue(0m)
                .HasColumnType("numeric(10, 2)")
                .HasColumnName("ART_POR55");
            entity.Property(e => e.ArtPor6)
                .HasDefaultValue(0m)
                .HasColumnType("numeric(5, 2)")
                .HasColumnName("ART_POR6");
            entity.Property(e => e.ArtPor66)
                .HasDefaultValue(0m)
                .HasColumnType("numeric(10, 2)")
                .HasColumnName("ART_POR66");
            entity.Property(e => e.ArtPorIgv)
                .HasDefaultValue(0m)
                .HasColumnType("numeric(11, 4)")
                .HasColumnName("ART_POR_IGV");
            entity.Property(e => e.ArtSituacion)
                .HasMaxLength(1)
                .IsUnicode(false)
                .HasDefaultValueSql("((0))")
                .IsFixedLength()
                .UseCollation("SQL_Latin1_General_CP1_CI_AS")
                .HasColumnName("ART_SITUACION");
            entity.Property(e => e.ArtStockMax)
                .HasDefaultValue(0m)
                .HasColumnType("numeric(11, 2)")
                .HasColumnName("ART_STOCK_MAX");
            entity.Property(e => e.ArtStockMin)
                .HasDefaultValue(0m)
                .HasColumnType("numeric(11, 2)")
                .HasColumnName("ART_STOCK_MIN");
            entity.Property(e => e.ArtStockrealMax)
                .HasDefaultValue(0m)
                .HasColumnType("numeric(11, 2)")
                .HasColumnName("ART_STOCKREAL_MAX");
            entity.Property(e => e.ArtStockrealMin)
                .HasDefaultValue(0m)
                .HasColumnType("numeric(11, 2)")
                .HasColumnName("ART_STOCKREAL_MIN");
            entity.Property(e => e.ArtSubfam)
                .HasDefaultValue(0)
                .HasColumnName("ART_SUBFAM");
            entity.Property(e => e.ArtSubgru)
                .HasDefaultValue(0)
                .HasColumnName("ART_SUBGRU");
            entity.Property(e => e.ArtTemperatura)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("ART_TEMPERATURA");
            entity.Property(e => e.ArtTipo)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength()
                .UseCollation("SQL_Latin1_General_CP1_CI_AS")
                .HasColumnName("ART_TIPO");
            entity.Property(e => e.ArtTipoarti)
                .HasDefaultValue(0)
                .HasColumnName("ART_TIPOARTI");
            entity.Property(e => e.ArtUndProv)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("ART_UND_PROV");
            entity.Property(e => e.ArtUnidad)
                .HasMaxLength(5)
                .IsUnicode(false)
                .IsFixedLength()
                .UseCollation("SQL_Latin1_General_CP1_CI_AS")
                .HasColumnName("ART_UNIDAD");
        });

        modelBuilder.Entity<Articulo>(entity =>
        {
            entity.HasKey(e => new { e.ArmCodart, e.ArmCodcia }).HasName("PK___3__10");

            entity.ToTable("ARTICULO");

            entity.HasIndex(e => new { e.ArmCodart, e.ArmCodcia, e.ArmStock }, "ARTICULO30");

            entity.Property(e => e.ArmCodart)
                .HasColumnType("numeric(8, 0)")
                .HasColumnName("ARM_CODART");
            entity.Property(e => e.ArmCodcia)
                .HasMaxLength(2)
                .IsUnicode(false)
                .IsFixedLength()
                .UseCollation("SQL_Latin1_General_CP1_CI_AS")
                .HasColumnName("ARM_CODCIA");
            entity.Property(e => e.ArmCospro)
                .HasDefaultValue(0m)
                .HasColumnType("numeric(11, 4)")
                .HasColumnName("ARM_COSPRO");
            entity.Property(e => e.ArmCostoUlt)
                .HasDefaultValue(0m)
                .HasColumnType("numeric(11, 2)")
                .HasColumnName("ARM_COSTO_ULT");
            entity.Property(e => e.ArmFechaUlt)
                .HasDefaultValueSql("(0)")
                .HasColumnType("datetime")
                .HasColumnName("ARM_FECHA_ULT");
            entity.Property(e => e.ArmIngresos)
                .HasDefaultValue(0m)
                .HasColumnType("numeric(13, 4)")
                .HasColumnName("ARM_INGRESOS");
            entity.Property(e => e.ArmSaldoN)
                .HasDefaultValue(0m)
                .HasColumnType("numeric(13, 4)")
                .HasColumnName("ARM_SALDO_N");
            entity.Property(e => e.ArmSaldoN2)
                .HasDefaultValue(0m)
                .HasColumnType("numeric(13, 4)")
                .HasColumnName("ARM_SALDO_N2");
            entity.Property(e => e.ArmSaldoS)
                .HasDefaultValue(0m)
                .HasColumnType("numeric(13, 4)")
                .HasColumnName("ARM_SALDO_S");
            entity.Property(e => e.ArmSaldoS2)
                .HasDefaultValue(0m)
                .HasColumnType("numeric(13, 4)")
                .HasColumnName("ARM_SALDO_S2");
            entity.Property(e => e.ArmSalidas)
                .HasDefaultValue(0m)
                .HasColumnType("numeric(13, 4)")
                .HasColumnName("ARM_SALIDAS");
            entity.Property(e => e.ArmStock)
                .HasDefaultValue(0m)
                .HasColumnType("numeric(13, 4)")
                .HasColumnName("ARM_STOCK");
            entity.Property(e => e.ArmStock2)
                .HasDefaultValue(0m)
                .HasColumnType("numeric(11, 4)")
                .HasColumnName("ARM_STOCK2");
            entity.Property(e => e.ArmStockIni)
                .HasDefaultValue(0m)
                .HasColumnType("numeric(13, 4)")
                .HasColumnName("ARM_STOCK_INI");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
