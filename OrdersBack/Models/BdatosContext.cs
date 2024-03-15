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

    public virtual DbSet<Cliente> Clientes { get; set; }

    public virtual DbSet<Clienteped> Clientepeds { get; set; }

    public virtual DbSet<Detpedido> Detpedidos { get; set; }

    public virtual DbSet<Dircli> Dirclis { get; set; }

    public virtual DbSet<Pedidoapp> Pedidoapps { get; set; }

    public virtual DbSet<Precio> Precios { get; set; }

    public virtual DbSet<Tabla> Tablas { get; set; }

    public virtual DbSet<Ubigeo> Ubigeos { get; set; }

    public virtual DbSet<Vemaest> Vemaests { get; set; }

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

        modelBuilder.Entity<Cliente>(entity =>
        {
            entity.HasKey(e => new { e.CliCodclie, e.CliCodcia, e.CliCp });

            entity.ToTable("CLIENTES");

            entity.HasIndex(e => new { e.CliCodclie, e.CliCp, e.CliNombre }, "CLIENTES26");

            entity.HasIndex(e => new { e.CliCodclie, e.CliCp, e.CliNombre, e.CliCodcia, e.CliNombreEmpresa, e.CliCasaZona, e.CliCasaSubzona, e.CliRucEsposo, e.CliGrupo, e.CliDepaCasa }, "CLIENTES7");

            entity.HasIndex(e => new { e.CliCodclie, e.CliCodcia, e.CliCp }, "_dta_index_CLIENTES_5_1312723729__K1_K2_K3_69");

            entity.Property(e => e.CliCodclie)
                .HasColumnType("numeric(8, 0)")
                .HasColumnName("CLI_CODCLIE");
            entity.Property(e => e.CliCodcia)
                .HasMaxLength(2)
                .IsUnicode(false)
                .IsFixedLength()
                .UseCollation("SQL_Latin1_General_CP1_CI_AS")
                .HasColumnName("CLI_CODCIA");
            entity.Property(e => e.CliCp)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength()
                .UseCollation("SQL_Latin1_General_CP1_CI_AS")
                .HasColumnName("CLI_CP");
            entity.Property(e => e.Capital).HasColumnType("decimal(12, 2)");
            entity.Property(e => e.Cli123)
                .HasColumnType("numeric(1, 0)")
                .HasColumnName("CLI_123");
            entity.Property(e => e.CliAm)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("CLI_AM");
            entity.Property(e => e.CliAp)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("CLI_AP");
            entity.Property(e => e.CliAuto1)
                .HasMaxLength(30)
                .IsUnicode(false)
                .IsFixedLength()
                .UseCollation("SQL_Latin1_General_CP1_CI_AS")
                .HasColumnName("CLI_AUTO1");
            entity.Property(e => e.CliAuto2)
                .HasMaxLength(30)
                .IsUnicode(false)
                .IsFixedLength()
                .UseCollation("SQL_Latin1_General_CP1_CI_AS")
                .HasColumnName("CLI_AUTO2");
            entity.Property(e => e.CliAutoavaluo)
                .HasMaxLength(20)
                .IsUnicode(false)
                .IsFixedLength()
                .UseCollation("SQL_Latin1_General_CP1_CI_AS")
                .HasColumnName("CLI_AUTOAVALUO");
            entity.Property(e => e.CliCanal)
                .HasDefaultValue(0)
                .HasColumnName("CLI_CANAL");
            entity.Property(e => e.CliCasa1)
                .HasMaxLength(30)
                .IsUnicode(false)
                .IsFixedLength()
                .UseCollation("SQL_Latin1_General_CP1_CI_AS")
                .HasColumnName("CLI_CASA1");
            entity.Property(e => e.CliCasa2)
                .HasMaxLength(30)
                .IsUnicode(false)
                .IsFixedLength()
                .UseCollation("SQL_Latin1_General_CP1_CI_AS")
                .HasColumnName("CLI_CASA2");
            entity.Property(e => e.CliCasaDirec)
                .HasMaxLength(80)
                .IsUnicode(false)
                .IsFixedLength()
                .UseCollation("SQL_Latin1_General_CP1_CI_AS")
                .HasColumnName("CLI_CASA_DIREC");
            entity.Property(e => e.CliCasaNum)
                .HasColumnType("numeric(4, 0)")
                .HasColumnName("CLI_CASA_NUM");
            entity.Property(e => e.CliCasaSubzona).HasColumnName("CLI_CASA_SUBZONA");
            entity.Property(e => e.CliCasaZona).HasColumnName("CLI_CASA_ZONA");
            entity.Property(e => e.CliCfinal)
                .HasDefaultValue(0)
                .HasColumnName("CLI_CFINAL");
            entity.Property(e => e.CliCiaRef)
                .HasMaxLength(2)
                .IsUnicode(false)
                .IsFixedLength()
                .UseCollation("SQL_Latin1_General_CP1_CI_AS")
                .HasColumnName("CLI_CIA_REF");
            entity.Property(e => e.CliCodart)
                .HasMaxLength(8)
                .IsUnicode(false)
                .IsFixedLength()
                .UseCollation("SQL_Latin1_General_CP1_CI_AS")
                .HasColumnName("CLI_CODART");
            entity.Property(e => e.CliCodven)
                .HasDefaultValue(0)
                .HasColumnName("CLI_CODVEN");
            entity.Property(e => e.CliContacto)
                .HasMaxLength(60)
                .IsUnicode(false)
                .HasColumnName("CLI_CONTACTO");
            entity.Property(e => e.CliCorreo)
                .HasMaxLength(60)
                .IsUnicode(false)
                .HasColumnName("CLI_CORREO");
            entity.Property(e => e.CliCorreo1)
                .HasMaxLength(60)
                .IsUnicode(false)
                .HasColumnName("CLI_CORREO1");
            entity.Property(e => e.CliCorreo2)
                .HasMaxLength(60)
                .IsUnicode(false)
                .HasColumnName("CLI_CORREO2");
            entity.Property(e => e.CliCorreo3)
                .HasMaxLength(60)
                .IsUnicode(false)
                .HasColumnName("CLI_CORREO3");
            entity.Property(e => e.CliCuentaContab)
                .HasMaxLength(12)
                .IsUnicode(false)
                .IsFixedLength()
                .UseCollation("SQL_Latin1_General_CP1_CI_AS")
                .HasColumnName("CLI_CUENTA_CONTAB");
            entity.Property(e => e.CliCuentaContab2)
                .HasMaxLength(12)
                .IsUnicode(false)
                .IsFixedLength()
                .UseCollation("SQL_Latin1_General_CP1_CI_AS")
                .HasColumnName("CLI_CUENTA_CONTAB2");
            entity.Property(e => e.CliCuentaContab22)
                .HasMaxLength(12)
                .IsUnicode(false)
                .IsFixedLength()
                .UseCollation("SQL_Latin1_General_CP1_CI_AS")
                .HasColumnName("CLI_CUENTA_CONTAB22");
            entity.Property(e => e.CliDepaCasa)
                .HasDefaultValue(0)
                .HasColumnName("CLI_DEPA_CASA");
            entity.Property(e => e.CliDetTot)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength()
                .UseCollation("SQL_Latin1_General_CP1_CI_AS")
                .HasColumnName("CLI_DET_TOT");
            entity.Property(e => e.CliDiaVisita).HasColumnName("CLI_DIA_VISITA");
            entity.Property(e => e.CliDiasCred).HasColumnName("CLI_DIAS_CRED");
            entity.Property(e => e.CliDiasFac).HasColumnName("CLI_DIAS_FAC");
            entity.Property(e => e.CliDireccionrep)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("CLI_DIRECCIONREP");
            entity.Property(e => e.CliDivision).HasColumnName("CLI_DIVISION");
            entity.Property(e => e.CliEstado)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength()
                .UseCollation("SQL_Latin1_General_CP1_CI_AS")
                .HasColumnName("CLI_ESTADO");
            entity.Property(e => e.CliFc)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("CLI_FC");
            entity.Property(e => e.CliFechaFac)
                .HasColumnType("datetime")
                .HasColumnName("CLI_FECHA_FAC");
            entity.Property(e => e.CliFechahora)
                .HasMaxLength(35)
                .IsUnicode(false)
                .HasDefaultValue(" ")
                .IsFixedLength()
                .HasColumnName("CLI_FECHAHORA");
            entity.Property(e => e.CliGrupo).HasColumnName("CLI_GRUPO");
            entity.Property(e => e.CliIdTipo).HasColumnName("CLI_ID_TIPO");
            entity.Property(e => e.CliIgvIncluido)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength()
                .UseCollation("SQL_Latin1_General_CP1_CI_AS")
                .HasColumnName("CLI_IGV_INCLUIDO");
            entity.Property(e => e.CliLetra)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength()
                .UseCollation("SQL_Latin1_General_CP1_CI_AS")
                .HasColumnName("CLI_LETRA");
            entity.Property(e => e.CliLimcre)
                .HasColumnType("numeric(11, 2)")
                .HasColumnName("CLI_LIMCRE");
            entity.Property(e => e.CliLimcre2)
                .HasColumnType("numeric(11, 2)")
                .HasColumnName("CLI_LIMCRE2");
            entity.Property(e => e.CliLugarCasa).HasColumnName("CLI_LUGAR_CASA");
            entity.Property(e => e.CliLugarTrab).HasColumnName("CLI_LUGAR_TRAB");
            entity.Property(e => e.CliMarcado)
                .HasMaxLength(1)
                .IsUnicode(false)
                .HasDefaultValue("0")
                .IsFixedLength()
                .HasColumnName("CLI_MARCADO");
            entity.Property(e => e.CliMoneda)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength()
                .UseCollation("SQL_Latin1_General_CP1_CI_AS")
                .HasColumnName("CLI_MONEDA");
            entity.Property(e => e.CliNomLet1)
                .HasMaxLength(40)
                .IsUnicode(false)
                .IsFixedLength()
                .UseCollation("SQL_Latin1_General_CP1_CI_AS")
                .HasColumnName("CLI_NOM_LET1");
            entity.Property(e => e.CliNomLet2)
                .HasMaxLength(40)
                .IsUnicode(false)
                .IsFixedLength()
                .UseCollation("SQL_Latin1_General_CP1_CI_AS")
                .HasColumnName("CLI_NOM_LET2");
            entity.Property(e => e.CliNombre)
                .HasMaxLength(60)
                .IsUnicode(false)
                .IsFixedLength()
                .UseCollation("SQL_Latin1_General_CP1_CI_AS")
                .HasColumnName("CLI_NOMBRE");
            entity.Property(e => e.CliNombreEmpresa)
                .HasMaxLength(60)
                .IsUnicode(false)
                .IsFixedLength()
                .UseCollation("SQL_Latin1_General_CP1_CI_AS")
                .HasColumnName("CLI_NOMBRE_EMPRESA");
            entity.Property(e => e.CliNombreEsposa)
                .HasMaxLength(60)
                .IsUnicode(false)
                .IsFixedLength()
                .UseCollation("SQL_Latin1_General_CP1_CI_AS")
                .HasColumnName("CLI_NOMBRE_ESPOSA");
            entity.Property(e => e.CliNombreEsposo)
                .HasMaxLength(60)
                .IsUnicode(false)
                .IsFixedLength()
                .UseCollation("SQL_Latin1_General_CP1_CI_AS")
                .HasColumnName("CLI_NOMBRE_ESPOSO");
            entity.Property(e => e.CliNombres)
                .HasMaxLength(80)
                .IsUnicode(false)
                .HasColumnName("CLI_NOMBRES");
            entity.Property(e => e.CliNucleo)
                .HasMaxLength(2)
                .IsUnicode(false)
                .IsFixedLength()
                .UseCollation("SQL_Latin1_General_CP1_CI_AS")
                .HasColumnName("CLI_NUCLEO");
            entity.Property(e => e.CliOtroContr)
                .HasMaxLength(1)
                .IsUnicode(false)
                .HasDefaultValue(" ")
                .IsFixedLength()
                .UseCollation("SQL_Latin1_General_CP1_CI_AS")
                .HasColumnName("CLI_OTRO_CONTR");
            entity.Property(e => e.CliPercep)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("CLI_PERCEP");
            entity.Property(e => e.CliPorPercep)
                .HasDefaultValue(0m)
                .HasColumnType("numeric(8, 2)")
                .HasColumnName("CLI_POR_PERCEP");
            entity.Property(e => e.CliPordescto)
                .HasColumnType("numeric(8, 2)")
                .HasColumnName("CLI_PORDESCTO");
            entity.Property(e => e.CliPrecios).HasColumnName("CLI_PRECIOS");
            entity.Property(e => e.CliPrenda)
                .HasMaxLength(30)
                .IsUnicode(false)
                .IsFixedLength()
                .UseCollation("SQL_Latin1_General_CP1_CI_AS")
                .HasColumnName("CLI_PRENDA");
            entity.Property(e => e.CliProgramado)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength()
                .UseCollation("SQL_Latin1_General_CP1_CI_AS")
                .HasColumnName("CLI_PROGRAMADO");
            entity.Property(e => e.CliRegpub1)
                .HasMaxLength(15)
                .IsUnicode(false)
                .IsFixedLength()
                .UseCollation("SQL_Latin1_General_CP1_CI_AS")
                .HasColumnName("CLI_REGPUB1");
            entity.Property(e => e.CliRegpub2)
                .HasMaxLength(100)
                .IsUnicode(false)
                .UseCollation("SQL_Latin1_General_CP1_CI_AS")
                .HasColumnName("CLI_REGPUB2");
            entity.Property(e => e.CliRucEmpresa)
                .HasMaxLength(15)
                .IsUnicode(false)
                .IsFixedLength()
                .UseCollation("SQL_Latin1_General_CP1_CI_AS")
                .HasColumnName("CLI_RUC_EMPRESA");
            entity.Property(e => e.CliRucEsposa)
                .HasMaxLength(15)
                .IsUnicode(false)
                .IsFixedLength()
                .UseCollation("SQL_Latin1_General_CP1_CI_AS")
                .HasColumnName("CLI_RUC_ESPOSA");
            entity.Property(e => e.CliRucEsposo)
                .HasMaxLength(15)
                .IsUnicode(false)
                .IsFixedLength()
                .UseCollation("SQL_Latin1_General_CP1_CI_AS")
                .HasColumnName("CLI_RUC_ESPOSO");
            entity.Property(e => e.CliSaldo)
                .HasColumnType("numeric(11, 2)")
                .HasColumnName("CLI_SALDO");
            entity.Property(e => e.CliSubgrupo)
                .HasMaxLength(4)
                .IsUnicode(false)
                .IsFixedLength()
                .UseCollation("SQL_Latin1_General_CP1_CI_AS")
                .HasColumnName("CLI_SUBGRUPO");
            entity.Property(e => e.CliTelef1)
                .HasMaxLength(50)
                .IsUnicode(false)
                .UseCollation("SQL_Latin1_General_CP1_CI_AS")
                .HasColumnName("CLI_TELEF1");
            entity.Property(e => e.CliTelef2)
                .HasMaxLength(12)
                .IsUnicode(false)
                .IsFixedLength()
                .UseCollation("SQL_Latin1_General_CP1_CI_AS")
                .HasColumnName("CLI_TELEF2");
            entity.Property(e => e.CliTipo)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength()
                .UseCollation("SQL_Latin1_General_CP1_CI_AS")
                .HasColumnName("CLI_TIPO");
            entity.Property(e => e.CliTipoBloq1)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength()
                .UseCollation("SQL_Latin1_General_CP1_CI_AS")
                .HasColumnName("CLI_TIPO_BLOQ1");
            entity.Property(e => e.CliTipoBloq2)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength()
                .UseCollation("SQL_Latin1_General_CP1_CI_AS")
                .HasColumnName("CLI_TIPO_BLOQ2");
            entity.Property(e => e.CliTipoBloq3)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength()
                .UseCollation("SQL_Latin1_General_CP1_CI_AS")
                .HasColumnName("CLI_TIPO_BLOQ3");
            entity.Property(e => e.CliTipoBloq4)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength()
                .UseCollation("SQL_Latin1_General_CP1_CI_AS")
                .HasColumnName("CLI_TIPO_BLOQ4");
            entity.Property(e => e.CliTipoClieVta)
                .HasDefaultValue(0)
                .HasColumnName("CLI_TIPO_CLIE_VTA");
            entity.Property(e => e.CliTrabDirec)
                .HasMaxLength(80)
                .IsUnicode(false)
                .IsFixedLength()
                .UseCollation("SQL_Latin1_General_CP1_CI_AS")
                .HasColumnName("CLI_TRAB_DIREC");
            entity.Property(e => e.CliTrabNum)
                .HasColumnType("numeric(4, 0)")
                .HasColumnName("CLI_TRAB_NUM");
            entity.Property(e => e.CliTrabProv).HasColumnName("CLI_TRAB_PROV");
            entity.Property(e => e.CliTrabSubzona).HasColumnName("CLI_TRAB_SUBZONA");
            entity.Property(e => e.CliTrabZona).HasColumnName("CLI_TRAB_ZONA");
            entity.Property(e => e.CliUbigeo)
                .HasMaxLength(6)
                .IsUnicode(false)
                .IsFixedLength()
                .UseCollation("SQL_Latin1_General_CP1_CI_AS")
                .HasColumnName("CLI_UBIGEO");
            entity.Property(e => e.CliVentas).HasColumnName("CLI_VENTAS");
            entity.Property(e => e.CliZonaNew).HasColumnName("CLI_ZONA_NEW");
            entity.Property(e => e.CopiaLitRp).HasColumnName("CopiaLitRP");
            entity.Property(e => e.FechaInicio).HasColumnType("datetime");
            entity.Property(e => e.FechaNacCli).HasColumnType("datetime");
            entity.Property(e => e.FechaReg)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.Infocorp)
                .HasMaxLength(200)
                .IsUnicode(false);
            entity.Property(e => e.Observaciones)
                .HasMaxLength(200)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Clienteped>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__CLIENTE_KEY");

            entity.ToTable("CLIENTEPED");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.Comercial)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Direccion)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Nombre)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.NroDoc)
                .HasMaxLength(11)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Detpedido>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__DETALLE_KEY");

            entity.ToTable("DETPEDIDO");

            entity.Property(e => e.Dscto1).HasColumnType("decimal(5, 2)");
            entity.Property(e => e.Dscto2).HasColumnType("decimal(5, 2)");
            entity.Property(e => e.Igv).HasColumnType("decimal(12, 2)");
            entity.Property(e => e.PrecDscto).HasColumnType("decimal(12, 4)");
            entity.Property(e => e.Precio).HasColumnType("decimal(12, 4)");
            entity.Property(e => e.Subtotal).HasColumnType("decimal(12, 2)");
            entity.Property(e => e.Total).HasColumnType("decimal(12, 2)");
            entity.Property(e => e.Valor).HasColumnType("decimal(12, 4)");

            entity.HasOne(d => d.IdPedNavigation).WithMany(p => p.Detpedidos)
                .HasForeignKey(d => d.IdPed)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__DETALLE_P__IdPed__4F7CD00D");
        });

        modelBuilder.Entity<Dircli>(entity =>
        {
            entity.HasKey(e => new { e.Codcia, e.Dircli1, e.Codcli, e.Cp }).IsClustered(false);

            entity.ToTable("DIRCLI", tb => tb.HasTrigger("Check_Direccion"));

            entity.Property(e => e.Codcia)
                .HasMaxLength(2)
                .IsUnicode(false)
                .IsFixedLength()
                .UseCollation("SQL_Latin1_General_CP1_CI_AS")
                .HasColumnName("CODCIA");
            entity.Property(e => e.Dircli1)
                .ValueGeneratedOnAdd()
                .HasColumnName("DIRCLI");
            entity.Property(e => e.Codcli)
                .HasColumnType("numeric(8, 0)")
                .HasColumnName("CODCLI");
            entity.Property(e => e.Cp)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength()
                .UseCollation("SQL_Latin1_General_CP1_CI_AS")
                .HasColumnName("CP");
            entity.Property(e => e.CliCasaSubzona).HasColumnName("CLI_CASA_SUBZONA");
            entity.Property(e => e.CliLugarTrab).HasColumnName("CLI_LUGAR_TRAB");
            entity.Property(e => e.CliTrabSubzona).HasColumnName("CLI_TRAB_SUBZONA");
            entity.Property(e => e.CliTrabZona).HasColumnName("CLI_TRAB_ZONA");
            entity.Property(e => e.Depa)
                .HasDefaultValue(0)
                .HasColumnName("depa");
            entity.Property(e => e.Dircomp)
                .HasMaxLength(200)
                .IsUnicode(false)
                .HasDefaultValue(" ")
                .UseCollation("SQL_Latin1_General_CP1_CI_AS")
                .HasColumnName("DIRCOMP");
            entity.Property(e => e.Direc)
                .HasMaxLength(100)
                .IsUnicode(false)
                .UseCollation("SQL_Latin1_General_CP1_CI_AS")
                .HasColumnName("DIREC");
            entity.Property(e => e.Numero).HasColumnName("NUMERO");
            entity.Property(e => e.Ref)
                .HasMaxLength(80)
                .IsUnicode(false)
                .UseCollation("SQL_Latin1_General_CP1_CI_AS")
                .HasColumnName("REF");
            entity.Property(e => e.Ubigeo)
                .HasMaxLength(6)
                .IsUnicode(false)
                .IsFixedLength()
                .UseCollation("SQL_Latin1_General_CP1_CI_AS")
                .HasColumnName("UBIGEO");
        });

        modelBuilder.Entity<Pedidoapp>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__PEDIDOS__3214EC07B9AF4618");

            entity.ToTable("PEDIDOAPP");

            entity.Property(e => e.Codigo)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.CondPago)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.Estado)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.FechaEdit).HasColumnType("datetime");
            entity.Property(e => e.FechaProc).HasColumnType("datetime");
            entity.Property(e => e.FechaReg).HasColumnType("datetime");
            entity.Property(e => e.Igv).HasColumnType("decimal(12, 2)");
            entity.Property(e => e.Latitud).HasColumnType("decimal(9, 6)");
            entity.Property(e => e.Longitud).HasColumnType("decimal(9, 6)");
            entity.Property(e => e.Observ)
                .HasMaxLength(200)
                .IsUnicode(false);
            entity.Property(e => e.Subtotal).HasColumnType("decimal(12, 2)");
            entity.Property(e => e.TipoDoc)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.Total).HasColumnType("decimal(12, 2)");
            entity.Property(e => e.UsuarioProc)
                .HasMaxLength(20)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Precio>(entity =>
        {
            entity.HasKey(e => new { e.PreCodcia, e.PreCodart, e.PreSecuencia }).HasName("PK___4__10");

            entity.ToTable("PRECIOS");

            entity.HasIndex(e => new { e.PreCodcia, e.PreCodart }, "PRECIOS34");

            entity.HasIndex(e => new { e.PreCodcia, e.PreCodart, e.PrePre1, e.PrePre2, e.PrePre3, e.PrePre4, e.PrePre5, e.PreUnidad, e.PreEquiv, e.PreFlagUnidad, e.PrePre6 }, "PRECIOS7");

            entity.Property(e => e.PreCodcia)
                .HasMaxLength(2)
                .IsUnicode(false)
                .IsFixedLength()
                .UseCollation("SQL_Latin1_General_CP1_CI_AS")
                .HasColumnName("PRE_CODCIA");
            entity.Property(e => e.PreCodart)
                .HasColumnType("numeric(8, 0)")
                .HasColumnName("PRE_CODART");
            entity.Property(e => e.PreSecuencia).HasColumnName("PRE_SECUENCIA");
            entity.Property(e => e.PreCosto)
                .HasDefaultValue(0m)
                .HasColumnType("numeric(11, 4)")
                .HasColumnName("PRE_COSTO");
            entity.Property(e => e.PreCostoAnt)
                .HasDefaultValue(0m)
                .HasColumnType("numeric(11, 4)")
                .HasColumnName("PRE_COSTO_ANT");
            entity.Property(e => e.PreCostoRepo)
                .HasDefaultValue(0m)
                .HasColumnType("numeric(11, 3)")
                .HasColumnName("PRE_COSTO_REPO");
            entity.Property(e => e.PreEquiv)
                .HasDefaultValue(1m)
                .HasColumnType("numeric(11, 2)")
                .HasColumnName("PRE_EQUIV");
            entity.Property(e => e.PreFlagUnidad)
                .HasMaxLength(1)
                .IsUnicode(false)
                .HasDefaultValue("A")
                .IsFixedLength()
                .UseCollation("SQL_Latin1_General_CP1_CI_AS")
                .HasColumnName("PRE_FLAG_UNIDAD");
            entity.Property(e => e.PreLitro)
                .HasDefaultValue(0m)
                .HasColumnType("numeric(11, 3)")
                .HasColumnName("PRE_LITRO");
            entity.Property(e => e.PrePeso)
                .HasDefaultValue(0m)
                .HasColumnType("numeric(11, 3)")
                .HasColumnName("PRE_PESO");
            entity.Property(e => e.PrePor1)
                .HasDefaultValue(0m)
                .HasColumnType("numeric(11, 3)")
                .HasColumnName("PRE_POR1");
            entity.Property(e => e.PrePor2)
                .HasDefaultValue(0m)
                .HasColumnType("numeric(11, 3)")
                .HasColumnName("PRE_POR2");
            entity.Property(e => e.PrePor3)
                .HasDefaultValue(0m)
                .HasColumnType("numeric(11, 3)")
                .HasColumnName("PRE_POR3");
            entity.Property(e => e.PrePor4)
                .HasDefaultValue(0m)
                .HasColumnType("numeric(11, 3)")
                .HasColumnName("PRE_POR4");
            entity.Property(e => e.PrePor5)
                .HasDefaultValue(0m)
                .HasColumnType("numeric(11, 3)")
                .HasColumnName("PRE_POR5");
            entity.Property(e => e.PrePor6)
                .HasDefaultValue(0m)
                .HasColumnType("numeric(11, 2)")
                .HasColumnName("PRE_POR6");
            entity.Property(e => e.PrePor7)
                .HasDefaultValue(0m)
                .HasColumnType("numeric(11, 2)")
                .HasColumnName("PRE_POR7");
            entity.Property(e => e.PrePor8)
                .HasDefaultValue(0m)
                .HasColumnType("numeric(11, 2)")
                .HasColumnName("PRE_POR8");
            entity.Property(e => e.PrePor9)
                .HasDefaultValue(0m)
                .HasColumnType("numeric(11, 4)")
                .HasColumnName("PRE_POR9");
            entity.Property(e => e.PrePre1)
                .HasDefaultValue(0m)
                .HasColumnType("numeric(11, 4)")
                .HasColumnName("PRE_PRE1");
            entity.Property(e => e.PrePre11)
                .HasDefaultValue(0m)
                .HasColumnType("numeric(11, 4)")
                .HasColumnName("PRE_PRE11");
            entity.Property(e => e.PrePre2)
                .HasDefaultValue(0m)
                .HasColumnType("numeric(11, 4)")
                .HasColumnName("PRE_PRE2");
            entity.Property(e => e.PrePre22)
                .HasDefaultValue(0m)
                .HasColumnType("numeric(11, 4)")
                .HasColumnName("PRE_PRE22");
            entity.Property(e => e.PrePre3)
                .HasDefaultValue(0m)
                .HasColumnType("numeric(11, 4)")
                .HasColumnName("PRE_PRE3");
            entity.Property(e => e.PrePre33)
                .HasDefaultValue(0m)
                .HasColumnType("numeric(11, 4)")
                .HasColumnName("PRE_PRE33");
            entity.Property(e => e.PrePre4)
                .HasDefaultValue(0m)
                .HasColumnType("numeric(11, 4)")
                .HasColumnName("PRE_PRE4");
            entity.Property(e => e.PrePre44)
                .HasDefaultValue(0m)
                .HasColumnType("numeric(11, 4)")
                .HasColumnName("PRE_PRE44");
            entity.Property(e => e.PrePre5)
                .HasDefaultValue(0m)
                .HasColumnType("numeric(11, 4)")
                .HasColumnName("PRE_PRE5");
            entity.Property(e => e.PrePre55)
                .HasDefaultValue(0m)
                .HasColumnType("numeric(11, 4)")
                .HasColumnName("PRE_PRE55");
            entity.Property(e => e.PrePre6)
                .HasDefaultValue(0m)
                .HasColumnType("numeric(11, 4)")
                .HasColumnName("PRE_PRE6");
            entity.Property(e => e.PrePre66)
                .HasDefaultValue(0m)
                .HasColumnType("numeric(11, 4)")
                .HasColumnName("PRE_PRE66");
            entity.Property(e => e.PrePre7)
                .HasDefaultValue(0m)
                .HasColumnType("numeric(11, 4)")
                .HasColumnName("PRE_PRE7");
            entity.Property(e => e.PrePre77)
                .HasDefaultValue(0m)
                .HasColumnType("numeric(11, 4)")
                .HasColumnName("PRE_PRE77");
            entity.Property(e => e.PrePre8)
                .HasDefaultValue(0m)
                .HasColumnType("numeric(11, 4)")
                .HasColumnName("PRE_PRE8");
            entity.Property(e => e.PrePre88)
                .HasDefaultValue(0m)
                .HasColumnType("numeric(11, 4)")
                .HasColumnName("PRE_PRE88");
            entity.Property(e => e.PrePre9)
                .HasDefaultValue(0m)
                .HasColumnType("numeric(11, 4)")
                .HasColumnName("PRE_PRE9");
            entity.Property(e => e.PrePre99)
                .HasDefaultValue(0m)
                .HasColumnType("numeric(11, 4)")
                .HasColumnName("PRE_PRE99");
            entity.Property(e => e.PrePrec1)
                .HasDefaultValue(0m)
                .HasColumnType("numeric(11, 4)")
                .HasColumnName("PRE_PREC1");
            entity.Property(e => e.PrePrec11)
                .HasDefaultValue(0m)
                .HasColumnType("numeric(11, 4)")
                .HasColumnName("PRE_PREC11");
            entity.Property(e => e.PrePrec2)
                .HasDefaultValue(0m)
                .HasColumnType("numeric(11, 4)")
                .HasColumnName("PRE_PREC2");
            entity.Property(e => e.PrePrec22)
                .HasDefaultValue(0m)
                .HasColumnType("numeric(11, 4)")
                .HasColumnName("PRE_PREC22");
            entity.Property(e => e.PrePrechi1)
                .HasDefaultValue(0m)
                .HasColumnType("numeric(11, 4)")
                .HasColumnName("PRE_PRECHI1");
            entity.Property(e => e.PrePrechi11)
                .HasDefaultValue(0m)
                .HasColumnType("numeric(11, 4)")
                .HasColumnName("PRE_PRECHI11");
            entity.Property(e => e.PreUnidad)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasDefaultValue("UNIDAD")
                .IsFixedLength()
                .UseCollation("SQL_Latin1_General_CP1_CI_AS")
                .HasColumnName("PRE_UNIDAD");
        });

        modelBuilder.Entity<Tabla>(entity =>
        {
            entity.HasKey(e => new { e.TabCodcia, e.TabTipreg, e.TabNumtab }).HasName("PK_TABLAS_1__13");

            entity.ToTable("TABLAS");

            entity.Property(e => e.TabCodcia)
                .HasMaxLength(2)
                .IsUnicode(false)
                .IsFixedLength()
                .UseCollation("SQL_Latin1_General_CP1_CI_AS")
                .HasColumnName("TAB_CODCIA");
            entity.Property(e => e.TabTipreg).HasColumnName("TAB_TIPREG");
            entity.Property(e => e.TabNumtab).HasColumnName("TAB_NUMTAB");
            entity.Property(e => e.TabCodart)
                .HasColumnType("numeric(8, 0)")
                .HasColumnName("TAB_CODART");
            entity.Property(e => e.TabCodclie)
                .HasColumnType("numeric(9, 0)")
                .HasColumnName("TAB_CODCLIE");
            entity.Property(e => e.TabContable2)
                .HasMaxLength(12)
                .IsUnicode(false)
                .HasDefaultValue(" ")
                .IsFixedLength()
                .UseCollation("SQL_Latin1_General_CP1_CI_AS")
                .HasColumnName("TAB_CONTABLE2");
            entity.Property(e => e.TabNomcorto)
                .HasMaxLength(10)
                .IsUnicode(false)
                .IsFixedLength()
                .UseCollation("SQL_Latin1_General_CP1_CI_AS")
                .HasColumnName("TAB_NOMCORTO");
            entity.Property(e => e.TabNomlargo)
                .HasMaxLength(40)
                .IsUnicode(false)
                .IsFixedLength()
                .UseCollation("SQL_Latin1_General_CP1_CI_AS")
                .HasColumnName("TAB_NOMLARGO");
        });

        modelBuilder.Entity<Ubigeo>(entity =>
        {
            entity.HasKey(e => new { e.UCodcia, e.UUbigeo });

            entity.ToTable("UBIGEO");

            entity.Property(e => e.UCodcia)
                .HasMaxLength(2)
                .IsUnicode(false)
                .IsFixedLength()
                .UseCollation("SQL_Latin1_General_CP1_CI_AS")
                .HasColumnName("U_CODCIA");
            entity.Property(e => e.UUbigeo)
                .HasMaxLength(6)
                .IsUnicode(false)
                .IsFixedLength()
                .UseCollation("SQL_Latin1_General_CP1_CI_AS")
                .HasColumnName("U_UBIGEO");
            entity.Property(e => e.UIddep)
                .HasMaxLength(2)
                .IsUnicode(false)
                .IsFixedLength()
                .UseCollation("SQL_Latin1_General_CP1_CI_AS")
                .HasColumnName("U_IDDEP");
            entity.Property(e => e.UIddist)
                .HasMaxLength(6)
                .IsUnicode(false)
                .IsFixedLength()
                .UseCollation("SQL_Latin1_General_CP1_CI_AS")
                .HasColumnName("U_IDDIST");
            entity.Property(e => e.UIdprov)
                .HasMaxLength(4)
                .IsUnicode(false)
                .IsFixedLength()
                .UseCollation("SQL_Latin1_General_CP1_CI_AS")
                .HasColumnName("U_IDPROV");
            entity.Property(e => e.UNomdep)
                .HasMaxLength(60)
                .IsUnicode(false)
                .IsFixedLength()
                .UseCollation("SQL_Latin1_General_CP1_CI_AS")
                .HasColumnName("U_NOMDEP");
            entity.Property(e => e.UNomdist)
                .HasMaxLength(60)
                .IsUnicode(false)
                .IsFixedLength()
                .UseCollation("SQL_Latin1_General_CP1_CI_AS")
                .HasColumnName("U_NOMDIST");
            entity.Property(e => e.UNomprov)
                .HasMaxLength(60)
                .IsUnicode(false)
                .IsFixedLength()
                .UseCollation("SQL_Latin1_General_CP1_CI_AS")
                .HasColumnName("U_NOMPROV");
        });

        modelBuilder.Entity<Vemaest>(entity =>
        {
            entity.HasKey(e => new { e.VemCodven, e.VemCodcia }).HasName("PK_VEMAEST_1__12");

            entity.ToTable("VEMAEST");

            entity.Property(e => e.VemCodven).HasColumnName("VEM_CODVEN");
            entity.Property(e => e.VemCodcia)
                .HasMaxLength(2)
                .IsUnicode(false)
                .IsFixedLength()
                .UseCollation("SQL_Latin1_General_CP1_CI_AS")
                .HasColumnName("VEM_CODCIA");
            entity.Property(e => e.Clave)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.VemAmLista)
                .HasDefaultValue(0)
                .HasColumnName("VEM_AM_LISTA");
            entity.Property(e => e.VemCodclieC)
                .HasDefaultValue(0m)
                .HasColumnType("numeric(9, 0)")
                .HasColumnName("VEM_CODCLIE_C");
            entity.Property(e => e.VemCodclieP)
                .HasDefaultValue(0m)
                .HasColumnType("numeric(9, 0)")
                .HasColumnName("VEM_CODCLIE_P");
            entity.Property(e => e.VemDesactivo)
                .HasMaxLength(1)
                .IsUnicode(false)
                .HasDefaultValue(" ")
                .IsFixedLength()
                .HasColumnName("VEM_DESACTIVO");
            entity.Property(e => e.VemDireccion)
                .HasMaxLength(40)
                .IsUnicode(false)
                .IsFixedLength()
                .UseCollation("SQL_Latin1_General_CP1_CI_AS")
                .HasColumnName("VEM_DIRECCION");
            entity.Property(e => e.VemFechaAuto)
                .HasColumnType("datetime")
                .HasColumnName("VEM_FECHA_AUTO");
            entity.Property(e => e.VemFechaIng)
                .HasColumnType("datetime")
                .HasColumnName("VEM_FECHA_ING");
            entity.Property(e => e.VemFlagB)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength()
                .UseCollation("SQL_Latin1_General_CP1_CI_AS")
                .HasColumnName("VEM_FLAG_B");
            entity.Property(e => e.VemFlagD)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength()
                .UseCollation("SQL_Latin1_General_CP1_CI_AS")
                .HasColumnName("VEM_FLAG_D");
            entity.Property(e => e.VemFlagF)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength()
                .UseCollation("SQL_Latin1_General_CP1_CI_AS")
                .HasColumnName("VEM_FLAG_F");
            entity.Property(e => e.VemFlagG)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength()
                .UseCollation("SQL_Latin1_General_CP1_CI_AS")
                .HasColumnName("VEM_FLAG_G");
            entity.Property(e => e.VemFlagN)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength()
                .UseCollation("SQL_Latin1_General_CP1_CI_AS")
                .HasColumnName("VEM_FLAG_N");
            entity.Property(e => e.VemFlagP)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength()
                .UseCollation("SQL_Latin1_General_CP1_CI_AS")
                .HasColumnName("VEM_FLAG_P");
            entity.Property(e => e.VemFlagPerc)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("VEM_FLAG_PERC");
            entity.Property(e => e.VemFlagR)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength()
                .UseCollation("SQL_Latin1_General_CP1_CI_AS")
                .HasColumnName("VEM_FLAG_R");
            entity.Property(e => e.VemNombre)
                .HasMaxLength(30)
                .IsUnicode(false)
                .IsFixedLength()
                .UseCollation("SQL_Latin1_General_CP1_CI_AS")
                .HasColumnName("VEM_NOMBRE");
            entity.Property(e => e.VemNroAuto)
                .HasMaxLength(80)
                .IsUnicode(false)
                .HasDefaultValue("")
                .HasColumnName("VEM_NRO_AUTO");
            entity.Property(e => e.VemNumPercFin)
                .HasColumnType("numeric(9, 0)")
                .HasColumnName("VEM_NUM_PERC_FIN");
            entity.Property(e => e.VemNumPercIni)
                .HasColumnType("numeric(9, 0)")
                .HasColumnName("VEM_NUM_PERC_INI");
            entity.Property(e => e.VemNumfacBFin)
                .HasColumnType("numeric(9, 0)")
                .HasColumnName("VEM_NUMFAC_B_FIN");
            entity.Property(e => e.VemNumfacBIni)
                .HasColumnType("numeric(9, 0)")
                .HasColumnName("VEM_NUMFAC_B_INI");
            entity.Property(e => e.VemNumfacDFin)
                .HasColumnType("numeric(9, 0)")
                .HasColumnName("VEM_NUMFAC_D_FIN");
            entity.Property(e => e.VemNumfacDIni)
                .HasColumnType("numeric(9, 0)")
                .HasColumnName("VEM_NUMFAC_D_INI");
            entity.Property(e => e.VemNumfacFFin)
                .HasColumnType("numeric(9, 0)")
                .HasColumnName("VEM_NUMFAC_F_FIN");
            entity.Property(e => e.VemNumfacFIni)
                .HasColumnType("numeric(9, 0)")
                .HasColumnName("VEM_NUMFAC_F_INI");
            entity.Property(e => e.VemNumfacGFin)
                .HasColumnType("numeric(9, 0)")
                .HasColumnName("VEM_NUMFAC_G_FIN");
            entity.Property(e => e.VemNumfacGIni)
                .HasColumnType("numeric(9, 0)")
                .HasColumnName("VEM_NUMFAC_G_INI");
            entity.Property(e => e.VemNumfacNFin)
                .HasColumnType("numeric(9, 0)")
                .HasColumnName("VEM_NUMFAC_N_FIN");
            entity.Property(e => e.VemNumfacNIni)
                .HasColumnType("numeric(9, 0)")
                .HasColumnName("VEM_NUMFAC_N_INI");
            entity.Property(e => e.VemNumfacPFin)
                .HasColumnType("numeric(9, 0)")
                .HasColumnName("VEM_NUMFAC_P_FIN");
            entity.Property(e => e.VemNumfacPIni)
                .HasColumnType("numeric(9, 0)")
                .HasColumnName("VEM_NUMFAC_P_INI");
            entity.Property(e => e.VemPor)
                .HasDefaultValue(0m)
                .HasColumnType("numeric(11, 2)")
                .HasColumnName("VEM_POR");
            entity.Property(e => e.VemSerieB).HasColumnName("VEM_SERIE_B");
            entity.Property(e => e.VemSerieD).HasColumnName("VEM_SERIE_D");
            entity.Property(e => e.VemSerieF).HasColumnName("VEM_SERIE_F");
            entity.Property(e => e.VemSerieG).HasColumnName("VEM_SERIE_G");
            entity.Property(e => e.VemSerieN).HasColumnName("VEM_SERIE_N");
            entity.Property(e => e.VemSerieP).HasColumnName("VEM_SERIE_P");
            entity.Property(e => e.VemSeriePerc).HasColumnName("VEM_SERIE_PERC");
            entity.Property(e => e.VemSerieR).HasColumnName("VEM_SERIE_R");
            entity.Property(e => e.VemTeleCasa)
                .HasMaxLength(12)
                .IsUnicode(false)
                .IsFixedLength()
                .UseCollation("SQL_Latin1_General_CP1_CI_AS")
                .HasColumnName("VEM_TELE_CASA");
            entity.Property(e => e.VemTeleCelu)
                .HasMaxLength(12)
                .IsUnicode(false)
                .IsFixedLength()
                .UseCollation("SQL_Latin1_General_CP1_CI_AS")
                .HasColumnName("VEM_TELE_CELU");
            entity.Property(e => e.VemTipovend).HasColumnName("VEM_TIPOVEND");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
