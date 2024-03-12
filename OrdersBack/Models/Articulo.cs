using System;
using System.Collections.Generic;

namespace OrdersBack.Models;

public partial class Articulo
{
    public decimal ArmCodart { get; set; }

    public string ArmCodcia { get; set; } = null!;

    public decimal? ArmStock { get; set; }

    public decimal? ArmIngresos { get; set; }

    public decimal? ArmSalidas { get; set; }

    public decimal? ArmStockIni { get; set; }

    public decimal? ArmCospro { get; set; }

    public decimal? ArmStock2 { get; set; }

    public decimal? ArmCostoUlt { get; set; }

    public DateTime? ArmFechaUlt { get; set; }

    public decimal? ArmSaldoS { get; set; }

    public decimal? ArmSaldoS2 { get; set; }

    public decimal? ArmSaldoN { get; set; }

    public decimal? ArmSaldoN2 { get; set; }
}
