using System;
using System.Collections.Generic;

namespace OrdersBack.Models;

public partial class Detpedido
{
    public int Id { get; set; }

    public int IdPed { get; set; }

    public int Item { get; set; }

    public string? IdProd { get; set; }

    public int Cantidad { get; set; }

    public decimal Valor { get; set; }

    public decimal Precio { get; set; }

    public decimal Dscto1 { get; set; }

    public decimal Dscto2 { get; set; }

    public decimal PrecDscto { get; set; }

    public decimal Subtotal { get; set; }

    public decimal Igv { get; set; }

    public decimal Total { get; set; }

    public decimal KeyProd { get; set; }

    public virtual Pedidoapp? IdPedNavigation { get; set; }
}
