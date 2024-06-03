using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OrdersBack.Models;

namespace OrdersBack.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HelpersController : ControllerBase
    {
        private readonly BdatosContext _context;
        public HelpersController(BdatosContext context)
        {
            _context = context;
        }

        // GET: api/helpers/cliente/id
        [HttpGet("cliente/{id}")]
        public IActionResult GetCliente(int id)
        {
            var cliente = _context.Clientes.FirstOrDefault(a => a.CliCodclie == id && a.CliCodcia == "01" && a.CliEstado == "A");

            if (cliente != null)
            {
                return Ok(new { Message = id + " - " + cliente.CliNombreEmpresa.Trim() });
            }

            return Ok(new { Message = "Cliente no existe" });
        }

        // GET: api/helpers/vendedor/id
        [HttpGet("vendedor/{id}")]
        public IActionResult GetVendedor(int id)
        {
            var vendedor = _context.Vemaests.FirstOrDefault(v => v.VemCodven == id && v.VemDesactivo != "A" && v.VemCodcia == "01");

            if (vendedor != null)
            {
                return Ok(new { Message = id + " - " + vendedor.VemNombre.Trim() });
            }

            return Ok(new { Message = "Vendedor no existe" });
        }

        // GET: api/helpers/fecha
        [HttpGet("fecha")]
        public IActionResult GetFecha()
        {
            return Ok(new { Message = DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss") });
        }

        // GET: api/helpers
        [HttpGet]
        public IActionResult GetApp()
        {
            return Ok(new { ScrumMaster = "Jesús Carrasco", ProductOwner = "Juan Zegarra" });
        }
    }
}
