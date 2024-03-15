﻿namespace OrdersBack.DTOs
{
    public class ProductoDTO
    {
        public int Codigo { get; set; }
        public string? Descripcion { get; set; }
        public string? Marca { get; set; }
        public string? Presentacion { get; set; }
        public decimal Precio { get; set; }
        public int Stock { get; set; }
    }
}
