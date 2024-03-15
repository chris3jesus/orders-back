using System;
using System.Collections.Generic;

namespace OrdersBack.Models;

public partial class Pedidoapp
{
    public int Id { get; set; }

    public string Codigo { get; set; } = null!;

    public int CodCli { get; set; }

    public int CodVen { get; set; }

    public string CondPago { get; set; } = null!;

    public int DiasCred { get; set; }

    public string TipoDoc { get; set; } = null!;

    public DateTime FechaReg { get; set; }

    public DateTime? FechaProc { get; set; }

    public string Estado { get; set; } = null!;

    public decimal Subtotal { get; set; }

    public decimal Igv { get; set; }

    public decimal Total { get; set; }

    public int IdDirCli { get; set; }

    public decimal Latitud { get; set; }

    public decimal Longitud { get; set; }

    public bool Flete { get; set; }

    public string Observ { get; set; } = null!;

    public DateTime? FechaEdit { get; set; }

    public string? UsuarioProc { get; set; }

    public virtual ICollection<Detpedido> Detpedidos { get; set; } = new List<Detpedido>();
}
