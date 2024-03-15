using System;
using System.Collections.Generic;

namespace OrdersBack.Models;

public partial class Tabla
{
    public string TabCodcia { get; set; } = null!;

    public int TabTipreg { get; set; }

    public int TabNumtab { get; set; }

    public string? TabNomlargo { get; set; }

    public string? TabNomcorto { get; set; }

    public decimal? TabCodart { get; set; }

    public string? TabContable2 { get; set; }

    public decimal? TabCodclie { get; set; }
}
