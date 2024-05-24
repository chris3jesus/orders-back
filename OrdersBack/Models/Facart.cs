using System;
using System.Collections.Generic;

namespace OrdersBack.Models;

public partial class Facart
{
    public int FarTipmov { get; set; }

    public string FarCodcia { get; set; } = null!;

    public string FarNumser { get; set; } = null!;

    public string FarFbg { get; set; } = null!;

    public decimal FarNumfac { get; set; }

    public int FarNumsec { get; set; }

    public DateTime? FarFecha { get; set; }

    public int FarNumoper { get; set; }

    public decimal FarCodclie { get; set; }

    public decimal FarCodart { get; set; }

    public string? FarTransito { get; set; }

    public string FarEstado { get; set; } = null!;

    public decimal? FarNumguia { get; set; }

    public int FarDias { get; set; }

    public int? FarSignoArm { get; set; }

    public decimal FarPrecio { get; set; }

    public decimal FarStock { get; set; }

    public decimal FarCospro { get; set; }

    public decimal FarImpto { get; set; }

    public decimal FarTotDescto { get; set; }

    public decimal FarDescto { get; set; }

    public decimal FarGastos { get; set; }

    public decimal FarBruto { get; set; }

    public decimal FarEquiv { get; set; }

    public decimal FarPordescto1 { get; set; }

    public decimal FarTipoCambio { get; set; }

    public string? FarOtraCia { get; set; }

    public string? FarNumserC { get; set; }

    public decimal FarNumfacC { get; set; }

    public decimal FarNumdoc { get; set; }

    public string? FarCp { get; set; }

    public decimal FarLimcreAnt { get; set; }

    public decimal FarLimcreAct { get; set; }

    public string? FarTipoBloqAnt1 { get; set; }

    public string? FarTipoBloqAnt2 { get; set; }

    public int? FarKeyDircli { get; set; }

    public string? FarRuc { get; set; }

    public string? FarTipoBloqAct1 { get; set; }

    public string? FarDoccli { get; set; }

    public string? FarDircli { get; set; }

    public string? FarCliente { get; set; }

    public decimal FarPrecioNeto { get; set; }

    public int? FarCodven { get; set; }

    public decimal? FarUnidades { get; set; }

    public decimal? FarLitro { get; set; }

    public DateTime? FarFechaCompra { get; set; }

    public int? FarNumLote { get; set; }

    public decimal? FarCantidad { get; set; }

    public int? FarSignoLot { get; set; }

    public string? FarConcepto { get; set; }

    public string? FarCodSunat { get; set; }

    public decimal? FarFlete { get; set; }

    public decimal? FarCodartRef { get; set; }

    public int? FarJabas { get; set; }

    public string? FarDescri { get; set; }

    public int? FarMortal { get; set; }

    public decimal? FarPeso { get; set; }

    public decimal? FarTotFlete { get; set; }

    public string? FarExIgv { get; set; }

    public int? FarSignoCar { get; set; }

    public string? FarNumPrecio { get; set; }

    public string? FarFacturacionIgv { get; set; }

    public string? FarSubtra { get; set; }

    public int? FarPedser { get; set; }

    public decimal? FarPedfac { get; set; }

    public int? FarPedsec { get; set; }

    public int? FarOrdenUnidades { get; set; }

    public string? FarCodusu { get; set; }

    public string? FarMoneda { get; set; }

    public string? FarCosteo { get; set; }

    public decimal? FarCosproAnt { get; set; }

    public string? FarCosteoReal { get; set; }

    public string? FarHora { get; set; }

    public short? FarSerguia { get; set; }

    public decimal? FarCantidadP { get; set; }

    public short? FarTurno { get; set; }

    public string? FarTipdoc { get; set; }

    public string? FarEstado2 { get; set; }

    public string? FarPordesctos { get; set; }

    public string? FarFlagSo { get; set; }

    public short? FarNumoper2 { get; set; }

    public string? FarOc { get; set; }

    public decimal? FarCosproSup { get; set; }

    public DateTime? FarFechaPro { get; set; }

    public DateTime? FarFechaCan { get; set; }

    public decimal? FarSubtotal { get; set; }

    public string? FarCodlot { get; set; }

    public int? FarDirguia { get; set; }

    public DateTime? FarFechaLot { get; set; }

    public int? FarIdcampmif { get; set; }

    public string? FarCodcampmif { get; set; }

    public decimal? FarDsctomif { get; set; }

    public int? FarSecmif { get; set; }

    public string? FarCodmifP { get; set; }

    public decimal? SaldoCantidad { get; set; }

    public int? Iddocumento { get; set; }
}
