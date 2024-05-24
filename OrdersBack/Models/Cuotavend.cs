using System;
using System.Collections.Generic;

namespace OrdersBack.Models;

public partial class Cuotavend
{
    public string CuoCodcia { get; set; } = null!;

    public string CuoPeriodo { get; set; } = null!;

    public int CuoCodven { get; set; }

    public int CuoLinea { get; set; }

    public decimal CuoCodclie { get; set; }

    public decimal? CuoValor { get; set; }
}
