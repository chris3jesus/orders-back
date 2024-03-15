using System;
using System.Collections.Generic;

namespace OrdersBack.Models;

public partial class Clienteped
{
    public int Id { get; set; }

    public bool Creado { get; set; }

    public int CodVen { get; set; }

    public string NroDoc { get; set; } = null!;

    public string Nombre { get; set; } = null!;

    public string Comercial { get; set; } = null!;

    public string Direccion { get; set; } = null!;
}
