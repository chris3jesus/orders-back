using System;
using System.Collections.Generic;

namespace OrdersBack.Models;

public partial class Dircli
{
    public string Codcia { get; set; } = null!;

    public int Dircli1 { get; set; }

    public decimal Codcli { get; set; }

    public string Cp { get; set; } = null!;

    public string? Direc { get; set; }

    public string? Ref { get; set; }

    public int CliLugarTrab { get; set; }

    public int CliTrabZona { get; set; }

    public int CliCasaSubzona { get; set; }

    public int CliTrabSubzona { get; set; }

    public int? Depa { get; set; }

    public int Numero { get; set; }

    public string Dircomp { get; set; } = null!;

    public string? Ubigeo { get; set; }
}
