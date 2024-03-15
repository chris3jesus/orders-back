using System;
using System.Collections.Generic;

namespace OrdersBack.Models;

public partial class Ubigeo
{
    public string UCodcia { get; set; } = null!;

    public string UUbigeo { get; set; } = null!;

    public string? UIddep { get; set; }

    public string? UIdprov { get; set; }

    public string? UIddist { get; set; }

    public string? UNomdep { get; set; }

    public string? UNomprov { get; set; }

    public string? UNomdist { get; set; }
}
