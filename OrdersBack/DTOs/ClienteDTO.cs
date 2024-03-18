namespace OrdersBack.DTOs
{
    public class ClienteDTO
    {
        public int Codigo { get; set; }
        public string? Documento { get; set; }
        public string? Razon { get; set; }
        public string? Nombre { get; set; }
        public string? Comercial { get; set; }
        public List<DireccionDTO> Direcciones { get; set; }
        public int Vendedor { get; set; }
    }

    public class DireccionDTO
    {
        public int Codigo { get; set; }
        public string? Direccion { get; set; }
        public string? Distrito { get; set; }
        public string? Provincia { get; set; }
        public string? Departamento { get; set; }
    }
}
