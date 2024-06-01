using System;
using System.Collections.Generic;

namespace OrdersBack.Models;

public partial class Vemaest
{
    public int VemCodven { get; set; }

    public string VemCodcia { get; set; } = null!;

    public string? VemNombre { get; set; }

    public int? VemSerieG { get; set; }

    public decimal? VemNumfacGIni { get; set; }

    public int? VemSerieB { get; set; }

    public decimal? VemNumfacBIni { get; set; }

    public int? VemSerieF { get; set; }

    public decimal? VemNumfacFIni { get; set; }

    public decimal? VemNumfacGFin { get; set; }

    public decimal? VemNumfacBFin { get; set; }

    public decimal? VemNumfacFFin { get; set; }

    public string? VemFlagG { get; set; }

    public string? VemFlagB { get; set; }

    public string? VemFlagF { get; set; }

    public string? VemDireccion { get; set; }

    public DateTime? VemFechaIng { get; set; }

    public string? VemTeleCasa { get; set; }

    public string? VemTeleCelu { get; set; }

    public decimal? VemNumfacPIni { get; set; }

    public decimal? VemNumfacPFin { get; set; }

    public string? VemFlagP { get; set; }

    public int? VemSerieP { get; set; }

    public int? VemSerieR { get; set; }

    public string? VemFlagR { get; set; }

    public int? VemSerieN { get; set; }

    public decimal? VemNumfacNIni { get; set; }

    public decimal? VemNumfacNFin { get; set; }

    public int? VemSerieD { get; set; }

    public decimal? VemNumfacDIni { get; set; }

    public decimal? VemNumfacDFin { get; set; }

    public string? VemFlagN { get; set; }

    public string? VemFlagD { get; set; }

    public int? VemAmLista { get; set; }

    public string? VemDesactivo { get; set; }

    public decimal? VemPor { get; set; }

    public decimal? VemCodclieC { get; set; }

    public decimal? VemCodclieP { get; set; }

    public int? VemTipovend { get; set; }

    public string? VemFlagPerc { get; set; }

    public int? VemSeriePerc { get; set; }

    public decimal? VemNumPercIni { get; set; }

    public decimal? VemNumPercFin { get; set; }

    public string? VemNroAuto { get; set; }

    public DateTime? VemFechaAuto { get; set; }

    public string? Clave { get; set; }

    public bool? Supervisor { get; set; }
}
