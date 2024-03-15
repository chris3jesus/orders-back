using System;
using System.Collections.Generic;

namespace OrdersBack.Models;

public partial class Cliente
{
    public decimal CliCodclie { get; set; }

    public string CliCodcia { get; set; } = null!;

    public string CliCp { get; set; } = null!;

    public string? CliNombre { get; set; }

    public string? CliNombreEsposo { get; set; }

    public string? CliNombreEsposa { get; set; }

    public string? CliNombreEmpresa { get; set; }

    public decimal? Cli123 { get; set; }

    public string? CliTelef1 { get; set; }

    public string? CliTelef2 { get; set; }

    public string? CliCasaDirec { get; set; }

    public decimal? CliCasaNum { get; set; }

    public int? CliCasaZona { get; set; }

    public int? CliCasaSubzona { get; set; }

    public string? CliTrabDirec { get; set; }

    public decimal? CliTrabNum { get; set; }

    public int? CliTrabZona { get; set; }

    public int? CliTrabSubzona { get; set; }

    public int? CliTrabProv { get; set; }

    public string? CliRucEsposo { get; set; }

    public string? CliRucEsposa { get; set; }

    public string? CliRucEmpresa { get; set; }

    public string? CliCasa1 { get; set; }

    public string? CliCasa2 { get; set; }

    public string? CliRegpub1 { get; set; }

    public string? CliRegpub2 { get; set; }

    public string? CliAutoavaluo { get; set; }

    public string? CliPrenda { get; set; }

    public string? CliAuto1 { get; set; }

    public string? CliAuto2 { get; set; }

    public string? CliIgvIncluido { get; set; }

    public string? CliOtroContr { get; set; }

    public string? CliLetra { get; set; }

    public decimal? CliLimcre { get; set; }

    public DateTime? CliFechaFac { get; set; }

    public string? CliTipoBloq1 { get; set; }

    public string? CliTipoBloq2 { get; set; }

    public string? CliTipoBloq3 { get; set; }

    public string? CliTipoBloq4 { get; set; }

    public string? CliDetTot { get; set; }

    public string? CliNomLet1 { get; set; }

    public string? CliNomLet2 { get; set; }

    public int? CliGrupo { get; set; }

    public string? CliSubgrupo { get; set; }

    public int? CliDivision { get; set; }

    public string? CliEstado { get; set; }

    public string? CliMoneda { get; set; }

    public string? CliCodart { get; set; }

    public string? CliNucleo { get; set; }

    public string? CliCuentaContab { get; set; }

    public string? CliCiaRef { get; set; }

    public decimal? CliPordescto { get; set; }

    public decimal? CliSaldo { get; set; }

    public int? CliPrecios { get; set; }

    public int? CliDiaVisita { get; set; }

    public int? CliZonaNew { get; set; }

    public string? CliProgramado { get; set; }

    public int? CliLugarCasa { get; set; }

    public int? CliLugarTrab { get; set; }

    public string? CliCuentaContab2 { get; set; }

    public int? CliDiasCred { get; set; }

    public int? CliDiasFac { get; set; }

    public string? CliCuentaContab22 { get; set; }

    public decimal? CliLimcre2 { get; set; }

    public string? CliTipo { get; set; }

    public string? CliFechahora { get; set; }

    public int? CliDepaCasa { get; set; }

    public int? CliCodven { get; set; }

    public string? CliUbigeo { get; set; }

    public string? CliMarcado { get; set; }

    public string? CliPercep { get; set; }

    public decimal? CliPorPercep { get; set; }

    public int? CliCfinal { get; set; }

    public string? CliAp { get; set; }

    public string? CliAm { get; set; }

    public string? CliNombres { get; set; }

    public int? CliIdTipo { get; set; }

    public int? CliTipoClieVta { get; set; }

    public int? CliCanal { get; set; }

    public int? CliVentas { get; set; }

    public string? CliCorreo { get; set; }

    public string? CliCorreo1 { get; set; }

    public string? CliCorreo2 { get; set; }

    public string? CliCorreo3 { get; set; }

    public string? CliContacto { get; set; }

    public string? CliDireccionrep { get; set; }

    public string? CliFc { get; set; }

    public bool? FichaRuc { get; set; }

    public DateTime? FechaInicio { get; set; }

    public bool? CopiaDni { get; set; }

    public DateTime? FechaNacCli { get; set; }

    public bool? ResolDigemid { get; set; }

    public int? RegimenTrib { get; set; }

    public bool? FactOtrosProv { get; set; }

    public string? Infocorp { get; set; }

    public bool? CopiaLitRp { get; set; }

    public bool? VigenciaPoder { get; set; }

    public decimal? Capital { get; set; }

    public string? Observaciones { get; set; }

    public DateTime? FechaReg { get; set; }
}
